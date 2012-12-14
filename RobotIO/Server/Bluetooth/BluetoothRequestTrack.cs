using RobotControl;
using RobotControl.Drive;

namespace RobotIO.Server.Bluetooth
{
  public class BluetoothRequestTrack : BluetoothBaseRequest<BluetoothCommandResponse>
  {
    public BluetoothRequestTrack() 
      : base(BluetoothCommandResponse.TrackReceived)
    {
    }

    protected override string DoProcess(string[] request)
    {
      Track track = TrackParser.Parse(request);
      World.Robot.Movement.AddTrack(track);
      return "Track processed as " + track;
    }
  }
}