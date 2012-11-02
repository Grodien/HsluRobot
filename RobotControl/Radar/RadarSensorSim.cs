﻿//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: RadarSensorSim.cs 643 2011-03-28 19:15:54Z zajost $
//------------------------------------------------------------------------------

namespace RobotControl.Radar
{
  public class RadarSensorSim : RadarSensor
  {
    public override float Distance
    {
      get { return World.GetFreeSpace(); }
    }
  }
}