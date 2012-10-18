using System;

namespace RobotControl.Drive
{
  public class TrackLine : Track
  {
    public TrackLine(float length, float speed, float acceleration)
      : base(speed, acceleration)
    {
      Length = length;
      Reverse = (Math.Sign(length) ^ Math.Sign(speed)) != 0;
    }

    protected override void OnIncrementalStep(float timeInterval, float newVelocity, out float leftSpeed, out float rightSpeed)
    {
      leftSpeed = newVelocity;
      rightSpeed = newVelocity;
    }
  }
}