using RobotControl;

namespace RobotIO.Server.Bluetooth
{
  public class BluetoothRequestStatus : IRequestHandler
  {
    public string Process(string[] request)
    {
      return World.Robot.Movement.ToString(false);
    }
  }
}