using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RobotControl.Drive;

namespace DriveCE
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();

      driveView1.Drive = new Drive();

      runLineView1.StartClicked += RunLineView1OnStartClicked;
      runTurnView1.StartClicked += RunTurnView1OnStartClicked;
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