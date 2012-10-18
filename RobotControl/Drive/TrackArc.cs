namespace RobotControl.Drive
{
  public abstract class TrackArc : Track
  {
    protected TrackArc(float radius, float angle, float speed, float acceleration)
      : base(speed, acceleration)
    {
      
    }
  }
}