using System;
using System.Drawing;
using System.Collections.Generic;

namespace RobotControl.Drive
{
  public class DriveImage
  {
    private const float SizeOffset = 10f;
    private readonly List<PositionInfo> _posList;
    private readonly SolidBrush _brushRobot;
    private readonly Pen _penAngle;
    private readonly Brush _brushRun;
    private readonly Pen _penRadar;
    private readonly object _locker;

    private float _xMin, _xMax;
    private float _yMin, _yMax;

    private int _width, _height;

    public DriveImage(Drive drive) {
      _posList = new List<PositionInfo>();
      _locker = new object();
      _penAngle = new Pen(Color.Black, 6);
      _penRadar = new Pen(Color.Green, 6);
      _brushRun = new SolidBrush(Color.Red);
      _brushRobot = new SolidBrush(Color.Gray);
      drive.OnPositionUpdated += DriveOnOnPositionUpdated;
    }

    private void DriveOnOnPositionUpdated(PositionInfo positionInfo) {
      lock (_locker)
      {
        _posList.Add(positionInfo);
      }
    }

    /// <summary>
    /// Berechnet aus einer x-Pos [m] im Weltkoordinatensystem 
    /// eine x-Pos [Pixel] im Koordinatensystem der WorldView
    /// </summary>
    /// <param name="x">die x-Position im Weltkoordinatensystem in Meter</param>
    /// <returns>die x-Position im WorldView-Koordinatensystem in Pixel</returns>
    private int XtoScreen(double x)
    {
      return WidthToScreen((float)(x - _xMin));
    }

    /// <summary>
    /// Berechnet aus einer y-Pos [m] im Weltkoordinatensystem 
    /// eine y-Pos [Pixel] im Koordinatensystem der WorldView
    /// </summary>
    /// <param name="y">die y-Position im Weltkoordinatensystem in Meter</param>
    /// <returns>die y-Position im WorldView-Koordinatensystem in Pixel</returns>
    private int YtoScreen(double y)
    {
      return _height - HeightToScreen((float)(y - _yMin));
    }

    /// <summary>
    /// Berechnet aus einer Distanz [m] in x-Richtung die Anzahl
    /// Pixel im Koordinatensystem der WorldView.
    /// </summary>
    /// <param name="width">die Distanz/Strecke in Metern</param>
    /// <returns>die Anzahl Pixel, die dieser Distanz/Strecke entsprechen</returns>
    private int WidthToScreen(float width)
    {
      double percentage = width / (_xMax - _xMin);
      return (int)(_width * percentage);
    }

    /// <summary>
    /// Berechnet aus einer Distanz [m] in y-Richtung die Anzahl
    /// Pixel im Koordinatensystem der WorldView.
    /// </summary>
    /// <param name="height">die Distanz/Strecke in Metern</param>
    /// <returns>die Anzahl Pixel, die dieser Distanz/Strecke entsprechen</returns>
    private int HeightToScreen(float height)
    {
      double percentage = height / (_yMax - _yMin);
      return (int)(_height * percentage);
    }

    public Bitmap GetImage()
    {
      return GetImage(500, 500);
    }

    public Bitmap GetImage(int width, int height) {
      _width = width;
      _height = height;
      Bitmap bitmap = new Bitmap(_width, _height);

      List<PositionInfo> tmpList;
      lock (_locker)
      {
        tmpList = new List<PositionInfo>(_posList);
      }
      int itemCount = tmpList.Count;
      if (itemCount > 0) {
        PositionInfo info = tmpList[0];
        _xMin = info.X; _xMax = info.X;
        _yMin = info.Y; _yMax = info.Y;
      } else {
        _xMin = 0; _xMax = 500;
        _yMin = 0; _yMax = 500;
      }

      for (int i = 1; i < itemCount; i++ ) {
        PositionInfo info = tmpList[1];
        if (info.X > _xMax) _xMax = info.X;
        else if (info.X < _xMin) _xMin = info.X;

        if (info.Y > _yMax) _yMax = info.Y;
        else if (info.Y < _yMin) _yMin = info.Y;
      }

      _xMax += SizeOffset; _xMin -= SizeOffset;
      _yMax += SizeOffset; _yMin -= SizeOffset;

      using (Graphics g = Graphics.FromImage(bitmap))
      {
        g.Clear(Color.White);

        Robot robot = World.Robot;
        if (robot != null)
        {
          #region Roboter zeichnen

          var pos = robot.Drive.Position;
          double phi = pos.Angle / 180 * Math.PI;

          // Draw Points
          for (int i = 0; i < itemCount; i++ ) {
            PositionInfo posInfo = tmpList[i];
            g.FillEllipse(_brushRun, XtoScreen(posInfo.X), YtoScreen(posInfo.Y), 5, 5);
          }

          // Roboter.Radar
          PositionInfo radarOffset = robot.Radar.AntennaPosition;
          PositionInfo radarPos = new PositionInfo(
            pos.X + radarOffset.X * (float)Math.Cos(phi) - radarOffset.Y * (float)Math.Sin(phi),
            pos.Y + radarOffset.X * (float)Math.Sin(phi) + radarOffset.Y * (float)Math.Cos(phi),
            (pos.Angle + radarOffset.Angle) % 360);
          double radarPhi = radarPos.Angle / 180.0 * Math.PI;
          double distance = robot.Radar.Distance;

          // Radarstrahl zeichnen...
          g.DrawLine(_penRadar, XtoScreen(radarPos.X), YtoScreen(radarPos.Y),
                     XtoScreen(radarPos.X + distance * Math.Cos(radarPhi)),
                     YtoScreen(radarPos.Y + distance * Math.Sin(radarPhi)));

          g.FillEllipse(_brushRobot, XtoScreen(pos.X - .07f), YtoScreen(pos.Y + .07f), WidthToScreen(.14f),
                        HeightToScreen(.14f));

          int xScreen = XtoScreen(pos.X);
          int yScreen = YtoScreen(pos.Y);
          g.DrawLine(_penAngle, xScreen, yScreen,
                     xScreen + WidthToScreen((float)(.07f * Math.Cos(phi))),
                     yScreen + HeightToScreen((float)(-.07f * Math.Sin(phi))));

          #endregion
        }
      }

      return bitmap;
    }

    public void Reset()
    {
      lock (_locker)
      {
        _posList.Clear();
      }
    }
  }
}
