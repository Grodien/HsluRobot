using System;

namespace RobotIO.Server.Bluetooth
{
  public abstract class BluetoothBaseRequest<T> : IRequestHandler where T : struct, IFormattable
  {
    protected T ResponseIdentifier { get; private set; }

    protected BluetoothBaseRequest(T identifier)
    {
      ResponseIdentifier = identifier;
    }

    public string Process(string[] request)
    {
      return string.Format("{0:0000}{1}", ResponseIdentifier, DoProcess(request));
    }

    protected abstract string DoProcess(string[] request);
  }
}