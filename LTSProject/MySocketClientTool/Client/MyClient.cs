using MySocketClientTool.PackageInfo;
using MySocketClientTool.ReceiveFilter;
using MyToolkits.Log.TraceLog;
using SuperSocket.ClientEngine;
using System;
using System.Net;
using System.Reflection;

namespace MySocketClientTool.Client
{
    public class MyClient
    {
        public MyClient()
        {
            client = new EasyClient<MyPackageInfo>();
            client.Initialize(new MyReceiveFilter());
            client.Closed += Client_Closed;
            client.Error += Client_Error;
            client.Connected += Client_Connected;
            client.NewPackageReceived += Client_NewPackageReceived;
        }
        public void Connect()
        {
            client.ConnectAsync(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port));
        }
        public void Close()
        {
            client.Close();
        }
        public void Send()
        {

        }
        private void Client_NewPackageReceived(object sender, PackageEventArgs<MyPackageInfo> e)
        {
            TraceLog.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        private void Client_Connected(object sender, EventArgs e)
        {
            TraceLog.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        private void Client_Error(object sender, ErrorEventArgs e)
        {
            TraceLog.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        private void Client_Closed(object sender, EventArgs e)
        {
            TraceLog.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        EasyClient<MyPackageInfo> client;
        int port = 2333;
    }
}
