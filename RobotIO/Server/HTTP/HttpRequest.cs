using System.Text;
using RobotControl;

namespace RobotIO.Server.HTTP
{
  public class HttpRequest : IRequestHandler
  {
    public string Process(string[] request)
    {
      string movement = World.Robot.Movement.ToString(true);

      StringBuilder builder = new StringBuilder();
      builder.AppendLine("HTTP/1.0 200 OK");
      builder.AppendLine("Server: ProgSY_Bollhalder_Bomatter 1.0");
      builder.AppendLine("Content-Type: text/html");
      //builder.AppendLine("Content-Type: image/bmp");
      builder.AppendLine("Content-Length: {0}");
      builder.AppendLine();
      builder.Append(HttpClient.HeaderSplit);
      builder.Append("<html><head></head><body><img src=\"data:image/bmp;base64,");
      builder.Append(movement);
      builder.Append("\"/></body></html>");

      return builder.ToString();
    }
  }
}