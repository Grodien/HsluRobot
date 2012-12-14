using System.Collections.Generic;
using System.Drawing;

namespace RobotControl.Drive
{
  public class DriveImage
  {
    private readonly List<PositionInfo> _posList;
    private readonly object _locker = new object();
    private readonly DriveImageCreator _creator;

    public DriveImage(Drive drive)
    {
      _posList = new List<PositionInfo>();
      _creator = new DriveImageCreator();
      _posList.Add(World.Robot.Drive.Position);
      drive.OnPositionUpdated += DriveOnOnPositionUpdated;
    }
    
    private void DriveOnOnPositionUpdated(PositionInfo positionInfo)
    {
      lock (_locker)
      {
        _posList.Add(positionInfo);
      }
    }

    public Bitmap GetImage()
    {
      return GetImage(500, 500);
    }

    public Bitmap GetImage(int width, int height)
    {
      Bitmap bitmap = new Bitmap(width, height);

      List<PositionInfo> tmpList;
      lock (_locker)
      {
        tmpList = new List<PositionInfo>(_posList);
      }
      _creator.DrawImage(bitmap, tmpList, World.Robot.Radar.AntennaPosition, World.Robot.Radar.Distance);
      return bitmap;
    }

    public void Reset()
    {
      lock (_locker)
      {
        _posList.Clear();
        _posList.Add(World.Robot.Drive.Position);
      }
    }

    public IList<PositionInfo> GetAllPositionInfos()
    {
      lock (_locker)
      {
        return new List<PositionInfo>(_posList);
      }
    }
  }
}