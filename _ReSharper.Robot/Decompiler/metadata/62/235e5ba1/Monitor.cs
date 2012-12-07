// Type: System.Threading.Monitor
// Assembly: mscorlib, Version=3.5.0.0, Culture=neutral, PublicKeyToken=969db8053d3322ac
// Assembly location: c:\Program Files (x86)\Microsoft.NET\SDK\CompactFramework\v3.5\WindowsCE\mscorlib.dll

namespace System.Threading
{
  public sealed class Monitor
  {
    public static void Enter(object obj);
    public static bool TryEnter(object obj);
    public static void Exit(object obj);
  }
}
