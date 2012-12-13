using System.Drawing.Imaging;
using System.IO;
using System.Net.Sockets;
using System.Text;
using RobotControl;

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
      //byte[] contentHTML = Encoding.UTF8.GetBytes(strings[1]);
      //Header
      //byte[] header = Encoding.ASCII.GetBytes(string.Format(strings[0], contentHTML.Length));
      //byte[] header = Encoding.ASCII.GetBytes(strings[0]);



      Writer.Write(string.Format(strings[0], strings[1].Length));
      Writer.Write(strings[1]);
      /*Writer.Write("<html><head></head><body><img src=\"data:image/bmp;,");
      using (MemoryStream ms = new MemoryStream())
      {
        World.Robot.Movement.Image.Save(ms, ImageFormat.Bmp);
        Writer.Write(Encoding.UTF8.GetString(ms.ToArray()));
      }
      Writer.Write("\"/></body></html>");*/

      //Writer.BaseStream.Write(contentHTML, 0, contentHTML.Length);
    }
  }
}