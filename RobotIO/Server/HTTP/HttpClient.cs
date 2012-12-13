using System.Net.Sockets;
using System.Text;

namespace RobotIO.Server.HTTP
{
  public class HttpClient : Client
  {
    public const string ReturnReport = "ReturnReport";
    public const char HeaderSplit = '¿';

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

    public override void SendResponse(string response)
    {
      string[] strings = response.Split(HeaderSplit);
      //HTML
      byte[] contentHtml = Encoding.UTF8.GetBytes(strings[1]);
      //Header
      byte[] header = Encoding.ASCII.GetBytes(string.Format(strings[0], contentHtml.Length));

      Writer.BaseStream.Write(header, 0, header.Length);
      Writer.BaseStream.Write(contentHtml, 0, contentHtml.Length);
    }
  }
}