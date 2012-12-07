using System.Net.Sockets;

namespace RobotIO.Server.HTTP
{
  public class HttpClient : Client
  {
    public const string ReturnReport = "ReturnReport";

    private int _requestCount;

    public HttpClient(string ip, NetworkStream stream) 
      : base(ip, stream)
    {
    }

    public override string ReadRequest()
    {
      if (_requestCount > 0)
        return string.Empty;

      _requestCount++;
      return ReturnReport;
    }
  }
}