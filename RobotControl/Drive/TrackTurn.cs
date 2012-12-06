using System.Globalization;
using RobotIO;
using System;

namespace RobotControl.Drive
{
  public class TrackTurn : Track
  {
    private readonly float _angle;

    public TrackTurn(float angle, float speed, float acceleration)
      : base(speed, acceleration)
    {
      _angle = angle;
      Length = (float)(Constants.AxleLength * Math.PI  * Math.Abs(angle) / 360);
      Reverse = angle < 0;
    }

    protected override void OnIncrementalStep(float timeInterval, float newVelocity, out float leftSpeed, out float rightSpeed)
    {
      if (Reverse)
      {
        leftSpeed = newVelocity;
        rightSpeed = newVelocity;
      }
      else
      {
        leftSpeed = -newVelocity;
        rightSpeed = -newVelocity;
      }
    }

    public override string ToStringData() {
      return "TrackTurn " + _angle;
    }
  }
}