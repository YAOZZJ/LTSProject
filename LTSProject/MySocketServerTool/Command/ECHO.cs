using MySocketServerTool.Services;
using MyToolkits.Log.TraceLog;
using SuperSocket.Facility.Protocol;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Metadata;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Linq;

namespace MySocketServerTool.Command
{
    //[CustomCommandFilter]
    //public class ECHO : CommandBase<CustomSession, StringRequestInfo>
    //{
    //    public override void ExecuteCommand(CustomSession session, StringRequestInfo requestInfo)
    //    {
    //        session.Send(string.Format($"Hello {session.RemoteEndPoint.Address} {session.RemoteEndPoint.Port} {requestInfo.Body}"));
    //        session.Send(requestInfo.Key + requestInfo.Body);
    //    }
    //}
}
