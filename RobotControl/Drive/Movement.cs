using System;
using System.Linq;
using System.Collections.Generic;

namespace RobotControl.Drive
{
  public class Movement
  {
    private readonly IDictionary<Track, bool> _tracks;

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
  }
}