using MySocketServerTool.RequestInfo;
using MySocketServerTool.Session;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace MySocketServerTool.Command
{
    public class FinsRWData : CommandBase<FinsSession, FinsTcpRequestInfo>
    {
        public override void ExecuteCommand(FinsSession session, FinsTcpRequestInfo requestInfo)
        {
            //session.Send($"Hello {session.RemoteEndPoint.Address} {session.RemoteEndPoint.Port} {requestInfo.Body}");
            //session.Send(requestInfo.Body, 0, requestInfo.Body.Length);
            session.Send(requestInfo.Data, 0, requestInfo.Data.Length);
        }
    }
}
