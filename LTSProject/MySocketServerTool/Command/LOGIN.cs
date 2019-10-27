using MySocketServerTool.Services;
using MySocketServerTool.Session;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace MySocketServerTool.Command
{
    public class LOGIN : CommandBase<CustomSession, StringRequestInfo>
    {
        public override void ExecuteCommand(CustomSession session, StringRequestInfo requestInfo)
        {
            //LOGIN:kerry,12345
            //: base(new CommandLineReceiveFilterFactory(Encoding.Default, new BasicRequestInfoParser(":", ",")))
            session.Send("Hello " + requestInfo.Parameters[0]);
        }
    }
}
