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
        //BluetoothRadio.PrimaryRadio.Name = "HSLU Robot - Team Bollhalder Bomatter";
        BluetoothRadio.PrimaryRadio.Mode = RadioMode.Discoverable;
        System.Guid serviceName = new System.Guid("{00112233-4455-6677-8899-aabbccddeeff}");
        _listener = new BluetoothListener(serviceName);
        _listener.ServiceName = serviceName.ToString();
        _listener.Start();
        while (!Stopped)
        {
          BluetoothClient client = _listener.AcceptBluetoothClient();
          ProcessClientSync(client.Client.RemoteEndPoint.ToString(), client.GetStream());
        }
      }
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