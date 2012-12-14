using System;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace RobotControl.Drive
{
  public class Movement
  {
    private readonly IDictionary<Track, bool> _tracks;
    private readonly DriveImage _image;
    public bool Running { get; private set; }

    public bool Finished { get; private set; }

    public IDictionary<Track, bool> Tracks { 
      get
      {
        lock (_tracks)
        {
          return new Dictionary<Track, bool>(_tracks);
        }
      } 
    }

    public Movement()
    {
      _tracks = new Dictionary<Track, bool>();
      _image = new DriveImage(World.Robot.Drive);
      World.Robot.Drive.TrackDone += DriveOnTrackDone;
    }

    private void DriveOnTrackDone(object sender, EventArgs eventArgs)
    {
      Track track = (Track) sender;
      lock (_tracks)
      {
        if (_tracks.ContainsKey(track))
        {
          _tracks[track] = true;
        }
        Finished = _tracks.Values.All(finished => finished);  
      }
      if (Finished)
        Running = false;
    }

    public void AddTrack(Track track)
    {
      lock (_tracks)
      {
        if (Running || Finished)
          NewMovement();
        _tracks.Add(track, false);  
      }
    }

    private void NewMovement()
    {
      Running = false;
      Finished = false;
      _tracks.Clear();
      _image.Reset();
      World.Robot.Drive.Stop();
    }

    public void StartMovement()
    {
      lock (_tracks)
      {
        Running = true;
        foreach (var track in _tracks.Keys)
        {
          World.Robot.Drive.AddTrack(track);
        }
      }
    }

    public IList<PositionInfo> GetAllPositionInfos()
    {
      return _image.GetAllPositionInfos();
    }

    public string GetBase64Image()
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        _image.GetImage().Save(memoryStream, ImageFormat.Bmp);
        memoryStream.Position = 0;
        return Convert.ToBase64String(memoryStream.ToArray());
      }
    }

    public override string ToString()
    {
      return ToString(false);
    }

    public string ToString(bool isHtml)
    {
      string newLine = isHtml ? "<br/>" : "¿";

      StringBuilder builder = new StringBuilder();
      builder.AppendFormat("---------- Status Report Fahrweg ---------{0}", newLine);
      builder.AppendFormat("Movement active: {0}{1}", Running, newLine);
      builder.AppendFormat("Movement finished: {0}{1}", Finished, newLine);
      builder.AppendFormat("# Tracks: {0} tracks.{1}", _tracks.Count, newLine);
      int i = 0;
      foreach (var track in _tracks)
      {
        if (track.Value)
        {
          builder.AppendFormat("Track {0}: Finished - Detail <{1}>{2}", ++i, track.Key, newLine);
        }
        else
        {
          builder.AppendFormat("Track {0}: Remaining {1:2g}m - Detail <{2}>{3}", ++i, track.Key.ResidualLength, track.Key, newLine);
        }
      }
      if (_tracks.Count > 0)
        builder.Append(newLine);

      if (isHtml)
      {
        builder.Append("<img src=\"data:image/jpeg;base64,");
        builder.Append(GetBase64Image());
        builder.Append("\"/>");
      }

      return builder.ToString(); 
    }
  }
}