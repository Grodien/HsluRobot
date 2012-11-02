//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: RadarSensor.cs 489 2011-02-07 13:21:01Z chj-nb $
//------------------------------------------------------------------------------

namespace RobotControl.Radar
{
  public abstract class RadarSensor
  {
    /// <summary>
    /// Liefert die gemessene Distanz zu einem Objekt in [m]
    /// </summary>
    public abstract float Distance { get; }
  }
}