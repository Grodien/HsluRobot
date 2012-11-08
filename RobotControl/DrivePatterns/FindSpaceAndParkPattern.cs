using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RobotControl.DrivePatterns
{
  public class FindSpaceAndParkPattern : BasePattern
  {
    public FindSpaceAndParkPattern(float speed, float acceleration) :
      base(speed, acceleration)
    {
    }

    protected override void StartThread() {
      try {
        Robot robot = World.Robot;

        RunArcRight(0.4f, 45, false);
        RunLine(.7f, false);
        RunArcLeft(0.4f, 45, true);

        RunLine(robot.Radar.Distance - 0.3f, true);

        RunTurn(-90, true);

        if (robot.Radar.Distance > 0.35f) {
          while (true) {
            RunLine(0.5f, true);

            RunTurn(90, true);

            if (robot.Radar.Distance < 0.35f) {
              RunTurn(-90, true);
            } else {
              RunLine(robot.Radar.Distance - 0.3f, true);
              break;
            }
          }
        }
      } catch (RobotStoppedException ex) {
        
      }
    }
  }
}
