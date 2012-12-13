using RobotControl;

namespace RobotIO.Server.Bluetooth
{
  public class BluetoothRequestImage : IRequestHandler
  {
    public string Process(string[] request)
    {
      return World.Robot.Movement.GetBase64Image();
    }
  }
}