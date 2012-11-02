using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RobotControl;
using RobotControl.DrivePatterns;
using RobotControl.Input;
using RobotControl.Output;
using RobotIO;
using RobotUI;
using WorldCE;

namespace Testat1CE
{
  public partial class FormWorldControl : Form
  {
    public FormWorldControl()
    {
      InitializeComponent();

      World.Robot = new Robot();

      if (!Constants.IsWinCE)
      {
        //World.ObstacleMap = new ObstacleMap(RobotUI.Properties.Resource.ObstacleMap1, -1.25f, 1.25f, -2.75f, -.25f);
        World.ObstacleMap = new ObstacleMap(RobotUI.Properties.Resource.ObstacleMap1, -3, 3, -1, 5);
      }

      // WorldView erstellen und anzeigen
      FormWorldView fww = new FormWorldView();
      fww.ViewPort = new ViewPort(-3, 3, -1, 5);

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
      consoleView1.RobotConsole = World.Robot.RobotConsole;

      World.Robot.RobotConsole[Switches.Switch1].SwitchStateChanged += OnSwitchStateChanged;
    }

    private void OnSwitchStateChanged(object sender, SwitchEventArgs switchEventArgs)
    {
      World.Robot.RobotConsole[Leds.Led1].LedEnabled = switchEventArgs.SwitchEnabled;

      if (switchEventArgs.SwitchEnabled)
      {
        FindSpaceAndPark pattern = new FindSpaceAndPark();
        pattern.Start();
      }
    }
  }
}