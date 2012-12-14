using System;
using System.Drawing;
using System.Windows.Forms;
using RobotControl.Drive;
using RobotIO.Server.Bluetooth;
using Testat2_GUIWin7.Bluetooth;

namespace Testat2_GUIWin7
{
  public partial class LiveViewForm : Form
  {
    private readonly BluetoothConnector _connector;
    private readonly DriveImageCreator _creator;
    private readonly Bitmap _bitmap;
    private bool _shallRefresh;

    public LiveViewForm(BluetoothConnector connector)
    {
      InitializeComponent();
      _connector = connector;
      _connector.SubscribeTo(OnMessageReceived, BluetoothCommandResponse.AllPositions);
      _creator = new DriveImageCreator();
      _bitmap = new Bitmap(image.Width, image.Height);
      image.Image = _bitmap;
      _shallRefresh = true;
    }

    private void OnMessageReceived(string message)
    {
      _creator.DrawImage(_bitmap, message);
      image.Image = _bitmap;
      _shallRefresh = true;
    }

    private void LiveViewFormShown(object sender, EventArgs e)
    {
      timer1.Enabled = true;
    }

    private void Timer1Tick(object sender, EventArgs e)
    {
      if (_shallRefresh) {
        _shallRefresh = false;
        _connector.WriteLine(BluetoothCommands.Image);
      }
    }

    private void LiveViewFormFormClosed(object sender, FormClosedEventArgs e)
    {
      _connector.Unsubscribe(OnMessageReceived, BluetoothCommandResponse.AllPositions);
    }
  }
}
