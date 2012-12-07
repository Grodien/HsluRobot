//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: Track.cs 605 2011-03-19 16:42:08Z zajost $
//------------------------------------------------------------------------------

using System;
namespace RobotControl.Drive
{
  /// <summary>
  /// Basisklasse für Fahrbefehle
  /// </summary>
  /// <remarks>
  /// Initialisiert alle Parameter auf 0!
  /// Folgenden Variablen muss in der abgeleiteten Klasse 
  /// zwingend ein Wert zugewiesen werden!
  /// - Length (nur positiver Wert!!!)
  /// - nominalspeed (nur positiver Wert!!!)
  /// - acceleration
  /// - Reverse
  /// </remarks>
  public abstract class Track
  {
    public const float DefaultAcceleration = 0.3f;
    public const float DefaultMaxSpeed = 0.5f;

    protected float CurrentVelocity;
    protected float Length;
    protected bool Reverse;

    /// <summary>
    /// Liefert die Restlänge, d.h. die Länge [m] die vom Track 
    /// noch gefahren wird.
    /// </summary>
    public virtual float ResidualLength
    {
      get { return Length - CoveredLength; }
    }

    /// <summary>
    /// Liefert die Länge [m], die der Track bereits gefahren ist.
    /// </summary>
    public float CoveredLength { get; protected set; }


    /// <summary>
    /// Liefert true, falls der Track fertig abgearbeitet wurde.
    /// </summary>
    public virtual bool Done
    {
      //get { return (elapsedTime > pauseTime) && (coveredLength > Length); }
      get { return (CoveredLength >= Length); }
    }

    /// <summary>
    /// Liefert die Zeit [s], die der Track bis zum aktuellen Zeitpunkt
    /// insgesammt aktiv war (=Fahrzeit).
    /// </summary>
    public float ElapsedTime { get; protected set; }


    /// <summary>
    /// Liefert die eingestellt Beschleunigung [m/s^2]
    /// </summary>
    public float Acceleration { get; protected set; }


    /// <summary>
    /// Liefert die Geschwindigkeit [m/s], mit der gefahren werden soll.
    /// </summary>
    public float NominalSpeed { get; protected set; }

    protected Track(float speed, float acceleration)
    {
      NominalSpeed = Math.Abs(speed);
      Acceleration = Math.Abs(acceleration);
    }

    /// <summary>
    /// Diese Methode wird regelmässig aufgerufen und muss von jedem Track
    /// implementiert werden.
    /// Innerhalb der Methode müssen die Geschwindigkeiten für die beiden
    /// Räder berechnet und zurückgeliefert werden. Dazu stehen die Zeit seit
    /// dem letzten Aufruf der Methode sowie die erwartete Geschwindigkeit 
    /// des Roboters zur Verfügung.
    /// </summary>
    /// <param name="timeInterval">Zeit seit dem letzten Aufruf diese Methode [s]</param>
    /// <param name="newVelocity">die gewünschte Geschwindigkeit [m/s]</param>
    /// <param name="leftSpeed">berechneter Wert für Geschw. des linken Rades [m/s]</param>
    /// <param name="rightSpeed">berechneter Wert für Geschw. des rechten Rades [m/s]</param>
    protected abstract void OnIncrementalStep(float timeInterval, float newVelocity, out float leftSpeed, out float rightSpeed);

    public void IncrementalStep(float timeInterval, float newVelocity, out float leftSpeed, out float rightSpeed)
    {
      OnIncrementalStep(timeInterval, newVelocity, out leftSpeed, out rightSpeed);
      CurrentVelocity = newVelocity;
      DoStep(timeInterval);
    }

    /// <summary>
    /// Diese Methode führt die aufgelaufene Zeit sowie Distanz nach und muss
    /// zwingend von der Methode <see cref="OnIncrementalStep"/> aufgerufen
    /// werden!
    /// </summary>
    /// <param name="timeInterval">Zeit seit dem letzten Aufruf der Methode</param>
    protected void DoStep(float timeInterval)
    {
      ElapsedTime += timeInterval;
      CoveredLength += timeInterval*CurrentVelocity;
    }

    public override string ToString() {
      return ToStringData();
    }

    public abstract string ToStringData();
  }
}