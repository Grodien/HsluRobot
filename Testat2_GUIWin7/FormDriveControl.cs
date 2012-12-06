using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RobotControl.Drive;

namespace Testat2_GUIWin7
{
  public partial class FormDriveControl : Form
  {
    public FormDriveControl()
    {
      InitializeComponent();
    }

    private void RunLineView1StartClicked(object sender, EventArgs e)
    {
      lsbCommands.Items.Add(new TrackLine((float)runLineView1.UPLength.Value, Track.DefaultMaxSpeed, Track.DefaultAcceleration));
    }

    private void RunTurnView1StartClicked(object sender, EventArgs e) {
      lsbCommands.Items.Add(new TrackTurn((float) runTurnView1.UPAngle.Value, Track.DefaultMaxSpeed, Track.DefaultAcceleration));
    }

    private void RunArcView1StartClicked(object sender, EventArgs e)
    {
      if (runArcView1.radioRight.Checked) {
        lsbCommands.Items.Add(new TrackArcRight((float)runArcView1.UPRadius.Value / 1000f, (float) runArcView1.UPAngle.Value, Track.DefaultMaxSpeed,
                          Track.DefaultAcceleration));
      } else {
        lsbCommands.Items.Add(new TrackArcLeft((float)runArcView1.UPRadius.Value / 1000f, (float)runArcView1.UPAngle.Value, Track.DefaultMaxSpeed,
                          Track.DefaultAcceleration));
      }
    }

    private void LsbCommandsKeyDown(object sender, KeyEventArgs e)
    {
      if (lsbCommands.SelectedItem == null)
        return;

      if (e.KeyCode == Keys.Delete) {
        int index = lsbCommands.SelectedIndex;
        lsbCommands.Items.Remove(lsbCommands.SelectedItem);
        if (lsbCommands.Items.Count > 0) {
          if (index < lsbCommands.Items.Count) {
            lsbCommands.SelectedIndex = index;
          } else {
            lsbCommands.SelectedIndex = lsbCommands.Items.Count - 1;
          }
        } 
        
      } else if ((e.Control || e.Shift) && e.KeyCode == Keys.Up) {
        int index = lsbCommands.SelectedIndex;
        if (index > 0) {
          object item = lsbCommands.SelectedItem;
          lsbCommands.Items.Remove(item);
          lsbCommands.Items.Insert(index - 1, item);
          lsbCommands.SelectedIndex = index;
        }
      } else if ((e.Control || e.Shift) && e.KeyCode == Keys.Down) {
        int index = lsbCommands.SelectedIndex;
        if (index < lsbCommands.Items.Count - 1)
        {
          object item = lsbCommands.SelectedItem;
          lsbCommands.Items.Remove(item);
          lsbCommands.Items.Insert(index + 1, item);
          lsbCommands.SelectedIndex = index;
        }
      }
    }

    private void BtnConnectClick(object sender, EventArgs e)
    {

    }

    private void BtnStartClick(object sender, EventArgs e)
    {

    }
  }
}
