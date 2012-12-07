using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using RobotIO;

namespace Testat2_GUIWin7.Bluetooth
{
  class BluetoothConnector
  {
    private BluetoothClient _client;
    private StreamWriter _writer;
    private StreamReader _reader;
    private Thread _readerThread;

    public delegate void DlgMessageReceived(string message);
    public event DlgMessageReceived OnMessageReceived;

    public BluetoothConnector() {
      _client = new BluetoothClient();
      Peers = new List<BluetoothDevice>();
    }

    public bool Connected { get { return _client.Connected; } }

    public List<BluetoothDevice> Peers { get; set; }

    public void DetectDevices() {
      Peers.Clear();
      foreach (var bluetoothDeviceInfo in _client.DiscoverDevices().ToList())
      {
        Peers.Add(new BluetoothDevice(bluetoothDeviceInfo));
      }
    }

    public void Connect(BluetoothDevice device) {
      _client.Connect(device.DeviceInfo.DeviceAddress, new Guid(Constants.BluetoothServiceGuid));
      _reader = new StreamReader(_client.GetStream());
      _writer = new StreamWriter(_client.GetStream());
      
      _readerThread = new Thread(ReadStream);
      _readerThread.Start();
    }

    public void Disconnect() {
      _client.Close();
      _client = new BluetoothClient();

      _readerThread = null;
      _reader = null;
      _writer = null;
    }

    private void ReadStream() {
      try {
        while (_client.Connected)
        {
          string message = _reader.ReadLine();
          if (OnMessageReceived != null && !String.IsNullOrEmpty(message))
            OnMessageReceived(message);
        }
      } catch(Exception ex) { }
    }

    public void WriteLine(string data) {
      if (_writer != null) {
        _writer.WriteLine(data);
        _writer.Flush();
      }
    }
  }
}
