using SuperSocket.SocketBase;

namespace MyToolkits.Socket.SuperSocketServer
{
    /// <summary>
    /// 代表一个和客户端的逻辑连接，基于连接的操作应该定于在该类之中。
    /// 你可以用该类的实例发送数据到客户端，接收客户端发送的数据或者关闭连接。
    /// </summary>
    public class MySession : AppSession<MySession, MyRequestInfo>
    {
        //protected override void OnSessionStarted()
        //{
        //    base.OnSessionStarted();
        //    TraceLog.Output(this.LocalEndPoint.Address.ToString());
        //}
    }
}
