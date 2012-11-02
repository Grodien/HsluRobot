//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: RadarSensorHW.cs 489 2011-02-07 13:21:01Z chj-nb $
//------------------------------------------------------------------------------

using RobotIO;

namespace RobotControl.Radar
{
  public class RadarSensorHW : RadarSensor
  {
    private readonly int _ioAddress;

    public RadarSensorHW(int IOAddress)
    {
      _ioAddress = IOAddress;
    }

    public override float Distance
    {
      get { return IOPortEx.Read(_ioAddress)/100.0f; }
    }
  }
}