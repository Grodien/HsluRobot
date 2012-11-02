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

    protected void RunLine(float length, float speed, float acceleration, bool wait)
    {
      if (_stop) throw new RobotStoppedException();
      World.Robot.Drive.RunLine(length, speed, acceleration);
      if (wait) _resetEvent.WaitOne();
    }

    protected void RunTurn(float angle, float speed, float acceleration, bool wait)
    {
      if (_stop) throw new RobotStoppedException();
      World.Robot.Drive.RunTurn(angle, speed, acceleration);
      if (wait) _resetEvent.WaitOne();
    }

    protected void RunArcRight(float radius, float angle, float speed, float acceleration, bool wait)
    {
      if (_stop) throw new RobotStoppedException();
      World.Robot.Drive.RunArcRight(radius, angle, speed, acceleration);
      if (wait) _resetEvent.WaitOne();
    }

    /// <summary>
    /// Runs the arc left.
    /// </summary>
    /// <param name="radius">The radius.</param>
    /// <param name="angle">The angle.</param>
    /// <param name="speed">The speed.</param>
    /// <param name="acceleration">The acceleration.</param>
    /// <exception cref="RobotControl.DrivePatterns.RobotStoppedException"></exception>
    protected void RunArcLeft(float radius, float angle, float speed, float acceleration, bool wait)
    {
      if (_stop) throw new RobotStoppedException();
      World.Robot.Drive.RunArcLeft(radius, angle, speed, acceleration);
      if (wait) _resetEvent.WaitOne();
    }

    public virtual void Stop() {
      _stop = true;
      World.Robot.Drive.Stop();
      _resetEvent.Set();
      World.Robot.Drive.TrackFinished -= DriveTrackFinished;
    }
  }
}
