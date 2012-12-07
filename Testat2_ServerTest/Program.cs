using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotIO.Server.Bluetooth;

namespace Testat2_ServerTest
{
  class Program
  {
    static void Main(string[] args)
    {
      var bluetoothServer = new BluetoothServer();
      bluetoothServer.Start();
      Console.ReadKey();
      bluetoothServer.Stop();
    }
  }
}
