using MyToolkits.Log.TraceLog;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.SocketEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySocketServerTool.Services
{
    public class MyBootstrap
    {
        public MyBootstrap()
        {
            _bootstrap = BootstrapFactory.CreateBootstrap();
            _bootstrap.Initialize();
            _bootstrap.Start();
            //if (_bootstrap.Initialize()) TraceLog.WriteLine("Initialize");
            //else { TraceLog.WriteLine("Initialize failed"); return; }
            //var result = _bootstrap.Start();
            //TraceLog.WriteLine("Start " + result.ToString());
        }
        IBootstrap _bootstrap;
    }
}