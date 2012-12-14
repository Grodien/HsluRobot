using System;
using System.Drawing;
using System.Collections.Generic;
using System.Globalization;

namespace RobotControl.Drive
{
  public class DriveImageCreator
  {
    private const float SizeOffset = 0.5f;
    private readonly Font _font;
    private readonly Brush _fontBrush;
    private readonly Pen _penGrid2;
    private readonly SolidBrush _brushRobot;
    private readonly Pen _penAngle;
    private readonly Brush _brushRun;
    private readonly Pen _penGrid1;
    private readonly Pen _penRadar;

    public DriveImageCreator() {
      _penGrid1 = new Pen(Color.Gray, 3);
      _penGrid2 = new Pen(Color.Gray, 1);
      _penAngle = new Pen(Color.Black, 2);
      _penRadar = new Pen(Color.Green, 2);
      _brushRun = new SolidBrush(Color.Red);
      _font = new Font(FontFamily.GenericSerif, 8, FontStyle.Regular);
      _fontBrush = new SolidBrush(Color.Black);
      _brushRobot = new SolidBrush(Color.Red);
    }

    /// <summary>
    /// Berechnet aus einer x-Pos [m] im Weltkoordinatensystem 
    /// eine x-Pos [Pixel] im Koordinatensystem der WorldView
    /// </summary>
    /// <param name="x">die x-Position im Weltkoordinatensystem in Meter</param>
    /// <returns>die x-Position im WorldView-Koordinatensystem in Pixel</returns>
    private int XtoScreen(int maxWidth, float xMin, float xMax, double x)
    {
      return WidthToScreen(maxWidth, xMin, xMax, (float)(x - xMin));
    }

    /// <summary>
    /// Berechnet aus einer y-Pos [m] im Weltkoordinatensystem 
    /// eine y-Pos [Pixel] im Koordinatensystem der WorldView
    /// </summary>
    /// <param name="y">die y-Position im Weltkoordinatensystem in Meter</param>
    /// <returns>die y-Position im WorldView-Koordinatensystem in Pixel</returns>
    private int YtoScreen(int maxHeight, float yMin, float yMax, double y)
    {
      return maxHeight - HeightToScreen(maxHeight, yMin, yMax, (float)(y - yMin));
    }

    /// <summary>
    /// Berechnet aus einer Distanz [m] in x-Richtung die Anzahl
    /// Pixel im Koordinatensystem der WorldView.
    /// </summary>
    /// <param name="width">die Distanz/Strecke in Metern</param>
    /// <returns>die Anzahl Pixel, die dieser Distanz/Strecke entsprechen</returns>
    private int WidthToScreen(int maxWidth, float xMin, float xMax, float width)
    {
      double percentage = width / (xMax - xMin);
      return (int)(maxWidth * percentage);
    }

    /// <summary>
    /// Berechnet aus einer Distanz [m] in y-Richtung die Anzahl
    /// Pixel im Koordinatensystem der WorldView.
    /// </summary>
    /// <param name="height">die Distanz/Strecke in Metern</param>
    /// <returns>die Anzahl Pixel, die dieser Distanz/Strecke entsprechen</returns>
    private int HeightToScreen(int maxHeight, float yMin, float yMax, float height)
    {
      double percentage = height / (yMax - yMin);
      return (int)(maxHeight * percentage);
    }

    public void DrawImage(Bitmap bitmap, IList<PositionInfo> tmpList, PositionInfo antennaPosition, float distance)
    {
      float[] bounderies = CalculateMinMaxXY(tmpList);
      DrawImage(bitmap, tmpList, antennaPosition, distance, bounderies[0], bounderies[1], bounderies[2], bounderies[3]);
    }

    public void DrawImage(Bitmap bitmap, string positions)
    {
      string[] splittedPositions = positions.Split('¿');
      PositionInfo antennaPosition;
      float distance;
      List<PositionInfo> positionList = ConvertToPositionList(splittedPositions, out antennaPosition, out distance);
      float[] bounderies = CalculateMinMaxXY(positionList);
      DrawImage(bitmap, positionList, antennaPosition, distance, bounderies[0], bounderies[1], bounderies[2], bounderies[3]);
    }

    private void ClearImage(Graphics g)
    {
      g.Clear(Color.White);
    }

    private List<PositionInfo> ConvertToPositionList(string[] positions, out PositionInfo antennaPosition, out float distance)
    {
      List<PositionInfo> positionList = new List<PositionInfo>();
      for (int i = 0; i < positions.Length-4; i += 2)
      {
        PositionInfo info = new PositionInfo(float.Parse(positions[i]), float.Parse(positions[i+1]), 0);
        positionList.Add(info);
      }

      PositionInfo lastPos = positionList[positionList.Count - 1];
      positionList[positionList.Count - 1] = new PositionInfo(lastPos.X, lastPos.Y, float.Parse(positions[positions.Length - 4]));
      antennaPosition = new PositionInfo(float.Parse(positions[positions.Length-3]), float.Parse(positions[positions.Length-2]),0);
      distance = float.Parse(positions[positions.Length - 1]);

      return positionList;
    }

    private float[] CalculateMinMaxXY(IList<PositionInfo> tmpList)
    {
      float xMin, xMax, yMin, yMax = 0f;
      int itemCount = tmpList.Count;
      if (itemCount > 0)
      {
        PositionInfo info = tmpList[0];
        xMin = info.X; xMax = info.X;
        yMin = info.Y; yMax = info.Y;
      }
      else
      {
        xMin = 0; xMax = 0;
        yMin = 0; yMax = 0;
      }

      for (int i = 1; i < itemCount; i++)
      {
        PositionInfo info = tmpList[i];
        if (info.X > xMax)
        {
          xMax = info.X;
        }
        else if (info.X < xMin)
        {
          xMin = info.X;
        }

        if (info.Y > yMax)
        {
          yMax = info.Y;
        }
        else if (info.Y < yMin)
        {
          yMin = info.Y;
        }
      }

      float xDiff = Math.Abs(xMin) + Math.Abs(xMax);
      float yDiff = Math.Abs(yMin) + Math.Abs(yMax);
      float xyDiff = xDiff - yDiff;
      if (xyDiff < 0) {
        xMin -= Math.Abs(xyDiff/2);
        xMax -= Math.Abs(xyDiff / 2);
      } else {
        yMin -= Math.Abs(xyDiff / 2);
        yMax -= Math.Abs(xyDiff / 2);
      }

      xMax += SizeOffset; xMin -= SizeOffset;
      yMax += SizeOffset; yMin -= SizeOffset;

      return new[] {xMin, xMax, yMin, yMax};
    }

    private void DrawImage(Bitmap bitmap, IList<PositionInfo> posInfos , PositionInfo antennaPosition, float distance, float xMin, float xMax, float yMin, float yMax) {
      int width = bitmap.Width;
      int height = bitmap.Height;

      using (Graphics g = Graphics.FromImage(bitmap))
      {
        ClearImage(g);

        // Vertikale Linien die >viewPort.xMin bzw. <viewPort.xMax sind zeichnen...
        double y = yMin - (yMin % 0.5);
        for (; y < yMax; y += .5d)
        {
          int yScreen = YtoScreen(height, yMin, yMax, y);
          g.DrawLine((y == 0d ? _penGrid1 : _penGrid2), 0, yScreen, width, yScreen);
          g.DrawString(y.ToString(CultureInfo.InvariantCulture), _font, _fontBrush, 5, yScreen + 3);
        }

        // Horizontale Linien >viewPort.yMin bzw. <viewPort.yMax sind zeichnen...
        double x = xMax - (xMax % 0.5);
        for (; x > xMin; x -= .5d)
        {
          int xScreen = XtoScreen(width, xMin, xMax, x);
          g.DrawLine((x == 0d ? _penGrid1 : _penGrid2), xScreen, 0, xScreen, height);
          g.DrawString(x.ToString(CultureInfo.InvariantCulture), _font, _fontBrush, xScreen + 3, 5);
        }

        // Draw Points
        foreach (var positionInfo in posInfos) {
          g.FillEllipse(_brushRun, XtoScreen(bitmap.Width, xMin, xMax, positionInfo.X),
                               YtoScreen(bitmap.Height, yMin, yMax, positionInfo.Y),
                    5, 5);
        }

        #region Roboter zeichnen

        PositionInfo lastPosInfo = posInfos[posInfos.Count - 1];
        double phi = lastPosInfo.Angle / 180 * Math.PI;

        // Roboter.Radar
        PositionInfo radarPos = new PositionInfo(
          lastPosInfo.X + antennaPosition.X * (float)Math.Cos(phi) - antennaPosition.Y * (float)Math.Sin(phi),
          lastPosInfo.Y + antennaPosition.X * (float)Math.Sin(phi) + antennaPosition.Y * (float)Math.Cos(phi),
          (lastPosInfo.Angle + antennaPosition.Angle) % 360);
        double radarPhi = radarPos.Angle / 180.0 * Math.PI;

        // Radarstrahl zeichnen...
        g.DrawLine(_penRadar, XtoScreen(width, xMin, xMax, radarPos.X),
                              YtoScreen(height, yMin, yMax, radarPos.Y),
                              XtoScreen(width, xMin, xMax, radarPos.X + distance * Math.Cos(radarPhi)),
                              YtoScreen(height, yMin, yMax, radarPos.Y + distance * Math.Sin(radarPhi)));

        g.FillEllipse(_brushRobot, XtoScreen(width, xMin, xMax, lastPosInfo.X - .07f),
                                   YtoScreen(height, yMin, yMax, lastPosInfo.Y + .07f),
                                   WidthToScreen(width, xMin, xMax, .14f),
                                   HeightToScreen(height, yMin, yMax, .14f));

        int xScreenRobot = XtoScreen(width, xMin, xMax, lastPosInfo.X);
        int yScreenRobot = YtoScreen(height, yMin, yMax, lastPosInfo.Y);
        g.DrawLine(_penAngle, xScreenRobot, yScreenRobot,
                   xScreenRobot + WidthToScreen(width, xMin, xMax, (float)(.07f * Math.Cos(phi))),
                   yScreenRobot + HeightToScreen(height, yMin, yMax, (float)(-.07f * Math.Sin(phi))));

        #endregion
      }
    }
  }
}
