using MySocketServerTool.Services;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace MySocketServerTool.Command
{
    //[CustomCommandFilter]
    public class ECHO : CommandBase<CustomSession, StringRequestInfo>
    {
        public override void ExecuteCommand(CustomSession session, StringRequestInfo requestInfo)
        {

            session.Send(string.Format($"Hello {session.RemoteEndPoint.Address} {session.RemoteEndPoint.Port} {requestInfo.Body}"));
            session.Send(requestInfo.Key + requestInfo.Body);
        }
    }
}
