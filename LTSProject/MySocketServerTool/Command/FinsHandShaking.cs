using MySocketServerTool.RequestInfo;
using MySocketServerTool.Session;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System.Collections.Generic;

namespace MySocketServerTool.Command
{
    public class FinsHandShaking : CommandBase<FinsSession, FinsTcpRequestInfo>
    {
        public override void ExecuteCommand(FinsSession session, FinsTcpRequestInfo requestInfo)
        {
            List<byte> _data = new List<byte>(requestInfo.Header);
            _data.AddRange(requestInfo.Command);
            _data.AddRange(requestInfo.Body);
            _data.Add(0);
            _data.Add(0);
            _data.Add(0);
            _data.Add(1);
            session.Send(_data.ToArray(), 0, _data.Count);
        }
    }
}
