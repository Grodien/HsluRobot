using System;
using System.Drawing;
using System.Windows.Forms;
using RobotControl.Drive;

namespace Testat2_GUIWin7
{
  public partial class LiveViewForm : Form
  {
    private readonly Action<string> _writeLineAction;
    private readonly DriveImageCreator _creator;
    private readonly Bitmap _bitmap;
    private bool _shallRefresh;

    public LiveViewForm(Action<string> writeLineAction)
    {
      InitializeComponent();
      _writeLineAction = writeLineAction;
      _creator = new DriveImageCreator();
      _bitmap = new Bitmap(image.Width, image.Height);
      image.Image = _bitmap;
      _shallRefresh = true;
    }

    public void OnMessageReceived(string message)
    {
      _creator.DrawImage(_bitmap, message);
      image.Refresh();
      _shallRefresh = true;
    }

    private void LiveViewForm_Shown(object sender, EventArgs e)
    {
      timer1.Enabled = true;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      if (_shallRefresh)
      {
        _writeLineAction(RobotIO.Server.Bluetooth.BluetoothCommands.Image);
      }
    }
  }
}
