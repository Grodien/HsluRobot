using RobotControl;

namespace RobotIO.Server.Bluetooth
{
  public class BluetoothRequestStart : IRequestHandler
  {
    public string Process(string[] request)
    {
      World.Robot.Movement.StartMovement();
      return "Process Start";
    }
  }
}