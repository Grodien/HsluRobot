using System;
using RobotIO;

namespace RobotControl.Drive
{
  public abstract class TrackArc : Track
  {
    protected readonly float _radius;
    protected readonly float _angle;
    protected float Ratio;

    protected TrackArc(float radius, float angle, float speed, float acceleration)
      : base(speed, acceleration) {
      _radius = radius;
      _angle = angle;
      Length = (float)((2*radius)* Math.PI * Math.Abs(angle) / 360f);
      Reverse = (Math.Sign(angle) ^ Math.Sign(speed)) != 0;

      float dphi = Length / radius;
      float rInner = radius - Constants.AxleLength;
      float dInner = rInner * dphi;

      Ratio = 1 / Length * dInner;
    }
  }
}