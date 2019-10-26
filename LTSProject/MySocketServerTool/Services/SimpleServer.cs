using MyToolkits.Log.TraceLog;
using SuperSocket.SocketBase;
using System;
using System.Linq;

namespace MySocketServerTool.Services
{
    /// <summary>
    /// Hello world
    /// </summary>
    public class SimpleServer
    {
        public SimpleServer()
        {
            _server = new AppServer();
            _port = 2333;
            if (!_server.Setup(_port))
            { TraceLog.WriteLine($"{_port} 设置失败"); return; }
            //处理请求
            //和Command不能共存
            //_server.NewRequestReceived += new RequestHandler<AppSession, StringRequestInfo>(Server_NewRequestReceived);
            _server.NewSessionConnected += Server_NewSessionConnected;
            _server.SessionClosed += Server_SessionClosed;
        }

        private void Server_SessionClosed(AppSession session, CloseReason value)
        {
            TraceLog.WriteLine($"{session.RemoteEndPoint.Address} {session.RemoteEndPoint.Port} Closed");
        }

        private void Server_NewSessionConnected(AppSession session)
        {
            TraceLog.WriteLine($"{session.RemoteEndPoint.Address} {session.RemoteEndPoint.Port} Connected");
        }

        private void Server_NewRequestReceived(AppSession session, SuperSocket.SocketBase.Protocol.StringRequestInfo requestInfo)
        {
            //requestInfo.Key 是请求的命令行用空格分隔开的第一部分
            //requestInfo.Parameters 是用空格分隔开的其余部分
            TraceLog.WriteLine(requestInfo.Body);
            switch (requestInfo.Key.ToUpper())
            {
                case ("ECHO"):
                    session.Send(requestInfo.Body);
                    break;

                case ("ADD"):
                    session.Send(requestInfo.Parameters.Select(p => Convert.ToInt32(p)).Sum().ToString());
                    break;

                case ("MULT"):

                    var result = 1;

                    foreach (var factor in requestInfo.Parameters.Select(p => Convert.ToInt32(p)))
                    {
                        result *= factor;
                    }

                    session.Send(result.ToString());
                    break;
            }
        }

        public void Start()
        {
            if (_server == null) return;

            if (_server.Start()) TraceLog.WriteLine($"{_port} 启动成功");
            else TraceLog.WriteLine($"{_port} 启动失败");
        }
        public void Stop()
        {
            if (_server == null) return;
            _server.Stop();
            TraceLog.WriteLine($"{_port} 停止");
        }
        int _port;
        AppServer _server;
        public int Port { get => _port; set => _port = value; }
    }
}
