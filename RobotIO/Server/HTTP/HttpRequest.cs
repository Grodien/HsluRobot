using System.Text;
using RobotControl;
using RobotControl.Drive;

namespace RobotIO.Server.HTTP
{
  public class HttpRequest : IRequestHandler
  {
    public string Process(string[] request)
    {
      Movement movement = World.Robot.Movement;
      StringBuilder builder = new StringBuilder();
      builder.AppendLine();
      builder.Append("---------- Status Report Fahrweg ---------\r\n");
      builder.AppendFormat("Movement active: {0}\r\n", movement.Running);
      builder.AppendFormat("Movement finished: {0}\r\n", movement.Finished);
      var tracks = movement.Tracks;
      //builder.AppendFormat("Movement done {0}m of {1}m\n", World.Robot.Drive);
      builder.AppendFormat("# Tracks: {0} tracks.\r\n", tracks.Count);
      int i = 0;
      foreach (var track in tracks)
      {
        builder.AppendFormat("Track {0}: Finished {1} - Detail <{2}>\r\n", ++i, track.Value, track.Key);
      }
      if (tracks.Count > 0)
        builder.AppendLine();

      return builder.ToString();
    }
  }
}