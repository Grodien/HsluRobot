using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RobotControl.DrivePatterns
{
  public abstract class BasePattern
  {
    private readonly float _speed;
    private readonly float _acceleration;
    private volatile bool _stop = false;
    private readonly AutoResetEvent _resetEvent;

    protected BasePattern(float speed, float acceleration)
    {
      _speed = speed;
      _acceleration = acceleration;
      _resetEvent = new AutoResetEvent(false);
      World.Robot.Drive.TrackFinished += DriveTrackFinished;
    }

    void DriveTrackFinished(object sender, EventArgs e) {
      _resetEvent.Set();
    }

    public void Start() {
      new Thread(StartThread).Start();
    }

    protected abstract void StartThread();

    protected void RunLine(float length, bool wait)
    {
      if (_stop) throw new RobotStoppedException();
      World.Robot.Drive.RunLine(length, _speed, _acceleration);
      if (wait) _resetEvent.WaitOne();
    }

    protected void RunTurn(float angle, bool wait)
    {
      if (_stop) throw new RobotStoppedException();
      World.Robot.Drive.RunTurn(angle, _speed, _acceleration);
      if (wait) _resetEvent.WaitOne();
    }

    protected void RunArcRight(float radius, float angle, bool wait)
    {
      if (_stop) throw new RobotStoppedException();
      World.Robot.Drive.RunArcRight(radius, angle, _speed, _acceleration);
      if (wait) _resetEvent.WaitOne();
    }

    /// <summary>
    /// Runs the arc left.
    /// </summary>
    /// <param name="radius">The radius.</param>
    /// <param name="angle">The angle.</param>
    /// <param name="wait"> </param>
    /// <exception cref="RobotControl.DrivePatterns.RobotStoppedException"></exception>
    protected void RunArcLeft(float radius, float angle, bool wait)
    {
      if (_stop) throw new RobotStoppedException();
      World.Robot.Drive.RunArcLeft(radius, angle, _speed, _acceleration);
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
