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

        while (robot.Radar.Distance > 2.5f) {
          RunLine(0.5f, 1, 1);
        }
        
        while (robot.Radar.Distance < 2.5f) {
          RunTurn(10,1,1);
        }

        RunLine(2.5f, 1, 1);

        RunTurn(-(90 - robot.Position.Angle), 1, 1);

        RunLine(robot.Radar.Distance - 0.4f, 1, 1);

        RunTurn(-90, 1, 1);

        if (robot.Radar.Distance > 0.45f) {
          while (true) {
            RunLine(1, 1, 1);

            RunTurn(90, 1, 1);

            if (robot.Radar.Distance < 0.45f) {
              RunTurn(-90, 1, 1);
            } else {
              RunLine(robot.Radar.Distance- 0.4f, 1, 1);
              break;
            }
          }
        }
      } catch (RobotStoppedException ex) {
        
      }
    }
  }
}
