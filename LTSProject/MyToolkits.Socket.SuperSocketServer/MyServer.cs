using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace MyToolkits.Socket.SuperSocketServer
{
    /// <summary>
    /// 监听客户端连接，承载TCP连接的服务器实例。
    /// 通过AppServer实例获取任何你想要的客户端连接。
    /// 服务器级别的操作和逻辑应该定义在此类之中。
    /// </summary>
    public class MyServer : AppServer<MySession, MyRequestInfo>
    {
        public MyServer()
           : base(new DefaultReceiveFilterFactory<MyReceiveFilter, MyRequestInfo>())
        {
            this.NewSessionConnected += MyServer_NewSessionConnected;
            this.SessionClosed += MyServer_SessionClosed;
        }

        public MyServer(SessionHandler<MySession> NewSessionConnected, SessionHandler<MySession, CloseReason> SessionClosed)
            : base(new DefaultReceiveFilterFactory<MyReceiveFilter, MyRequestInfo>())
        {
            this.NewSessionConnected += NewSessionConnected;
            this.SessionClosed += SessionClosed;
        }

        protected override void OnStarted()
        {
            //启动成功
        }

        void MyServer_NewSessionConnected(MySession session)
        {
            //连接成功
        }

        void MyServer_SessionClosed(MySession session, CloseReason value)
        {

        }
    }
}
