using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace Testat2_GUIWin7.Bluetooth
{
  class BluetoothConnector
  {
    private readonly BluetoothClient _client;
    private StreamWriter _writer;

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
      _client.Connect(device.DeviceInfo.DeviceAddress, new Guid("{00112233-4455-6677-8899-aabbccddeeff}"));
      _writer = new StreamWriter(_client.GetStream());
    }

    public void Write(string data) {
      if (_writer != null) {
        _writer.WriteLine(data);
        _writer.Flush();
      }
    }
  }
}
