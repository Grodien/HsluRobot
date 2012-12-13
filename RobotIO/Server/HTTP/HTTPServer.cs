using System.Threading;
using System.Net.Sockets;

namespace RobotIO.Server.HTTP
{
  public class HttpServer : AbstractServer
  {
    private readonly int _port;
    private TcpListener _tcpListener;

    public HttpServer(int port)
      : base("HTTP Server")
    {
      _port = port;
    }

    protected override void AddRequestHandlers()
    {
      RequestDict.Add(HttpClient.ReturnReport, new HttpRequest());
    }

    protected override void StartListener()
    {
      _tcpListener = new TcpListener(_port);
      _tcpListener.Start();
      Log("{0}: Started on {1}", Identifier, _tcpListener.LocalEndpoint.ToString());
      while (!Stopped)
      {
        TcpClient client = _tcpListener.AcceptTcpClient();
        ProcessClientSync(client.Client.RemoteEndPoint.ToString(), client.GetStream(), () => FinishCallbackAsync(client));
      }
    }

    private void FinishCallbackAsync(TcpClient client)
    {
      ThreadPool.QueueUserWorkItem(FinishCallback, client);
    }

    private void FinishCallback(object state)
    {
      Thread.Sleep(10000);
      ((TcpClient) state).Close();
    }

    protected override void OnStop()
    {
      base.OnStop();
      _tcpListener.Stop();
    }

    protected override Client CreateClient(string ip, NetworkStream networkStream)
    {
      return new HttpClient(ip, networkStream);
    }
  }
}