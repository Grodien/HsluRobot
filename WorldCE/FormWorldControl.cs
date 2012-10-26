using System;
using System.Drawing;
using System.Windows.Forms;
using RobotControl;
using RobotUI;

namespace WorldCE
{
  public partial class FormWorldControl : Form
  {
    public FormWorldControl()
    {
      InitializeComponent();

      World.Robot = new Robot();
      
      // WorldView erstellen und anzeigen
      FormWorldView fww = new FormWorldView();
      fww.ViewPort = new ViewPort(-1.3, 1.3, -1.3, 1.3);
      
      fww.Show();

      // FormWorldControl in die obere, linke Ecke setzen
      #if !WindowsCE
      this.StartPosition = FormStartPosition.Manual;
      fww.StartPosition = FormStartPosition.Manual;
      #endif
      Location = new Point(0, 0);
      int width = Math.Min(Screen.PrimaryScreen.WorkingArea.Height, Screen.PrimaryScreen.WorkingArea.Width - Width);
      fww.Width = width;
      fww.ClientSize = new Size(fww.ClientSize.Width, fww.ClientSize.Width);
      fww.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - fww.Width, 0);

      driveView1.Drive = World.Robot.Drive;
      runLineView1.StartClicked += RunLineView1OnStartClicked;
      runTurnView1.StartClicked += RunTurnView1OnStartClicked;
      runArcView1.StartClicked += RunArcView1OnStartClicked;
    }
    
    private void RunArcView1OnStartClicked(object sender, EventArgs eventArgs) {

      if (runArcView1.radioRight.Checked) {
        driveView1.Drive.RunArcRight(
        ConvertDecimalMMToFloatM(runArcView1.UPRadius.Value),
        (float)runArcView1.UPAngle.Value,
        ConvertDecimalMMToFloatM(commonRunParameters1.UPSpeed.Value),
        ConvertDecimalMMToFloatM(commonRunParameters1.UPAcceleration.Value));
      } else {
        driveView1.Drive.RunArcLeft(
        ConvertDecimalMMToFloatM(runArcView1.UPRadius.Value),
        (float)runArcView1.UPAngle.Value,
        ConvertDecimalMMToFloatM(commonRunParameters1.UPSpeed.Value),
        ConvertDecimalMMToFloatM(commonRunParameters1.UPAcceleration.Value));
      }
    }

    private void RunTurnView1OnStartClicked(object sender, EventArgs eventArgs)
    {
      driveView1.Drive.RunTurn(
        (float)runTurnView1.UPAngle.Value,
        ConvertDecimalMMToFloatM(commonRunParameters1.UPSpeed.Value),
        ConvertDecimalMMToFloatM(commonRunParameters1.UPAcceleration.Value));
    }

    private void RunLineView1OnStartClicked(object sender, EventArgs eventArgs)
    {
      driveView1.Drive.RunLine(
        ConvertDecimalMMToFloatM(runLineView1.UPLength.Value), 
        ConvertDecimalMMToFloatM(commonRunParameters1.UPSpeed.Value), 
        ConvertDecimalMMToFloatM(commonRunParameters1.UPAcceleration.Value));
    }

    private float ConvertDecimalMMToFloatM(decimal value)
    {
      return (float)value / 1000f;
    }
  }
}