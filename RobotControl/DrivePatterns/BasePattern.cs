using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RobotControl.DrivePatterns
{
  public abstract class BasePattern
  {
    private volatile bool _stop = false;
    private readonly AutoResetEvent _resetEvent;

    public BasePattern() {
      _resetEvent = new AutoResetEvent(false);
      World.Robot.Drive.TrackFinished += DriveTrackFinished;
    }

    void DriveTrackFinished(object sender, EventArgs e) {
      _resetEvent.Set();
    }

    public virtual void Start() {
      
    }

    protected void RunLine(float length, float speed, float acceleration) {
      if (_stop) throw new RobotStoppedException();
      World.Robot.Drive.RunLine(length, speed, acceleration);
      _resetEvent.WaitOne();
    }

    protected void RunTurn(float angle, float speed, float acceleration)
    {
      if (_stop) throw new RobotStoppedException();
      World.Robot.Drive.RunTurn(angle, speed, acceleration);
      _resetEvent.WaitOne();
    }

    protected void RunArcRight(float radius, float angle, float speed, float acceleration)
    {
      if (_stop) throw new RobotStoppedException();
      World.Robot.Drive.RunArcRight(radius, angle, speed, acceleration);
      _resetEvent.WaitOne();
    }

    protected void RunArcLeft(float radius, float angle, float speed, float acceleration)
    {
      if (_stop) throw new RobotStoppedException();
      World.Robot.Drive.RunArcLeft(radius, angle, speed, acceleration);
      _resetEvent.WaitOne();
    }

    public virtual void Stop() {
      _stop = true;
      World.Robot.Drive.Stop();
      _resetEvent.Set();
      World.Robot.Drive.TrackFinished -= DriveTrackFinished;
    }
  }
}
