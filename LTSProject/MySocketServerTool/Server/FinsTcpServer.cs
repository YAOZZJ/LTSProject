using MySocketServerTool.Filter;
using MySocketServerTool.RequestInfo;
using MySocketServerTool.Session;
using MyToolkits.Log.TraceLog;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;

namespace MySocketServerTool.Server
{
    public class FinsTcpServer : AppServer<FinsSession,FinsTcpRequestInfo>
    {
        public FinsTcpServer()
        : base(new DefaultReceiveFilterFactory<FinsTcpReceiveFilter, FinsTcpRequestInfo>())
        {

        }

        /// <summary>
        /// 配置 Server
        /// </summary>
        /// <param name="rootConfig"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            //this.NewRequestReceived += CustomServer_NewRequestReceived;
            return base.Setup(rootConfig, config);
        }
        /// <summary>
        /// 与Command互斥
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        private void CustomServer_NewRequestReceived(CustomSession session, SuperSocket.SocketBase.Protocol.StringRequestInfo requestInfo)
        {
            TraceLog.WriteLine("CustomServer_NewRequestReceived...", logger: _logger);
        }

        /// <summary>
        /// 服务启动前
        /// </summary>
        protected override void OnStarted()
        {
            TraceLog.WriteLine("Started...", logger: _logger);
            base.OnStarted();
        }
        /// <summary>
        /// 服务停止前
        /// </summary>
        protected override void OnStopped()
        {
            TraceLog.WriteLine("Stopped...", logger: _logger);
            base.OnStopped();
        }
        /// <summary>
        /// 新链接
        /// </summary>
        /// <param name="session"></param>
        protected override void OnNewSessionConnected(FinsSession session)
        {
            //TraceLog.WriteLine("新的连接加入，标识：" + session.SessionID);
            TraceLog.WriteLine($"新链接: { session.RemoteEndPoint.Address.ToString()} { session.RemoteEndPoint.Port.ToString()}", logger: _logger);
            base.OnNewSessionConnected(session);
        }
        protected override void OnSessionClosed(FinsSession session, CloseReason reason)
        {
            TraceLog.WriteLine($"链接断开: { session.RemoteEndPoint.Address.ToString()} { session.RemoteEndPoint.Port.ToString()} , {reason.ToString()}", logger: _logger);
            base.OnSessionClosed(session, reason);
        }
        string _logger = "FinsTcpServer";
    }
}
