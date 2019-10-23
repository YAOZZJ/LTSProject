using MyToolkits.Socket.Core;
using SuperSocket.SocketBase;

namespace MyToolkits.Socket.SuperSocketServer
{
    public class Server
    {
        public Server()
        {
            TcpServerInital();
        }
        MyServer appServer;
        int port = 2333;
        #region "SocketTCPServer"
        void TcpServerInital()
        {
            if (appServer != null && appServer.State == SuperSocket.SocketBase.ServerState.Running)
                return;
            var config = new SuperSocket.SocketBase.Config.ServerConfig()
            {
                Name = "SuperSocketServer",
                ServerTypeName = "SuperSocketServer",
                ClearIdleSession = true, //60秒执行一次清理90秒没数据传送的连接
                ClearIdleSessionInterval = 60,
                IdleSessionTimeOut = 90,
                MaxRequestLength = 10000, //最大包长度
                Ip = "Any",
                Port = port,
                MaxConnectionNumber = 10000,//最大允许的客户端连接数目
            };
            appServer = new MyServer(app_NewSessionConnected, app_SessionClosed);
            //移除请求处理方法的注册，因为它和命令不能同时被支持：
            appServer.NewRequestReceived -= App_NewRequestReceived;
            appServer.NewRequestReceived += App_NewRequestReceived;
            appServer.Setup(config);
            if (!appServer.Start())
            {
                //Message("初始化服务失败");
            }
            //else Message("初始化服务成功");
        }

        //客户端断开
        void app_SessionClosed(MySession session, CloseReason value)
        {
            //Message($"客户端{session.SessionID}已断开，原因：{value.ToString()}");
        }
        //客户端连接
        void app_NewSessionConnected(MySession session)
        {
            //Message($"客户端{session.SessionID}已连接");
            session.Send("qqqqq");
        }
        //接收客户端消息
        void App_NewRequestReceived(MySession session, MyRequestInfo requestInfo)
        {
            //if (requestInfo == null) return;
            //if (!requestInfo.IsHeart)
            //Message($"收到{session.SessionID}消息：{requestInfo.Body}");
            //是否显示心跳包
            //else if (cbIgnoreHeart.IsChecked == false)
            //{
            //    txbReceive.AppendText($"收到{session.SessionID}心跳：{requestInfo.Body}" + '\n');
            //}
            ////发送心跳反馈
            //if (requestInfo.IsHeart && cbSendHeart.IsChecked == true)
            //{
            //    var msg = CommandBuilder.BuildHeartCmd();
            //    if (session.Connected)
            //        session.Send(msg, 0, msg.Length);
            //}
        }
        //发送消息
        protected bool Send(string message)
        {
            if (appServer != null && appServer.State == SuperSocket.SocketBase.ServerState.Running && !string.IsNullOrEmpty(message))
            {
                foreach (var item in appServer.GetAllSessions())
                {
                    if (item.Connected)
                    {
                        var msg = CommandBuilder.BuildMsgCmd(message);
                        item.Send(msg, 0, msg.Length);
                    }
                }
                return true;
            }
            return false;
        }
        #endregion "SocketTCPServer"

    }
}
