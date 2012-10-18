using System;

namespace RobotControl
{
  public class Robot : IDisposable
  {
    private bool _isDisposed;

    /// <summary>
    /// Gets the drive.
    /// </summary>
    /// <value>
    /// The drive.
    /// </value>
    public Drive.Drive Drive { get; private set; }

    /// <summary>
    /// Gets the robot console.
    /// </summary>
    /// <value>
    /// The robot console.
    /// </value>
    public RobotConsole RobotConsole { get; private set; }

    public Robot()
    {
      Drive = new Drive.Drive();
      RobotConsole = new RobotConsole();

    }

    public void Dispose()
    {
      if (_isDisposed == false)
      {
        Dispose(true);
      }
      _isDisposed = true;
    }

    private void Dispose(bool disposing)
    {
      if (_isDisposed == false)
      {
        if (disposing)
        {
          Drive.Dispose();
          RobotConsole.Dispose();
        }
      }
    }
  }
}