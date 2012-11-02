//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: Drive.cs 762 2011-10-26 09:30:46Z zajost $
//------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using RobotControl.Engine;
using RobotIO;

namespace RobotControl.Drive
{
  /// <summary>
  /// Mit Hilfe dieser Klasse können Fahrbefehle (z.B. linkskurve, gerade aus fahren etc.) ausgeführt 
  /// werden. Dazu verwendet sie intern die DriveCtrl sowie MotorCtrl Klassen um die einzelnen Motoren 
  /// anzusteuern.
  /// </summary>
  public class Drive : IDisposable
  {
    private readonly Object _drivesLock = new object();
    private readonly Object _infoLock = new object();
    private readonly Thread _thread;

    private bool _disposed;
    private volatile bool _halt;
    private volatile bool _run;
    private volatile bool _stop;
    private DriveInfo _info;
    private DriveInfo _oldInfo;
    private Track _actualTrack;

    private readonly List<Track> _tracksToRun;

    /// <summary>
    /// Initialisiert den Antrieb des Roboters
    /// </summary>
    public Drive()
    {
      _tracksToRun = new List<Track>();

      // Antrieb initialisieren
      if (Constants.IsWinCE)
      {
          DriveCtrl = new DriveCtrlHW(Constants.IODriveCtrl);
          MotorCtrlLeft = new MotorCtrlHW(Constants.IOMotorCtrlLeft);
          MotorCtrlRight = new MotorCtrlHW(Constants.IOMotorCtrlRight);
      }
      else
      {
        DriveCtrl = new DriveCtrlSim();
        MotorCtrlLeft = new MotorCtrlSim();
        MotorCtrlRight = new MotorCtrlSim();
      }

      // Beschleunigung festlegen
      DriveCtrl.Power = true;
      MotorCtrlLeft.Acceleration = 10f;
      MotorCtrlRight.Acceleration = 10f;
      Position = new PositionInfo(0f, 0f, 90);

      // Prozess-Thread erzeugen und starten
      _thread = new Thread(RunTracks) {IsBackground = true, Priority = ThreadPriority.Highest};
      _thread.Start();
    }


    /// <summary>
    /// Process-Loop beenden und die Motorencontroller zurücksetzen => Motoren halten an
    /// </summary>
    public void Dispose()
    {
      if (!_disposed)
      {
        _run = false; // Drive-Thread beenden
        _thread.Join();

        MotorCtrlLeft.Dispose(); // linkes Motorenobjekt disposen
        MotorCtrlRight.Dispose(); // rechtes Motorenobjekt disposen

        DriveCtrl.Dispose(); // DriveCtrl disposen => HW-Motorencontroller werden zurückgesetzt und Motoren laufen aus
        _disposed = true;
      }
    }

    /// <summary>
    /// Occurs when [track finished].
    /// </summary>
    public event EventHandler TrackFinished;

    private void OnTrackFinished()
    {
      EventHandler handler = TrackFinished;
      if (handler != null) handler(this, EventArgs.Empty);
    }

    /// <summary>
    /// Bietet Zugriff auf das DriveCtrl-Objekt um beispielsweise die Motoren ein-/auszuschalten
    /// </summary>
    public DriveCtrl DriveCtrl { get; private set; }


    /// <summary>
    /// Bietet Zugriff auf den linken Motor
    /// </summary>
    public MotorCtrl MotorCtrlLeft { get; private set; }


    /// <summary>
    /// Bietet Zugriff auf den rechten Motor
    /// </summary>
    public MotorCtrl MotorCtrlRight { get; private set; }


    /// <summary>
    /// Schaltet die Stromversorgung der Motoren ein-/aus
    /// </summary>
    public bool Power
    {
      set { DriveCtrl.Power = value; }
    }


    /// <summary>
    /// Liefert Informationen zum Drive (Position, Geschwindigkeit etc.)
    /// </summary>
    public DriveInfo DriveInfo
    {
      get
      {
        lock (_infoLock)
        {
          return _info;
        }
      }
    }


    /// <summary>
    /// Liefert bzw. setzt die aktuelle Position des Roboters
    /// </summary>
    public PositionInfo Position
    {
      get
      {
        lock (_infoLock)
        {
          return _info.Position;
        }
      }
      set
      {
        lock (_infoLock)
        {
          _info.Position = value;
        }
      }
    }


    /// <summary>
    /// Liefert true, falls gerade kein Track ausgeführt wird.
    /// </summary>
    public bool Done
    {
      get { return _actualTrack == null; }
    }

    private void AddTrack(Track track)
    {
      lock (_tracksToRun)
      {
        _tracksToRun.Add(track);
      }
    }

    /// <summary>
    /// Fährt eine Strecke gerade aus.
    /// </summary>
    /// <remarks> 
    /// Der Fahrbefehl wird nur ausgeführt, falls gerade kein anderer Fahrbefehl abgearbeitet wird!
    /// </remarks>
    /// <param name="length">Strecke, die zurückgelegt werden soll [m]</param>
    /// <param name="speed">die gewünschte Geschwindigkeit [m/s]</param>
    /// <param name="acceleration">die gewünschte Beschleunigung [m/s]</param>
    public void RunLine(float length, float speed, float acceleration)
    {
        if (_disposed) throw new ObjectDisposedException("Drive");
        AddTrack(new TrackLine(length, speed, acceleration));
    }

    /// <summary>
    /// Dreht an Ort und Stelle
    /// </summary>
    /// 
    /// <remarks> 
    /// Der Fahrbefehl wird nur ausgeführt, falls gerade kein anderer Fahrbefehl abgearbeitet wird!
    /// </remarks>
    /// 
    /// <param name="angle">der gewünschte Winkel [°]</param>
    /// <param name="speed">die gewünschte Geschwindigkeit [m/s]</param>
    /// <param name="acceleration">die gewünschte Beschleunigung [m/s]</param>
    public void RunTurn(float angle, float speed, float acceleration)
    {
        if (_disposed) throw new ObjectDisposedException("Drive");
        AddTrack(new TrackTurn(angle, speed, acceleration));
    }
    /// <summary>
    /// Fährt eine Linkskurve
    /// </summary>
    /// 
    /// <remarks> 
    /// Der Fahrbefehl wird nur ausgeführt, falls gerade kein anderer Fahrbefehl abgearbeitet wird!
    /// </remarks>
    /// 
    /// <param name="radius">der gewünschte Radius</param>
    /// <param name="angle">der gewünschte Winkel [°]</param>
    /// <param name="speed">die gewünschte Geschwindigkeit [m/s]</param>
    /// <param name="acceleration">die gewünschte Beschleunigung [m/s]</param>
    public void RunArcLeft(float radius, float angle, float speed, float acceleration)
    {
        if (_disposed) throw new ObjectDisposedException("Drive");
        AddTrack(new TrackArcLeft(radius, angle, speed, acceleration));
    }
    /// <summary>
    /// Fährt eine Rechtskurve
    /// </summary>
    /// 
    /// <remarks> 
    /// Der Fahrbefehl wird nur ausgeführt, falls gerade kein anderer Fahrbefehl abgearbeitet wird!
    /// </remarks>
    /// 
    /// <param name="radius">der gewünschte Radius</param>
    /// <param name="angle">der gewünschte Winkel [°]</param>
    /// <param name="speed">die gewünschte Geschwindigkeit [m/s]</param>
    /// <param name="acceleration">die gewünschte Beschleunigung [m/s]</param>
    public void RunArcRight(float radius, float angle, float speed, float acceleration)
    {
        if (_disposed) throw new ObjectDisposedException("Drive");
        AddTrack(new TrackArcRight(radius, angle, speed, acceleration));
    }

    /// <summary>
    /// Hält den Roboter sofort (abrupt) an.
    /// Removes all remaining tracks.
    /// </summary>
    public void Stop()
    {
      lock (_tracksToRun)
      {
        _tracksToRun.Clear();
      }
      _stop = true;
    }

    /// <summary>
    /// Bremst den Roboter ab und hält ihn an.
    /// </summary>
    public void Halt()
    {
      _halt = true;
    }

    /// <summary>
    /// Diese Thread-Methode ist dafür zuständig, die Fahrbefehle abzuarbeiten.
    /// Dazu werden folgende Schritte ausgeführt:
    /// - evtl. neuen Track initialisieren
    /// - Aktuelle Prozessdaten (Zeit) erfassen
    /// - Neue Parameter berechnen
    /// - Neue Parameter setzen
    /// - Informationen aktualisieren
    /// </summary>
    private void RunTracks()
    {
      float velocity = 0;
      float deltaTime;

      _stop = false;
      _halt = false;
      _run = true;

      Track oldTrack = null;

      int ticks = Environment.TickCount;

      while (_run)
      {
        Thread.Sleep(1); // Möglichst schneller Process Control Loop

        if (_stop)
        {
          _actualTrack = null;
          _stop = false;
          velocity = 0;
        }

        // Check if new Track needs to be assigned
        lock (_tracksToRun)
        {
          if (_actualTrack == null && _tracksToRun.Count > 0)
          {
            _actualTrack = _tracksToRun[0];
          }
        }

        // Falls ein neuer Track gesetzt wurde, diesen initialisieren und starten 
        if (_actualTrack != null && _actualTrack != oldTrack)
        {
          lock (_infoLock)
          {
            lock (_drivesLock)
            {
              // Aktuelle, gefahrene Distanz des linken un rechten Rades speichern
              _oldInfo.DistanceL = -MotorCtrlLeft.Distance;
              _oldInfo.DistanceR = MotorCtrlRight.Distance;
            }
            _info.Runtime = 0;
          }
          oldTrack = _actualTrack;
          _halt = false;
        }

        // Aktuelle Prozessdaten erfassen
        // ------------------------------
        int deltaTicks = Environment.TickCount - ticks; // Zeit [ms]
        ticks += deltaTicks;
        deltaTime = deltaTicks/1000.0f;

        if (_actualTrack != null)
        {
          if ((_actualTrack.Done) || ((_halt && (velocity == 0))))
          {
            _actualTrack = null;
            _halt = false;
          }
          else if (_actualTrack.ResidualLength > 0)
          {
            // Neue Prozessparameter berechnen
            // -------------------------------
            if (_halt)
            {
              // Roboter mit der eingestellten Beschleunigung bremsen und anhalten
              velocity = Math.Max(0, velocity - deltaTime*_actualTrack.Acceleration);
            }
            else
            {
              // Beschleunigung (od. Verzögerung bei Reduktion der nominalSpeed) 
              if (_actualTrack.NominalSpeed > velocity)
              {
                velocity = Math.Min(_actualTrack.NominalSpeed, velocity + deltaTime*_actualTrack.Acceleration);
              }
              else if (_actualTrack.NominalSpeed < velocity)
              {
                velocity = Math.Max(_actualTrack.NominalSpeed, velocity - deltaTime*_actualTrack.Acceleration);
              }

              // Verzögerung auf Zielposition
              // Geschwindigkeit auf max. zulässige Bremsgeschwindigkeit limitieren
              float ve;
              float s = _tracksToRun.Sum(track => track.ResidualLength);
              if (s >= 0)
              {
                ve = (float) Math.Sqrt(2.0*_actualTrack.Acceleration*s);
              }
              else
              {
                ve = 0;
              }

              if (float.IsNaN(ve)) ve = 0;
              velocity = Math.Min(ve, velocity);
              //System.Console.WriteLine(velocity);
            }

            // Neue Prozessparameter aktivieren
            // --------------------------------
            float leftSpeed, rightSpeed;
            _actualTrack.IncrementalStep(deltaTime, velocity, out leftSpeed, out rightSpeed);
            MotorCtrlLeft.Speed = leftSpeed;
            MotorCtrlRight.Speed = rightSpeed;

            // Motorenparameter sind gesetzt 
            // => möglichst gleichzeitig aktivieren (durch .Go())
            MotorCtrlLeft.Go();
            MotorCtrlRight.Go();
          }
          else
          {
            lock (_tracksToRun)
            {
              _tracksToRun.Remove(_actualTrack);
            }
            OnTrackFinished();
            _actualTrack = null;
          }
        }
        else
        {
          // Idle-Zustand setzen
          // -------------------
          lock (_drivesLock)
          {
            MotorCtrlLeft.Speed = 0;
            MotorCtrlRight.Speed = 0;
            MotorCtrlRight.Go();
            MotorCtrlLeft.Go();
          }
        }
        // Aktuellen Status speichern
        UpdateInfo(deltaTime);
      }
    }

    /// <summary>
    /// Diese Methode aktualisiert die Positionsinformationen indem die
    /// alten und neuen Daten sowie die gefahrende Distanz (Motorenticks)
    /// seit dem letzten Aufruf der Methode verrechnet werden.
    /// (siehe auch Übung 7)
    /// </summary>
    /// <param name="timeInterval">Zeit seit dem letzten Aufruf der Methode</param>
    private void UpdateInfo(double timeInterval)
    {
      // Motor-Status aktualisieren
      _info.DriveStatus = DriveCtrl.DriveState;

      lock (_infoLock)
      {
        lock (_drivesLock)
        {
          _info.MotorStatusL = MotorCtrlLeft.Status;
          _info.MotorStatusR = MotorCtrlRight.Status;

          _info.SpeedL = -MotorCtrlLeft.Speed;
          _info.SpeedR = MotorCtrlRight.Speed;

          _info.DistanceL = -MotorCtrlLeft.Distance;
          _info.DistanceR = MotorCtrlRight.Distance;
        }
        if (_actualTrack != null) _info.Runtime = _actualTrack.ElapsedTime;
      }

      // Position und Richtung im Weltkoordinatensystem bestimmen 
      // --------------------------------------------------------
      float dL = _info.DistanceL - _oldInfo.DistanceL;
      float dR = _info.DistanceR - _oldInfo.DistanceR;

      float d;
      float x1, y1, phi1;
      float x2, y2, phi2;

      d = (dL + dR)/2.0f;
      x1 = _info.Position.X;
      y1 = _info.Position.Y;
      phi1 = _info.Position.Angle/180.0f*(float) Math.PI;

      if (dL == dR) // Spezialfall geradeaus fahren
      {
        x2 = x1 + d*(float) Math.Cos(phi1);
        y2 = y1 + d*(float) Math.Sin(phi1);
        phi2 = phi1;
      }
      else if (dL == -dR) // Spezialfall an Ort drehen
      {
        x2 = x1;
        y2 = y1;
        phi2 = phi1 + dR/(Constants.AxleLength/2.0f);
      }
      else // allgemeiner Fall
      {
        float radius = Constants.AxleLength*d/(dR - dL);
        float x0 = x1 + radius*(float) Math.Cos(phi1 + (float) Math.PI/2.0);
        float y0 = y1 + radius*(float) Math.Sin(phi1 + (float) Math.PI/2.0);
        float dphi = d/radius;

        x2 = x0 + (x1 - x0)*(float) Math.Cos(dphi) - (y1 - y0)*(float) Math.Sin(dphi);
        y2 = y0 + (x1 - x0)*(float) Math.Sin(dphi) + (y1 - y0)*(float) Math.Cos(dphi);
        phi2 = phi1 + dphi;
      }

      phi2 = phi2%(2*(float) Math.PI);

      // Neue Position speichern
      lock (_infoLock)
      {
        _info.Position.X = x2;
        _info.Position.Y = y2;
        _info.Position.Angle = phi2/(float) Math.PI*180;
        _oldInfo = _info;
      }
    }
  }
}