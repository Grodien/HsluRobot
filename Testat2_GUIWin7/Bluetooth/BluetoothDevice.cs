using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InTheHand.Net.Sockets;

namespace Testat2_GUIWin7.Bluetooth
{
  public class BluetoothDevice
  {
    public BluetoothDevice(BluetoothDeviceInfo deviceInfo) {
      DeviceInfo = deviceInfo;
    }

    public BluetoothDeviceInfo DeviceInfo { get; private set; }

    public override string ToString() {
      return String.Format("{0}: {1}", DeviceInfo.DeviceName, DeviceInfo.DeviceAddress);
    }
  }
}
