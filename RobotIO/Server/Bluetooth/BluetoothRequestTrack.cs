using RobotControl.Drive;

namespace RobotIO.Server.Bluetooth
{
  public class BluetoothRequestTrack : IRequestHandler
  {
    public string Process(string[] request)
    {
      Track track = TrackParser.Parse(request);
      return "Track processed as " + track;
    }
  }
}