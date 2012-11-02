//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: Radar.cs 643 2011-03-28 19:15:54Z zajost $
//------------------------------------------------------------------------------

using RobotIO;

namespace RobotControl.Radar
{
  public class Radar
  {
    private readonly RadarSensor _sensor;

    public Radar()
    {
      if (!Constants.IsWinCE)
      {
        _sensor = new RadarSensorSim();
      }
      else
      {
        _sensor = new RadarSensorHW(Constants.IORadarSensor);
      }
    }

    /// <summary>
    /// Liefert die gemessene Distanz zum nächsten Objekt [m]
    /// </summary>
    public float Distance
    {
      get { return _sensor.Distance; }
    }

    /// <summary>
    /// Liefert bzw. setzt die Position des Ultraschall Distanzsensors am Roboter
    /// </summary>
    public PositionInfo AntennaPosition { get; set; }
  }
}