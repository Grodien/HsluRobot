using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotControl.Drive
{
  public static class TrackParser
  {
    private const char Seperator = ' ';

    public static Track Parse(string data) {
      return Parse(data.Split(Seperator));
    }

    public static Track Parse(params string[] data) {
      Track track = null;
      switch (data[0]) {
        case "TrackLine": track = new TrackLine(float.Parse(data[1]), Track.DefaultMaxSpeed, Track.DefaultAcceleration);
          break;
        case "TrackTurn": track = new TrackTurn(float.Parse(data[1]), Track.DefaultMaxSpeed, Track.DefaultAcceleration);
          break;
        case "TrackArcLeft": track = new TrackArcLeft(float.Parse(data[2]), float.Parse(data[1]), Track.DefaultMaxSpeed, Track.DefaultAcceleration);
          break;
        case "TrackArcRight": track = new TrackArcRight(float.Parse(data[2]), float.Parse(data[1]), Track.DefaultMaxSpeed, Track.DefaultAcceleration);
          break;
      }

      return track;
    }
  }
}
