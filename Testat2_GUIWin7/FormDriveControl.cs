using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using RobotControl.Drive;
using RobotIO.Server.Bluetooth;
using Testat2_GUIWin7.Bluetooth;

namespace Testat2_GUIWin7
{
  public partial class FormDriveControl : Form
  {
    private BluetoothConnector _connector;
    private BackgroundWorker _discoverWorker;
    private BackgroundWorker _connectWorker;
    private LiveViewForm _liveViewFormForm;
    private readonly object _liveViewFormFormLocker = new object();

    public FormDriveControl()
    {
      InitializeComponent();
      _connector = new BluetoothConnector();
      _connector.SubscribeTo(_connector_OnMessageReceived, BluetoothCommandResponse.Started, 
                                                           BluetoothCommandResponse.Status, 
                                                           BluetoothCommandResponse.TrackReceived);
      _connectWorker = new BackgroundWorker();
      _connectWorker.DoWork += ConnectWorkerOnDoWork;
      _connectWorker.RunWorkerCompleted += ConnectWorkerRunWorkerCompleted;
      _discoverWorker = new BackgroundWorker();
      _discoverWorker.DoWork += DiscoverWorkerOnDoWork;
      _discoverWorker.RunWorkerCompleted += DiscoverWorkerOnRunDiscoverWorkerCompleted;
    }

    void _connector_OnMessageReceived(string message) {
      if (lsbRobotMessages.InvokeRequired) {
        lsbRobotMessages.Invoke(new Action<string>(_connector_OnMessageReceived), message);
      } else
      {
        var messageParts = message.Split('¿');
        statusLabel.Text = String.Format("Response: {0}", messageParts[0]);
        foreach (var messagePart in messageParts)
        {
          lsbRobotMessages.Items.Add(message);
        }
        lsbRobotMessages.SelectedIndex = lsbRobotMessages.Items.Count - 1;
        lsbRobotMessages.SelectedIndex = -1;
      }
    }

    void ConnectWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (e.Error == null) {
        statusLabel.Text = "Connection to Device established!";
        btnConnect.Text = "Disconnect";
        btnConnect.Enabled = true;
        lsbCommands.Items.Clear();
        SetControlState(true);
      } else {
        statusLabel.Text = "Failed to connect to Device!";
        btnConnect.Enabled = true;
        btnRefresh.Enabled = true;
      }
    }

    private void ConnectWorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs) {
      _connector.Connect((BluetoothDevice)doWorkEventArgs.Argument);
    }

    private void DiscoverWorkerOnRunDiscoverWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs) {
      lsbCommands.Items.Clear();
      btnRefresh.Enabled = true;
      statusLabel.Text = String.Format("Found {0} devices", _connector.Peers.Count);
      foreach (var bluetoothDeviceInfo in _connector.Peers) {
        lsbCommands.Items.Add(bluetoothDeviceInfo);
      }
    }

    private void DiscoverWorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs) {
      _connector.DetectDevices();
    }

    private void RunLineView1StartClicked(object sender, EventArgs e)
    {
      lsbCommands.Items.Add(new TrackLine((float)runLineView1.UPLength.Value / 1000f, Track.DefaultMaxSpeed, Track.DefaultAcceleration));
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
      if (_connectWorker.IsBusy || _discoverWorker.IsBusy)
        return;
    
      if (_connector.Connected) {
        _connector.Disconnect();

        btnConnect.Text = "Connect";

        SetControlState(false);
        btnRefresh.Enabled = true;
        lsbCommands.Items.Clear();

      } else {
        _connectWorker.RunWorkerAsync(lsbCommands.SelectedItem);
        btnRefresh.Enabled = false;
        btnConnect.Enabled = false;
        statusLabel.Text = "Connecting to device...";
      }
    }

    private void SetControlState(bool state)
    {
      btnLive.Enabled = state;
      btnStart.Enabled = state;
      runArcView1.Enabled = state;
      runLineView1.Enabled = state;
      runTurnView1.Enabled = state;
      btnStatus.Enabled = state;
    }

    private void BtnStartClick(object sender, EventArgs e)
    {
      foreach (var item in lsbCommands.Items) {
          _connector.WriteLine(item.ToString());
      }
      _connector.WriteLine(BluetoothCommands.Start);
    }

    private void BtnRefreshClick(object sender, EventArgs e)
    {

      if (_discoverWorker.IsBusy || _connectWorker.IsBusy)
        return;
      
      _discoverWorker.RunWorkerAsync();
      lsbCommands.Items.Clear();
      btnRefresh.Enabled = false;
      statusLabel.Text = "Searching for Bluetooth Devices...";
    }

    private void LsbCommandsSelectedIndexChanged(object sender, EventArgs e) {
      object obj = lsbCommands.SelectedItem;
      if (_connector.Connected || (obj != null && obj.GetType() == typeof(BluetoothDevice))) {
        btnConnect.Enabled = true;
      } else {
        btnConnect.Enabled = false;
      }
    }

    private void BtnStatusClick(object sender, EventArgs e)
    {
      _connector.WriteLine(BluetoothCommands.Status);
    }

    private void BtnLiveClick(object sender, EventArgs e)
    {
      lock(_liveViewFormFormLocker)
      {
        if (_liveViewFormForm == null)
        {
          _liveViewFormForm = new LiveViewForm(_connector.WriteLine);
          _connector.SubscribeTo(_liveViewFormForm.OnMessageReceived, BluetoothCommandResponse.AllPositions);
          _liveViewFormForm.Closed += (o, ea) =>
                                        {
                                          _connector.Unsubscribe(_liveViewFormForm.OnMessageReceived, BluetoothCommandResponse.AllPositions);
                                          _liveViewFormForm = null;
                                        };
          _liveViewFormForm.Show();
        }
      }
    }
  }
}
