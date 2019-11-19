using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace MyToolkits.Sockets
{
    /// <summary>
    /// Socket服务端
    /// </summary>
    public class SocketServer
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ip">监听的IP地址</param>
        /// <param name="port">监听的端口</param>
        public SocketServer(string ip, int port)
        {
            _ip = ip;
            _port = port;
        }

        /// <summary>
        /// 构造函数,监听IP地址默认为本机0.0.0.0
        /// </summary>
        /// <param name="port">监听的端口</param>
        public SocketServer(int port)
        {
            _ip = "0.0.0.0";
            _port = port;
        }

        #endregion

        #region 内部成员

        private Socket _socket { get; set; } = null;
        private string _ip { get; set; } = "";
        private int _port { get; set; } = 0;
        private bool _isListen = false;
        private void StartListen()
        {
            try
            {
                _socket.BeginAccept(asyncResult =>
                {
                    try
                    {
                        Socket newSocket = _socket.EndAccept(asyncResult);//异步接受传入的连接尝试。

                        //马上进行下一轮监听,增加吞吐量
                        if (IsListen)
                            StartListen();

                        SocketConnection newConnection = new SocketConnection(newSocket, this)
                        {
                            HandleRecMsg = HandleRecMsg == null ? null : new Action<byte[], SocketConnection, SocketServer>(HandleRecMsg),
                            HandleClientClose = HandleClientClose == null ? null : new Action<SocketConnection, SocketServer>(HandleClientClose),
                            HandleSendMsg = HandleSendMsg == null ? null : new Action<byte[], SocketConnection, SocketServer>(HandleSendMsg),
                            HandleException = HandleException == null ? null : new Action<Exception>(HandleException)
                        };

                        newConnection.StartRecMsg();
                        AddConnection(newConnection);
                        HandleNewClientConnected?.BeginInvoke(this, newConnection, null, null);
                    }
                    catch (Exception ex)
                    {
                        HandleException?.BeginInvoke(ex, null, null);
                    }
                }, null);
            }
            catch (Exception ex)
            {
                HandleException?.BeginInvoke(ex, null, null);
            }
        }
        private LinkedList<SocketConnection> _clientList { get; } = new LinkedList<SocketConnection>();

        #endregion

        #region 外部接口

        public EndPoint RemoteEndPoint { get => _socket.RemoteEndPoint; }
        public IPEndPoint RemoteIPEndPoint { get => (IPEndPoint)_socket.RemoteEndPoint; }
        public EndPoint LocalEndPoint { get => _socket.LocalEndPoint; }
        public IPEndPoint LocalIPEndPoint { get => (IPEndPoint)_socket.LocalEndPoint; }

        /// <summary>
        /// 开始服务，监听客户端
        /// </summary>
        public void StartServer()
        {
            try
            {
                //创建ip对象
                IPAddress address = IPAddress.Parse(_ip);
                //创建网络节点对象包含ip和port
                IPEndPoint endpoint = new IPEndPoint(address, _port);
                //--------------------------------------------------------------------------------------
                //实例化套接字（ip4寻址协议，流式传输，TCP协议）
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //--------------------------------------------------------------------------------------
                //将 监听套接字绑定到 对应的IP和端口
                _socket.Bind(endpoint);
                //--------------------------------------------------------------------------------------
                //设置监听队列长度为Int32最大值(同时能够处理连接请求数量)
                _socket.Listen(int.MaxValue);
                //--------------------------------------------------------------------------------------
                //开始监听客户端
                StartListen();
                _isListen = true;
                HandleServerStarted?.BeginInvoke(this, null, null);
            }
            catch (Exception ex)
            {
                HandleException?.BeginInvoke(ex, null, null);
            }
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="bytes">数据字节</param>
        public void Send(byte[] bytes,string remoteEndpoint = null)
        {
            try
            {
                //LinkedListNode<SocketConnection> node = _clientList.First;
                //node.Value.Send(bytes);
                if(string.IsNullOrEmpty(remoteEndpoint))
                    foreach(var node in GetConnectionList())
                    {
                        node.Send(bytes);
                    }
                else
                {
                    var node = GetTheConnection(session => session.RemoteEndPoint.ToString() == remoteEndpoint);
                    node.Send(bytes);
                }
            }
            catch (Exception ex)
            {
                HandleException?.BeginInvoke(ex, null, null);
            }
        }

        /// <summary>
        /// 发送字符串（默认使用UTF-8编码）
        /// </summary>
        /// <param name="msgStr">字符串</param>
        public void Send(string msgStr, string remoteEndpoint = null)
        {
            Send(Encoding.Default.GetBytes(msgStr), remoteEndpoint);
        }

        /// <summary>
        /// 发送字符串（使用自定义编码）
        /// </summary>
        /// <param name="msgStr">字符串消息</param>
        /// <param name="encoding">使用的编码</param>
        public void Send(string msgStr, Encoding encoding)
        {
            Send(encoding.GetBytes(msgStr));
        }

        /// <summary>
        /// 维护客户端列表的读写锁
        /// </summary>
        public ReaderWriterLockSlim RWLock_ClientList { get; } = new ReaderWriterLockSlim();

        /// <summary>
        /// 关闭指定客户端连接
        /// </summary>
        /// <param name="theConnection">指定的客户端连接</param>
        public void CloseConnection(SocketConnection theConnection)
        {
            theConnection.Close();
        }

        /// <summary>
        /// 添加客户端连接
        /// </summary>
        /// <param name="theConnection">需要添加的客户端连接</param>
        public void AddConnection(SocketConnection theConnection)
        {
            RWLock_ClientList.EnterWriteLock();
            try
            {
                _clientList.AddLast(theConnection);
            }
            finally
            {
                RWLock_ClientList.ExitWriteLock();
            }
        }

        /// <summary>
        /// 删除指定的客户端连接
        /// </summary>
        /// <param name="theConnection">指定的客户端连接</param>
        public void RemoveConnection(SocketConnection theConnection)
        {
            RWLock_ClientList.EnterWriteLock();
            try
            {
                _clientList.Remove(theConnection);
            }
            finally
            {
                RWLock_ClientList.ExitWriteLock();
            }
        }

        /// <summary>
        /// 通过条件获取客户端连接列表
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <returns></returns>
        public IEnumerable<SocketConnection> GetConnectionList(Func<SocketConnection, bool> predicate)
        {
            RWLock_ClientList.EnterReadLock();
            try
            {
                return _clientList.Where(predicate);
            }
            finally
            {
                RWLock_ClientList.ExitReadLock();
            }
        }

        /// <summary>
        /// 获取所有客户端连接列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SocketConnection> GetConnectionList()
        {
            return _clientList;
        }

        /// <summary>
        /// 寻找特定条件的客户端连接
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <returns></returns>
        public SocketConnection GetTheConnection(Func<SocketConnection, bool> predicate)
        {
            RWLock_ClientList.EnterReadLock();
            try
            {
                return _clientList.Where(predicate).FirstOrDefault();
            }
            finally
            {
                RWLock_ClientList.ExitReadLock();
            }
        }

        /// <summary>
        /// 获取客户端连接数
        /// </summary>
        /// <returns></returns>
        public int GetConnectionCount()
        {
            RWLock_ClientList.EnterReadLock();
            try
            {
                return _clientList.Count;
            }
            finally
            {
                RWLock_ClientList.ExitReadLock();
            }
        }
        public List<EndPoint> GetRemoteEndPointList()
        {
            if (_clientList == null) return null;
            List<EndPoint> endPoints = new List<EndPoint>();
            foreach(var node in _clientList)
            {
                endPoints.Add(node.RemoteEndPoint);
            }
            return endPoints;
        }

        #endregion

        #region 公共事件

        /// <summary>
        /// 异常处理程序
        /// </summary>
        public Action<Exception> HandleException { get; set; }

        #endregion

        #region 服务端事件

        /// <summary>
        /// 服务启动后执行
        /// </summary>
        public Action<SocketServer> HandleServerStarted { get; set; }

        /// <summary>
        /// 当新客户端连接后执行
        /// </summary>
        public Action<SocketServer, SocketConnection> HandleNewClientConnected { get; set; }

        /// <summary>
        /// 服务端关闭客户端后执行
        /// </summary>
        public Action<SocketServer, SocketConnection> HandleCloseClient { get; set; }

        #endregion

        #region 客户端连接事件

        /// <summary>
        /// 客户端连接接受新的消息后调用
        /// </summary>
        public Action<byte[], SocketConnection, SocketServer> HandleRecMsg { get; set; }

        /// <summary>
        /// 客户端连接发送消息后回调
        /// </summary>
        public Action<byte[], SocketConnection, SocketServer> HandleSendMsg { get; set; }

        /// <summary>
        /// 客户端连接关闭后回调
        /// </summary>
        public Action<SocketConnection, SocketServer> HandleClientClose { get; set; }
        public bool IsListen { get => _isListen; set => _isListen = value; }

        #endregion

        #region 测试功能用
        #endregion
    }
}
