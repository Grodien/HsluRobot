using RobotControl;
using RobotControl.Drive;

namespace RobotIO.Server.Bluetooth
{
  public class BluetoothRequestTrack : IRequestHandler
  {
    public string Process(string[] request)
    {
      Track track = TrackParser.Parse(request);
      World.Robot.Movement.AddTrack(track);
      return "Track processed as " + track;
    }
  }
}