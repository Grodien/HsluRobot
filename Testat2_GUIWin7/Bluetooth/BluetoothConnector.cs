using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using InTheHand.Net.Sockets;
using RobotIO;
using RobotIO.Server.Bluetooth;

namespace Testat2_GUIWin7.Bluetooth
{
  class BluetoothConnector
  {
    private BluetoothClient _client;
    private StreamWriter _writer;
    private StreamReader _reader;
    private Thread _readerThread;

    private readonly Dictionary<BluetoothCommandResponse, Action<string>> _callbacks; 

    public BluetoothConnector() {
      _client = new BluetoothClient();
      _callbacks = new Dictionary<BluetoothCommandResponse, Action<string>>();
      Peers = new List<BluetoothDevice>();
    }

    public bool Connected { get { return _client.Connected; } }

    public List<BluetoothDevice> Peers { get; set; }

    public void DetectDevices()
    {
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
          if (!string.IsNullOrEmpty(message))
          {
            int identifier;
            if (int.TryParse(message.Substring(0, 4), out identifier))
            {
              Action<string> callback = _callbacks[(BluetoothCommandResponse)identifier];
              if (callback != null)
              {
                string content = message.Substring(4);
                if (!string.IsNullOrEmpty(content))
                {
                  callback(content);
                }
              }
            }
          }
        }
      } catch(Exception ex) { }
    }

    public void SubscribeTo(Action<string> callback, params BluetoothCommandResponse[] identifiers)
    {
      foreach (var identifier in identifiers)
      {
        SubscribeTo(callback, identifier);
      }
    }
    public void SubscribeTo(Action<string> callback, BluetoothCommandResponse identifier)
    {
      if (_callbacks.ContainsKey(identifier))
      {
        _callbacks[identifier] += callback;
      }
      else
      {
        _callbacks.Add(identifier, callback);
      }
    }

    public void Unsubscribe(Action<string> callback, params BluetoothCommandResponse[] identifiers)
    {
      foreach (var identifier in identifiers)
      {
        Unsubscribe(callback, identifier);
      }
    }
    public void Unsubscribe(Action<string> callback, BluetoothCommandResponse identifier)
    {
      if (_callbacks.ContainsKey(identifier))
      {
        _callbacks[identifier] -= callback;
      }
    }

    public void WriteLine(string data) {
      if (_writer != null) {
        _writer.WriteLine(data);
        _writer.Flush();
      }
    }
  }
}
