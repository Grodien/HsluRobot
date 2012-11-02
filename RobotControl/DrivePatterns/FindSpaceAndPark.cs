using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RobotControl.DrivePatterns
{
  public class FindSpaceAndPark : BasePattern
  {
    public FindSpaceAndPark() : base() {
    }

    public override void Start() {
      new Thread(StartThread).Start();
    }   

    private void StartThread() {
      try {
        Robot robot = World.Robot;

        RunArcRight(0.5f, 90, 1, 1, true);
        RunArcLeft(0.5f, 90, 1, 1, true);

        /*while (robot.Radar.Distance < 2.5f) {
          RunTurn(10,1,1);
        }

        RunLine(1.25f, 1, 1);

        RunTurn(-(90 - robot.Position.Angle), 1, 1);*/

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
