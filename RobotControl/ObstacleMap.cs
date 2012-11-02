//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: ObstacleMap.cs 652 2011-03-30 13:01:56Z zajost $
//------------------------------------------------------------------------------

using System;
using System.Drawing;

namespace RobotControl
{
  /// <summary>
  /// Diese Klasse bildet die Hinderniskarte ab.
  /// </summary>
  public class ObstacleMap
  {
    private const double MaxLength = 2.55;
    private readonly object _syncRoot = new object();
    private RectangleF _area;
    private Bitmap _image;
    private int _imageHeight;
    private int _imageWidth;
    private bool[,] _obstaclePixel;

    /// <summary>
    /// Erstellt eine neue Hinderniskarte und bildet diese auf 
    /// ein Koordinatensystem am (Mapping).
    /// </summary>
    /// 
    /// <param name="image">das Bild mit dem Hindernis</param>
    /// <param name="area">dazugehörige Fläche im Koordinatensystem,
    /// ausgehend von der linken unteren Ecke!</param>
    public ObstacleMap(Bitmap image, RectangleF area)
    {
      SetImage(image);
      _area = area;
    }


    /// <summary>
    /// Erstellt eine neue Hinderniskarte und bildet diese auf 
    /// ein Koordinatensystem ab (Mapping).
    /// </summary>
    /// 
    /// <param name="image">das Bild mit dem Hindernis</param>
    /// <param name="xMin">kleinste x-Pos im Koordinatensystem</param>
    /// <param name="xMax">grösste x-Pos im Koordinatensystem</param>
    /// <param name="yMin">kleinste y-Pos im Koordinatensystem</param>
    /// <param name="yMax">grösste y-Pos im Koordinatensystem</param>
    public ObstacleMap(Bitmap image, float xMin, float xMax, float yMin, float yMax)
      : this(image, new RectangleF(xMin, yMin, xMax - xMin, yMax - yMin))
    {
    }

    /// <summary>
    /// Liefert bzw. setzt das Bild mit dem Hindernis.
    /// </summary>
    public Bitmap Image
    {
      get
      {
        lock (_syncRoot)
        {
          return _image;
        }
      }
      set
      {
        lock (_syncRoot)
        {
          SetImage(value);
        }
      }
    }

    public RectangleF Area
    {
      get { return _area; }
      set { _area = value; }
    }

    /// <summary>
    /// Liefert die Information, wie weit das nächste Hindernist entfernt ist.
    /// </summary>
    /// <param name="position">die aktuelle (eigene) Position inkl. Blickrichtung</param>
    /// <returns>Die Distanz zum nächsten Hindernis in Blickrichtung</returns>
    public double GetFreeSpace(PositionInfo position)
    {
      lock (_syncRoot)
      {
        // Hindernis-Suche mit Bresenham-Algorithmus
        int x1 = xToIndex(position.X);
        int y1 = yToIndex(position.Y);
        int x2 = xToIndex(position.X + MaxLength*Math.Cos(position.Angle/180*Math.PI));
        int y2 = yToIndex(position.Y + MaxLength*Math.Sin(position.Angle/180*Math.PI));

        int dx = x2 - x1;
        int dy = y2 - y1;
        int absDx = Math.Abs(dx);
        int absDy = Math.Abs(dy);
        int incX = Math.Sign(dx);
        int incY = Math.Sign(dy);
        int x = x1, y = y1, err = 0;
        if (absDx >= absDy)
        {
          err = -absDx/2;
          for (x = x1; x != x2; x = x + incX)
          {
            if ((x >= 0) && (x < _imageWidth) &&
                (y >= 0) && (y < _imageHeight) &&
                _obstaclePixel[y, x])
              break;
            else
            {
              err += absDy;
              if (err >= 0)
              {
                y += incY;
                err -= absDx;
              }
            }
          }
        }
        else
        {
          err = -absDy/2;
          for (y = y1; y != y2; y = y + incY)
          {
            if ((x >= 0) && (x < _imageWidth) &&
                (y >= 0) && (y < _imageHeight) &&
                _obstaclePixel[y, x])
              break;
            else
            {
              err += absDx;
              if (err >= 0)
              {
                x += incX;
                err -= absDy;
              }
            }
          }
        }
        double xSpace = (x - x1)*_area.Width/_imageWidth;
        double ySpace = (y - y1)*_area.Height/_imageHeight;
        return Math.Sqrt(xSpace*xSpace + ySpace*ySpace);
      }
    }

    private int xToIndex(double x)
    {
      var index = (int) ((x - _area.X)*_imageWidth/_area.Width);
      return index;
    }

    private int yToIndex(double y)
    {
      int index = _imageHeight - (int) ((y - _area.Y)*_imageHeight/_area.Height);
      return index;
    }


    /// <summary>
    /// Setzt ein Bild und berechnet anschliessend die Hindernispixel.
    /// </summary>
    /// <param name="image">Das Bild mit dem Hindernis</param>
    private void SetImage(Bitmap image)
    {
      if (this._image != null) this._image.Dispose();
      this._image = image;
      _imageWidth = image.Width;
      _imageHeight = image.Height;

      CreateObstaclePixel();
    }


    /// <summary>
    /// Erstellt ein Boolean-Array mit den Hindernispixel.
    /// Das Array ist 2-Dimensional und gleich gross wie das Hindernisbild.
    /// Anschliessend wird Pixel für Pixel analysiert und dessen Helligkeit
    /// bestimmt. Der Schwellwert liegt bei 128. Ist die Helligkeit der
    /// drei Farben RGB im Durchschnitt kleiner als 128, so handelt es
    /// sich um ein Hindernis. Ansonsten ist es kein Hindernis.
    /// </summary>
    private void CreateObstaclePixel()
    {
      _obstaclePixel = new bool[_image.Height,_image.Width];
      for (int y = 0; y < _image.Height; y++)
      {
        for (int x = 0; x < _image.Width; x++)
        {
          Color c = _image.GetPixel(x, y);
          _obstaclePixel[y, x] = (c.R + c.G + c.B)/3 < 128;
        }
      }
    }
  }
}