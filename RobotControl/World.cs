//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: World.cs 757 2011-10-26 09:25:23Z zajost $
//------------------------------------------------------------------------------

namespace RobotControl
{
    /// <summary>
    /// Die Welt besteht aus einem Roboter und einer Hinderniskarte
    /// </summary>
    public class World
    {
        public static Robot Robot { get; set; }
        //public static ObstacleMap ObstacleMap { get; set; }


        //public static float GetFreeSpace()
        //{
        //    if (ObstacleMap != null)
        //    {
        //        PositionInfo offset = Robot.Radar.AntennaPosition;
        //        PositionInfo position = Robot.Position;

        //        float phi = position.Angle / 180.0f * (float)Math.PI;

        //        PositionInfo radarPos = new PositionInfo(
        //            position.X + offset.X * (float)Math.Cos(phi) - offset.Y * (float)Math.Sin(phi),
        //            position.Y + offset.X * (float)Math.Sin(phi) + offset.Y * (float)Math.Cos(phi),
        //            (position.Angle + offset.Angle) % 360);
        //        return (float)ObstacleMap.GetFreeSpace(radarPos);
        //    }
        //    else return 2.55f;
        //}
    }
}
