namespace RobotControl.Drive
{
  public class TrackArcRight : TrackArc
  {
    public TrackArcRight(float radius, float angle, float speed, float acceleration) 
      : base(radius, angle, speed, acceleration)
    {
    }

    protected override void OnIncrementalStep(float timeInterval, float newVelocity, out float leftSpeed, out float rightSpeed)
    {
      throw new System.NotImplementedException();
    }
  }
}