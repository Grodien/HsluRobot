using System.Text;
using RobotControl;

namespace RobotIO.Server.Bluetooth
{
  public class BluetoothRequestImage : BluetoothBaseRequest<BluetoothCommandResponse>
  {
    public BluetoothRequestImage() 
      : base(BluetoothCommandResponse.AllPositions)
    {
    }

    protected override string DoProcess(string[] request)
    {
      StringBuilder stringBuilder = new StringBuilder();

      //All Position Infos
      var posInfos = World.Robot.Movement.GetAllPositionInfos();
      foreach (var positionInfo in posInfos)
      {
        stringBuilder.Append(positionInfo.X).Append('¿')
                     .Append(positionInfo.Y).Append('¿');
      }
      //Angle for last position
      stringBuilder.Append(posInfos[posInfos.Count-1].Angle).Append('¿');

      //Antenna Position offset
      var antennaPosition = World.Robot.Radar.AntennaPosition;
      stringBuilder.Append(antennaPosition.X).Append('¿')
                   .Append(antennaPosition.Y).Append('¿');

      //Current distance
      stringBuilder.Append(World.Robot.Radar.Distance);
      return stringBuilder.ToString();
    }
  }
}