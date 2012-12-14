using RobotControl;

namespace RobotIO.Server.Bluetooth
{
  public class BluetoothRequestStart : BluetoothBaseRequest<BluetoothCommandResponse>
  {
    public BluetoothRequestStart()
      : base(BluetoothCommandResponse.Started)
    {
    }

    protected override string DoProcess(string[] request)
    {
      World.Robot.Movement.StartMovement();
      return "Process Start";
    }
  }
}