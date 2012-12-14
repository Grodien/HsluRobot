namespace RobotIO.Server.Bluetooth
{
  public enum BluetoothCommandResponse
  {
    Started = 1,
    TrackReceived,
    Status,
    AllPositions,
    PositionUpdate
  }

  public static class BluetoothCommands
  {
    public const string Start = "Start";
    public const string TrackLine = "TrackLine";
    public const string TrackTurn = "TrackTurn";
    public const string TrackArcLeft = "TrackArcLeft";
    public const string TrackArcRight = "TrackArcRight";
    public const string Status = "Status";
    public const string Image = "Image";
  }
}