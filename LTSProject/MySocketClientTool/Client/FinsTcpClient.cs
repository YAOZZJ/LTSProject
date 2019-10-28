using MySocketClientTool.PackageInfo;
using MySocketClientTool.ReceiveFilter;
using MyToolkits.Log.TraceLog;
using MyToolkits.Unitities.Conversion;
using SuperSocket.ClientEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MySocketClientTool.Client
{
    public class FinsTcpClient
    {
        public FinsTcpClient()
        {
            client = new EasyClient<FinsTcpPackageInfo>();
            client.Initialize(new FinsTcpReceiveFilter());
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
        private void Client_NewPackageReceived(object sender, PackageEventArgs<FinsTcpPackageInfo> e)
        {
            //TraceLog.WriteLine(MethodBase.GetCurrentMethod().Name);
                TraceLog.WriteLine(Conversion.Byte2HexString(e.Package.Data));
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
        EasyClient<FinsTcpPackageInfo> client;
        int port = 9600;
    }
    
}
