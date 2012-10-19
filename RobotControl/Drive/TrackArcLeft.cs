using RobotIO;

namespace RobotControl.Drive
{
  public class TrackArcLeft : TrackArc
  {
    public TrackArcLeft(float radius, float angle, float speed, float acceleration) 
      : base(radius, angle, speed, acceleration) {}


    protected override void OnIncrementalStep(float timeInterval, float newVelocity, out float leftSpeed, out float rightSpeed) {     
      if (Reverse) {
        rightSpeed = -newVelocity;
        leftSpeed = newVelocity * Ratio;
      } else {
        rightSpeed = newVelocity;
        leftSpeed = -(newVelocity * Ratio);
      }
    }
  }
}