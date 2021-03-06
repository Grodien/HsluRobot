﻿using System.Threading;
using System.Net.Sockets;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace RobotIO.Server.Bluetooth
{
  public class BluetoothServer : AbstractServer
  {
    private BluetoothListener _listener;

    public BluetoothServer() 
      : base("Bluetooth")
    {
    }

    protected override void AddRequestHandlers()
    {
      RequestDict.Add(BluetoothCommands.Start, new BluetoothRequestStart());
      RequestDict.Add(BluetoothCommands.Image, new BluetoothRequestImage());
      RequestDict.Add(BluetoothCommands.Status, new BluetoothRequestStatus());

      var tmpHandler = new BluetoothRequestTrack();
      RequestDict.Add(BluetoothCommands.TrackLine, tmpHandler);
      RequestDict.Add(BluetoothCommands.TrackTurn, tmpHandler);
      RequestDict.Add(BluetoothCommands.TrackArcLeft, tmpHandler);
      RequestDict.Add(BluetoothCommands.TrackArcRight, tmpHandler);
    }

    protected override void StartListener()
    {
      if (BluetoothRadio.IsSupported)
      {
        if (Constants.IsWinCE)
          BluetoothRadio.PrimaryRadio.Name = "HSLU Robot - Team Bollhalder Bomatter";
        BluetoothRadio.PrimaryRadio.Mode = RadioMode.Discoverable;
        System.Guid serviceName = new System.Guid(Constants.BluetoothServiceGuid);
        Log("{0}: MAC: {1} Name {2}", Identifier, BluetoothRadio.PrimaryRadio.LocalAddress, BluetoothRadio.PrimaryRadio.Name);
        _listener = new BluetoothListener(serviceName);
        _listener.ServiceName = serviceName.ToString();
        _listener.Start();
        while (!Stopped)
        {
          BluetoothClient client = _listener.AcceptBluetoothClient();
          ProcessClientSync(client.Client.RemoteEndPoint.ToString(), client.GetStream(), () => FinishCallback(client));
        }
      }
    }

    private void FinishCallback(BluetoothClient client)
    {
      client.Close();
    }

    protected override void OnStop()
    {
      base.OnStop();
      _listener.Stop();
    }

    protected override Client CreateClient(string ip, NetworkStream networkStream)
    {
      return new Client(ip, networkStream);
    }
  }
}