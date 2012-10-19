using RobotIO;
using System;

namespace RobotControl.Drive
{
  public class TrackTurn : Track
  {
    public TrackTurn(float angle, float speed, float acceleration)
      : base(speed, acceleration)
    {
      Length = (float)(Constants.AxleLength * Math.PI * (Math.Abs(angle) * (Math.PI / 180f)));
      Reverse = angle > 0;
    }

    protected override void OnIncrementalStep(float timeInterval, float newVelocity, out float leftSpeed, out float rightSpeed)
    {
      if (Reverse)
      {
        leftSpeed = -newVelocity;
        rightSpeed = newVelocity;
      }
      else
      {
        leftSpeed = newVelocity;
        rightSpeed = -newVelocity;
      }
    }
  }
}