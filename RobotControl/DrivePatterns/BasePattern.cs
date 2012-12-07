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

    public event EventHandler PatternFinished;

    protected BasePattern(float speed, float acceleration)
    {
      _speed = speed;
      _acceleration = acceleration;
      _resetEvent = new AutoResetEvent(false);
      World.Robot.Drive.TracksFinished += DriveTracksFinished;
    }

    protected void OnPatternFinished()
    {
      EventHandler handler = PatternFinished;
      if (handler != null) 
        handler(this, EventArgs.Empty);
    }

    private void DriveTracksFinished(object sender, EventArgs e) {
      _resetEvent.Set();
    }

    public void Start() {
      ThreadPool.QueueUserWorkItem(obj => StartPattern());
    }

    private void StartPattern()
    {
      StartThread();
      OnPatternFinished();
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

    public void Restart()
    {
      World.Robot.Drive.Restart();
    }

    public void Halt()
    {
      World.Robot.Drive.Halt();
    }

    public virtual void Stop() {
      _stop = true;
      World.Robot.Drive.Stop();
      _resetEvent.Set();
      World.Robot.Drive.TracksFinished -= DriveTracksFinished;
    }
  }
}
