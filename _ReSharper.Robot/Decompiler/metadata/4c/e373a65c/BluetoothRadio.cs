// Type: InTheHand.Net.Bluetooth.BluetoothRadio
// Assembly: InTheHand.Net.Personal, Version=3.5.605.0, Culture=neutral, PublicKeyToken=ea38caa273134499
// Assembly location: C:\Program Files (x86)\32feet.NET\NETCF\InTheHand.Net.Personal.dll

using InTheHand.Net;
using System;
using System.Diagnostics;

namespace InTheHand.Net.Bluetooth
{
  /// <summary>
  /// Represents a Bluetooth Radio device.
  /// 
  /// </summary>
  /// 
  /// <remarks>
  /// Allows you to query properties of the radio hardware and set the mode.
  /// </remarks>
  public sealed class BluetoothRadio
  {
    /// <summary>
    /// Gets an array of all Bluetooth radios on the system.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// Under Windows CE this will only ever return a single <see cref="T:InTheHand.Net.Bluetooth.BluetoothRadio"/> device.
    /// 
    /// <para>
    /// If the device has a third-party stack this property will return an empty collection
    /// </para>
    /// 
    /// </remarks>
    public static BluetoothRadio[] AllRadios { get; }
    /// <summary>
    /// Gets the primary <see cref="T:InTheHand.Net.Bluetooth.BluetoothRadio"/>.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// For Windows CE based devices this is the only <see cref="T:InTheHand.Net.Bluetooth.BluetoothRadio"/>, for Windows XP this is the first available <see cref="T:InTheHand.Net.Bluetooth.BluetoothRadio"/> device.
    /// 
    /// <para>
    /// If the device has a third-party stack this property will return null
    /// </para>
    /// 
    /// </remarks>
    public static BluetoothRadio PrimaryRadio { get; }
    /// <summary>
    /// Gets a value that indicates whether the 32feet.NET library can be used with the current device.
    /// 
    /// </summary>
    public static bool IsSupported { get; }
    /// <summary>
    /// Gets a class factory for creating client and listener instances on a particular stack.
    /// 
    /// </summary>
    public BluetoothPublicFactory StackFactory { [DebuggerStepThrough] get; }
    /// <summary>
    /// Gets whether the radio is on a Bluetooth stack on a remote machine.
    /// 
    /// </summary>
    /// -
    /// 
    /// <value>
    /// Is <see langword="null"/> if the radio is on to the local
    ///             machine, otherwise it’s the name of the remote machine to which the
    ///             radio is attached.
    /// 
    /// </value>
    public string Remote { [DebuggerStepThrough] get; }
    /// <summary>
    /// Gets the handle for this radio.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// Relevant only on Windows XP.
    /// </remarks>
    public IntPtr Handle { [DebuggerStepThrough] get; }
    /// <summary>
    /// Returns the current status of the Bluetooth radio hardware.
    /// 
    /// </summary>
    /// 
    /// <value>
    /// A member of the <see cref="P:InTheHand.Net.Bluetooth.BluetoothRadio.HardwareStatus"/> enumeration.
    /// </value>
    public HardwareStatus HardwareStatus { [DebuggerStepThrough] get; }
    /// <summary>
    /// Gets or Sets the current mode of operation of the Bluetooth radio.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// 
    /// <para>
    /// <strong>Microsoft CE/WM</strong>
    /// </para>
    /// 
    ///             This setting will be persisted when the device is reset.
    ///             An Icon will be displayed in the tray on the Home screen and a ?Windows Mobile device will emit a flashing blue LED when Bluetooth is enabled.
    /// 
    /// 
    /// <para>
    /// <strong>Widcomm Win32</strong>
    /// </para>
    /// 
    /// <para>
    /// Is supported.
    /// 
    /// </para>
    /// 
    /// <para>
    /// <strong>Widcomm CE/WM</strong>
    /// </para>
    /// 
    /// <para>
    /// Get and Set both supported.
    /// 
    /// </para>
    /// 
    /// <list type="table">
    /// 
    /// <listheader>
    /// <term>Mode</term><term>Get</term><term>Set</term>
    /// </listheader>
    /// 
    /// <item>
    /// <term>PowerOff</term><term>Disabled or non-connectable</term><term>CONNECT_ALLOW_NONE</term>
    /// </item>
    /// 
    /// <item>
    /// <term>Connectable</term><term>Connectable</term><term>CONNECT_ALLOW_ALL, note not CONNECT_ALLOW_PAIRED.</term>
    /// </item>
    /// 
    /// <item>
    /// <term>Discoverable</term><term>Discoverable</term><term>Plus also discoverable.</term>
    /// </item>
    /// 
    /// </list>
    /// 
    /// <para>
    /// Note also that when the Widcomm stack is disabled/off
    ///             we report <c>PowerOff</c> (not in 2.4 and earlier), but
    ///             we can't turn put it in that mode from the library.
    ///             Neither can we turn it back on, <strong>except</strong> that
    ///             it happens when the application first uses Bluetooth!
    /// 
    /// </para>
    /// 
    /// <para>
    /// <strong>Widcomm Win32</strong>
    /// </para>
    /// 
    /// <para>
    /// Set is not supported.  There's no Widcomm API support.
    /// 
    /// </para>
    /// 
    /// </remarks>
    public RadioMode Mode { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }
    /// <summary>
    /// Get the address of the local Bluetooth radio device.
    /// 
    /// </summary>
    /// -
    /// 
    /// <remarks>
    /// 
    /// <para>
    /// The property can return a <see langword="null"/> value in
    ///             some cases.  For instance on CE when the radio is powered-off the value
    ///             will be <see>null</see>.
    /// </para>
    /// 
    /// </remarks>
    /// -
    /// 
    /// <value>
    /// The address of the local Bluetooth radio device.
    /// 
    /// </value>
    public BluetoothAddress LocalAddress { [DebuggerStepThrough] get; }
    /// <summary>
    /// Returns the friendly name of the local Bluetooth radio.
    /// 
    /// </summary>
    /// -
    /// 
    /// <remarks>
    /// 
    /// <para>
    /// Devices normally cache the remote device name, only reading it the first
    ///             time the remote device is discovered.  It is generally not useful then to change
    ///             the name to provide a status update.  For instance on desktop Windows
    ///             with the Microsoft stack we haven't found a good way for the name to be
    ///             flushed so that it is re-read, even deleting the device didn't flush the
    ///             name if I remember correctly.
    /// 
    /// </para>
    /// 
    /// <para>
    /// Currently read-only on Widcomm stack.  Probably could be supported,
    ///             let us know if you need this function.
    /// 
    /// </para>
    /// 
    /// </remarks>
    public string Name { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }
    /// <summary>
    /// Returns the Class of Device.
    /// 
    /// </summary>
    public ClassOfDevice ClassOfDevice { [DebuggerStepThrough] get; }
    /// <summary>
    /// Returns the manufacturer of the <see cref="T:InTheHand.Net.Bluetooth.BluetoothRadio"/> device.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// See <see cref="P:InTheHand.Net.Bluetooth.BluetoothRadio.HciVersion"/> for more information.
    /// 
    /// </remarks>
    public Manufacturer Manufacturer { [DebuggerStepThrough] get; }
    /// <summary>
    /// Bluetooth Version supported by the Host Controller Interface implementation.
    /// 
    /// </summary>
    /// -
    /// 
    /// <remarks>
    /// 
    /// <para>
    /// There are five fields returned by the Read Local Version Information
    ///             HCI command: HCI Version, HCI Revision, LMP Version,
    ///             Manufacturer_Name, and LMP Subversion.
    ///             We expose all five, but not all platforms provide access to them all.
    ///             The Microsoft stack on desktop Windows exposes all five,
    ///             except for Windows XP which only exposes the Manufacturer
    ///             and LmpSubversion values.  Bluetopia apparently exposes none of them.
    ///             The Microsoft stack on Windows Mobile, Widcomm on both platforms,
    ///             BlueSoleil, and BlueZ expose all five.
    /// 
    /// </para>
    /// 
    /// </remarks>
    public HciVersion HciVersion { [DebuggerStepThrough] get; }
    /// <summary>
    /// Manufacture's Revision number of the HCI implementation.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// See <see cref="P:InTheHand.Net.Bluetooth.BluetoothRadio.HciVersion"/> for more information.
    /// 
    /// </remarks>
    public int HciRevision { [DebuggerStepThrough] get; }
    /// <summary>
    /// Bluetooth Version supported by the Link Manager Protocol implementation.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// See <see cref="P:InTheHand.Net.Bluetooth.BluetoothRadio.HciVersion"/> for more information.
    /// 
    /// </remarks>
    public LmpVersion LmpVersion { [DebuggerStepThrough] get; }
    /// <summary>
    /// Manufacture's Revision number of the LMP implementation.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// See <see cref="P:InTheHand.Net.Bluetooth.BluetoothRadio.HciVersion"/> for more information.
    /// 
    /// </remarks>
    public int LmpSubversion { [DebuggerStepThrough] get; }
    /// <summary>
    /// Returns the manufacturer of the Bluetooth software stack running locally.
    /// 
    /// </summary>
    public Manufacturer SoftwareManufacturer { [DebuggerStepThrough] get; }
  }
}
