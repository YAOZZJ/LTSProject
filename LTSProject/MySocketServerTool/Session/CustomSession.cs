using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System;

namespace MySocketServerTool.Session
{
    /// <summary>
    /// 节点相关操作;
    /// 节点启动
    /// 不明请求
    /// 节点断开
    /// </summary>
    public class CustomSession : AppSession<CustomSession, StringRequestInfo>
    {
        protected override void OnSessionStarted()
        {
            this.Send("welecome to custom socket");
        }

        protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
        {
            this.Send("UnknownRequest");
            //base.HandleUnknownRequest(requestInfo);
        }

        protected override void HandleException(Exception e)
        {
            this.Send("Application error: {0}", e.Message);
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
