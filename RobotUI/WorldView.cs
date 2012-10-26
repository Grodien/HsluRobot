//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: WorldView.cs 771 2011-10-28 08:39:33Z zajost $
//------------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using RobotControl;

namespace RobotUI
{
  /// <summary>
  /// Diese Klasse visualisiert einen Ausschnitt der Welt
  /// </summary>
  public partial class WorldView : UserControl
  {
    private readonly Font _font;
    private readonly Brush _fontBrush;
    private readonly Pen _penGrid2;
    private SolidBrush _brushRobot;
    private Pen _penAngle;
    private Pen _penGrid1;
    private Pen _penRadar;
    private Bitmap _plot;
    private ViewPort _viewPort;


    public WorldView()
    {
      _penGrid1 = new Pen(Color.Gray, 3);
      _penGrid2 = new Pen(Color.Gray, 1);
      _penAngle = new Pen(Color.Black, 7);
      _penRadar = new Pen(Color.Green, 9);
      _font = new Font(FontFamily.GenericSerif, 8, FontStyle.Regular);
      _fontBrush = new SolidBrush(Color.Black);
      _brushRobot = new SolidBrush(Color.Gray);

      _viewPort = new ViewPort(-1, 4, -2, 2);

      InitializeComponent();
    }

    /// <summary>
    /// Liefert die Farbe für den Roboter
    /// </summary>
    private SolidBrush BrushRobot
    {
      get
      {
        if (World.Robot != null)
        {
          if (World.Robot.Color != _brushRobot.Color)
          {
            _brushRobot = new SolidBrush(World.Robot.Color);
          }
        }
        return _brushRobot;
      }
    }

    /// <summary>
    /// Liefert bzw. setzt den Ausschnitt, den die WorldView darstellen soll
    /// </summary>
    public ViewPort ViewPort
    {
      get { return _viewPort; }
      set
      {
        _viewPort = value;
        UpdateView();
      }
    }

    /// <summary>
    /// Sorgt dafür, dass der Inhalt neu gezeichnet wird, falls die Grösse
    /// der WorldView verändert wird.
    /// </summary>
    /// 
    /// <param name="e"></param>
    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      UpdateView();
    }

    /// <summary>
    /// Berechnet aus einer x-Pos [m] im Weltkoordinatensystem 
    /// eine x-Pos [Pixel] im Koordinatensystem der WorldView
    /// </summary>
    /// <param name="x">die x-Position im Weltkoordinatensystem in Meter</param>
    /// <returns>die x-Position im WorldView-Koordinatensystem in Pixel</returns>
    private int XtoScreen(double x)
    {
      return WidthToScreen((float) (x - _viewPort.xMin));
    }

    /// <summary>
    /// Berechnet aus einer y-Pos [m] im Weltkoordinatensystem 
    /// eine y-Pos [Pixel] im Koordinatensystem der WorldView
    /// </summary>
    /// <param name="y">die y-Position im Weltkoordinatensystem in Meter</param>
    /// <returns>die y-Position im WorldView-Koordinatensystem in Pixel</returns>
    private int YtoScreen(double y)
    {
      return HeightToScreen((float) (y - _viewPort.yMin));
    }

    /// <summary>
    /// Berechnet aus einer Distanz [m] in x-Richtung die Anzahl
    /// Pixel im Koordinatensystem der WorldView.
    /// </summary>
    /// <param name="width">die Distanz/Strecke in Metern</param>
    /// <returns>die Anzahl Pixel, die dieser Distanz/Strecke entsprechen</returns>
    private int WidthToScreen(float width)
    {
      double percentage = width/(_viewPort.xMax - _viewPort.xMin);
      return (int) (Width*percentage);
    }

    /// <summary>
    /// Berechnet aus einer Distanz [m] in y-Richtung die Anzahl
    /// Pixel im Koordinatensystem der WorldView.
    /// </summary>
    /// <param name="height">die Distanz/Strecke in Metern</param>
    /// <returns>die Anzahl Pixel, die dieser Distanz/Strecke entsprechen</returns>
    private int HeightToScreen(float height)
    {
      double percentage = height/(_viewPort.yMax - _viewPort.yMin);
      return (int) (Height*percentage);
    }

    /// <summary>
    /// Aktualisiert die View, d.h. es wird in ein Bitmap gezeichnet und
    /// anschliessend das Bitmap in der PictureBox dargestellt.
    /// Folgende Objekte werden gezeichnet:
    /// - Hindernis
    /// - Koordinaten-Netz
    /// - Roboter
    /// - Radar
    /// </summary>
    private void UpdateView()
    {
      // Verhindert Exception falls Fenster auf 0 verkleinert wird.
      if (pictureBox.Width == 0 || pictureBox.Height == 0) return;

      // Verhindert Designer-Absturz falls ViewPort auf 0 gesetzt wird.
      if (_viewPort.Width == 0 || _viewPort.Height == 0) return;

      // Bitmap erstellen auf das die WorldView gezeichnet werden kann
      if ((_plot == null) || (_plot.Size != pictureBox.Size))
      {
        _plot = new Bitmap(pictureBox.Width, pictureBox.Height);
      }

      using (Graphics g = Graphics.FromImage(_plot))
      {
        // Hintergrund löschen
        g.Clear(Color.White);

        #region Koordinaten-Netz zeichnen
        // Vertikale Linien die >viewPort.xMin bzw. <viewPort.xMax sind zeichnen...
        double y = _viewPort.yMax - (_viewPort.yMax%0.5);
        for (; y > _viewPort.yMin; y -= .5d)
        {
          int yScreen = YtoScreen(y);
          g.DrawLine((y == 0d ? _penGrid1 : _penGrid2), 0, yScreen, Width, yScreen);
          g.DrawString(y.ToString(CultureInfo.InvariantCulture), _font, _fontBrush, 5, yScreen + 3);
        }

        // Horizontale Linien >viewPort.yMin bzw. <viewPort.yMax sind zeichnen...
        double x = _viewPort.xMax - (_viewPort.xMax%0.5);
        for (; x > _viewPort.xMin; x -= .5d)
        {
          int xScreen = XtoScreen(x);
          g.DrawLine((x == 0d ? _penGrid1 : _penGrid2), xScreen, 0, xScreen, Height);
          g.DrawString(x.ToString(CultureInfo.InvariantCulture), _font, _fontBrush, xScreen + 3, 5);
        }

        #endregion

        Robot robot = World.Robot;
        if (robot != null)
        {
          #region Roboter zeichnen

          var pos = robot.Drive.Position;
          g.FillEllipse(BrushRobot, XtoScreen(pos.X - .07f), YtoScreen(pos.Y - .07f), WidthToScreen(.14f), HeightToScreen(.14f));

          int xScreen = XtoScreen(pos.X);
          int yScreen = YtoScreen(pos.Y);
          g.DrawLine(_penAngle, xScreen, yScreen,
            xScreen + WidthToScreen((float)(.07f * Math.Cos(pos.Angle / 180 * Math.PI))),
            yScreen + HeightToScreen((float)(.07f * Math.Sin(pos.Angle / 180 * Math.PI))));

          #endregion
        }
      }

      pictureBox.Image = _plot;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      UpdateView();
    }
  }
}