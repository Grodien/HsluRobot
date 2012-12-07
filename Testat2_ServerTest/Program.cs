using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotControl;
using RobotIO.Server.Bluetooth;
using RobotIO.Server.HTTP;

namespace Testat2_ServerTest
{
  class Program
  {
    static void Main(string[] args)
    {
      World.Robot = new Robot();
      var bluetoothServer = new BluetoothServer();
      var httpServer = new HttpServer(8000);
      bluetoothServer.Start();
      httpServer.Start();
      Console.ReadLine();
      bluetoothServer.Stop();
      httpServer.Stop();
    }
  }
}
