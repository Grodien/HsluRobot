using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RobotControl.DrivePatterns
{
  public class FindSpaceAndPark : BasePattern
  {
    protected override void StartThread() {
      try {
        Robot robot = World.Robot;

        RunArcRight(0.4f, 45, 1, 1, false);
        RunLine(.7f, 1, 1, false);
        RunArcLeft(0.4f, 45, 1, 1, true);

        RunLine(robot.Radar.Distance - 0.3f, 1, 1, true);

        RunTurn(-90, 1, 1, true);

        if (robot.Radar.Distance > 0.35f) {
          while (true) {
            RunLine(0.5f, 1, 1, true);

            RunTurn(90, 1, 1, true);

            if (robot.Radar.Distance < 0.35f) {
              RunTurn(-90, 1, 1, true);
            } else {
              RunLine(robot.Radar.Distance - 0.3f, 1, 1, true);
              break;
            }
          }
        }
      } catch (RobotStoppedException ex) {
        
      }
    }
  }
}
