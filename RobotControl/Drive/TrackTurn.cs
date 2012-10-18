namespace RobotControl.Drive
{
  public class TrackTurn : Track
  {
    public TrackTurn(float angle, float speed, float acceleration)
      : base(speed, acceleration)
    {
      Length = 1;
      Reverse = angle > 0;
    }

    protected override void OnIncrementalStep(float timeInterval, float newVelocity, out float leftSpeed, out float rightSpeed)
    {
      if (Reverse)
      {
        leftSpeed = newVelocity * -1;
        rightSpeed = newVelocity;
      }
      else
      {
        leftSpeed = newVelocity;
        rightSpeed = newVelocity * -1;
      }
    }
  }
}