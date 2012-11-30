using System;
using System.Globalization;
using System.Net.Sockets;
using System.IO;
using RobotControl;
using RobotControl.Output;
using System.Threading;

namespace DTServerCE
{
  class SimpleDayTimeServer
  {
    private static Robot _robot;
    private static Timer _tmr;

    static void Main(string[] args)
    {
      _robot = new Robot();
      _tmr = new Timer(TmrOnElapsed, null, Timeout.Infinite, Timeout.Infinite);
      TcpListener listen = new TcpListener(13);
      listen.Start();
      while (true)
      {
        Console.WriteLine("Warte auf Verbindung auf Port " +
        listen.LocalEndpoint + "...");
        TcpClient client = listen.AcceptTcpClient();
        Console.WriteLine("Verbindung zu " +
        client.Client.RemoteEndPoint);

        _tmr.Change(3000, Timeout.Infinite);
        _robot.RobotConsole[Leds.Led1].LedEnabled = true;

        StreamWriter sw = new StreamWriter(client.GetStream());
        sw.Write(DateTime.Now.ToString(CultureInfo.InvariantCulture));
        sw.Flush();
        client.Close();
      }
    }

    private static void TmrOnElapsed(object state) {
      _robot.RobotConsole[Leds.Led1].LedEnabled = false;
    }
  }
}
