﻿using MySocketServerTool.RequestInfo;
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
            //session.Send($"Hello {session.RemoteEndPoint.Address} {session.RemoteEndPoint.Port} {requestInfo.Body}");
            //session.Send(requestInfo.Body, 0, requestInfo.Body.Length);
            byte[] _header = requestInfo.Header;
            List<byte> _body = new List<byte>(requestInfo.Body);
            _body.Add(0x00);
            _body.Add(0x00);
            _body.Add(0x00);
            _body.Add(0x01);
            _header[7] = (byte)_body.Count;//待优化,command不会超过255,不会溢出
            session.Send(requestInfo.Body, 0, requestInfo.Body.Length);
        }
    }
}
