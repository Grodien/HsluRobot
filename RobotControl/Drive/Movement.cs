using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace RobotControl.Drive
{
  public class Movement
  {
    private readonly IDictionary<Track, bool> _tracks;

    public bool Running { get; private set; }

    public bool Finished { get; private set; }
    public Bitmap Image { get; private set; }

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
      Image = new Bitmap(60, 50);
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

    public override string ToString()
    {
      return ToString(false);
    }

    public string ToString(bool isHtml)
    {
      string newLine = isHtml ? "\r\n" : "<br/>";

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
        NewMovement();
        using (MemoryStream memoryStream = new MemoryStream())
        //using (FileStream memoryStream = new FileStream("Test.bmp", FileMode.Open))
        {
          Image.Save(memoryStream, ImageFormat.Bmp);
          //Image.Save("Test.bmp", ImageFormat.Bmp);

          memoryStream.Position = 0;
          using (StreamReader stream = new StreamReader(memoryStream) )
          {
            System.Convert.ToBase64String()
            UTF8Encoding utf8 = new UTF8Encoding();

            return utf8.GetString(memoryStream.ToArray(), 0, (int)memoryStream.Length);
            //builder.Append("<img src=\""+stream.ReadToEnd()+"\"/>");
          }
        }
      }

      return builder.ToString(); 
    }
  }
}