using System;
using System.Drawing;
using RobotControl.Drive;

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

    /// <summary>
    /// Gets or sets the color.
    /// </summary>
    /// <value>
    /// The color.
    /// </value>
    public Color Color { get; set; }

    /// <summary>
    /// Gets or sets the radar.
    /// </summary>
    /// <value>
    /// The radar.
    /// </value>
    public Radar.Radar Radar { get; private set; }

    public PositionInfo Position
    {
      get { return Drive.Position; }
    }

    public Movement Movement { get; private set; }

    public Robot()
    {
      World.Robot = this;
      Drive = new Drive.Drive();
      RobotConsole = new RobotConsole();
      Radar = new Radar.Radar();
      Movement = new Movement();
      Color = Color.Red;
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