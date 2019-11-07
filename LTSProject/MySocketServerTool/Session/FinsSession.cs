using MySocketServerTool.RequestInfo;
using SuperSocket.SocketBase;
using System;

namespace MySocketServerTool.Session
{
    public class FinsSession : AppSession<FinsSession, FinsTcpRequestInfo>
    {
        protected override void OnSessionStarted()
        {
            //this.Send("welecome to custom socket");
        }

        protected override void HandleUnknownRequest(FinsTcpRequestInfo requestInfo)
        {
            this.Send("UnknownRequest");
            //base.HandleUnknownRequest(requestInfo);
        }

        protected override void HandleException(Exception e)
        {
            //this.Send("Application error: {0}", e.Message);
            base.HandleException(e);
        }

        protected override void OnSessionClosed(CloseReason reason)
        {
            //添加业务逻辑，这些逻辑将在回话结束后执行
            base.OnSessionClosed(reason);
            //TraceLog.WriteLine(reason.ToString());
        }
    }
}
