﻿using System;
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
    private const float xMin = -1.25f;
    private const float xMax = 1.25f;
    private const float yMin = -0.25f;
    private const float yMax = 2.25f;

    public FormWorldControl()
    {
      InitializeComponent();
      
      World.Robot = new Robot();

      if (!Constants.IsWinCE)
      {
        upDownMap.ValueChanged += upDownMap_ValueChanged;
        upDownMap_ValueChanged(null, null);
        upDownMap.Visible = true;
        label1.Visible = true;
      }

      // WorldView erstellen und anzeigen
      FormWorldView fww = new FormWorldView();
      fww.ViewPort = new ViewPort(xMin, xMax, yMin, yMax);

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
        FindSpaceAndParkPattern pattern = new FindSpaceAndParkPattern((float)commonRunParameters1.UPSpeed.Value/1000f, (float)commonRunParameters1.UPAcceleration.Value/1000f);
        pattern.Start();
      }
    }

    private void upDownMap_ValueChanged(object sender, EventArgs e)
    {
      switch ((int)upDownMap.Value)
      {
        case 1:
          World.ObstacleMap = new ObstacleMap(RobotUI.Properties.Resource.ObstacleMap1, xMin, xMax, yMin, yMax);
          break;
        case 2:
          World.ObstacleMap = new ObstacleMap(RobotUI.Properties.Resource.ObstacleMap2, xMin, xMax, yMin, yMax);
          break;
        case 3:
          World.ObstacleMap = new ObstacleMap(RobotUI.Properties.Resource.ObstacleMap3, xMin, xMax, yMin, yMax);
          break;
      }
    }
  }
}