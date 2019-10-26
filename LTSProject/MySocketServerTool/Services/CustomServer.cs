using MyToolkits.Log.TraceLog;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using System.Text;

namespace MySocketServerTool.Services
{
    /// <summary>
    /// 配置Server
    /// 服务启动
    /// 停止
    /// 新链接
    /// 新链接断开
    /// </summary>
    public class CustomServer : AppServer<CustomSession>
    {
        public CustomServer()
            //: base(new CommandLineReceiveFilterFactory(Encoding.Default, new BasicRequestInfoParser(":", ",")))
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
            TraceLog.WriteLine("Started...", logger : _logger);
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
        protected override void OnNewSessionConnected(CustomSession session)
        {
            //TraceLog.WriteLine("新的连接加入，标识：" + session.SessionID);
            TraceLog.WriteLine($"新链接: { session.RemoteEndPoint.Address.ToString()} { session.RemoteEndPoint.Port.ToString()}", logger: _logger);
            base.OnNewSessionConnected(session);
        }
        protected override void OnSessionClosed(CustomSession session, CloseReason reason)
        {
            TraceLog.WriteLine($"链接断开: { session.RemoteEndPoint.Address.ToString()} { session.RemoteEndPoint.Port.ToString()} , {reason.ToString()}", logger: _logger);
            base.OnSessionClosed(session, reason);
        }
        string _logger = "CustomServer";
    }
}
