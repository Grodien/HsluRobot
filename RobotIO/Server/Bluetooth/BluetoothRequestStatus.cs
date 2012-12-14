using RobotControl;

namespace RobotIO.Server.Bluetooth
{
  public class BluetoothRequestStatus : BluetoothBaseRequest<BluetoothCommandResponse>
  {
    public BluetoothRequestStatus()
      : base(BluetoothCommandResponse.Status)
    {
    }

    protected override string DoProcess(string[] request)
    {
      return World.Robot.Movement.ToString(false);
    }
  }
}