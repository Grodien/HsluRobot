//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: MotorCtrlSim.cs 763 2011-10-26 09:31:02Z zajost $
//------------------------------------------------------------------------------

using System;
using System.Threading;
using RobotIO;

namespace RobotControl.Engine
{
    public class MotorCtrlSim : MotorCtrl
    {

        #region members
        private float _acceleration;     // Beschleunigung [m/s^2]
        private float _nominalSpeed;     // eingestellte Geschwindigkeit [m/s]
        private float _currentSpeed;     // aktuelle Geschwindigkeit [m/s]

        private readonly Thread _thread;
        private int _ticks;
        private int _status;

        private volatile bool _stopThread;
        #endregion


        #region constructor & destructor
        /// <summary>
        /// Initialisiert den Simulator und startet einen Hintergrund-Thread,
        /// der die Simulation des Motors durchführt.
        /// </summary>
        public MotorCtrlSim()
        {
            Reset();

            this._thread = new Thread(Run) {IsBackground = true, Priority = ThreadPriority.AboveNormal};
            this._thread.Start();
        }
        #endregion


        #region properties
        /// <summary>
        /// Liefert bzw. setzt die gewünschte Geschwindigkeit [m/s] (Sollwert)
        /// </summary>
        public override float Speed
        {
            get { return this._nominalSpeed; }
            set { this._nominalSpeed = value; }
        }


        /// <summary>
        /// Liefert die aktuelle Geschwindigkeit [m/s] (Istwert)
        /// </summary>
        public override float CurrentSpeed
        {
            get { return this._currentSpeed; }
        }


        /// <summary>
        /// Liefert bzw. setzt die Beschleunigung [m/s^2]
        /// </summary>
        public override float Acceleration
        {
            get { return this._acceleration; }
            set { this._acceleration = value; }
        }


        /// <summary>
        /// Liefert das Statusbyte des Motorencontrollers
        /// </summary>
        public override int Status
        {
            get { return _status; }
        }


        /// <summary>
        /// Liefert die gefahrenen Ticks
        /// </summary>
        public override int Ticks
        {
            get { return this._ticks; }
        }
        #endregion


        #region methods
        /// <summary>
        /// TODO_joc (Speed etc. erst nach Go übernehmen => Verhalten wie IC implementieren)
        /// </summary>
        public override void Go()
        {
            this._status = 0x00;
        }

        /// <summary>
        /// Hält den Motor sofort an.
        /// </summary>
        public override void Stop()
        {
            this._status = 0x80;
            this._currentSpeed = 0;
        }

        /// <summary>
        /// Setzt den Motorencontroller zurück
        /// </summary>
        public override void Reset()
        {
            this._ticks = 0;
            this._nominalSpeed = 0;
            this._acceleration = 0.25f;
            this._status = 0x80;
        }


        /// <summary>
        /// Setzt den Ticks-Zähler auf Null zurück
        /// </summary>
        public override void ResetTicks()
        {
            this._ticks = 0;
        }


        /// <summary>
        /// Setzt die Werte für den PID-Regler
        /// </summary>
        /// <param name="proportional"></param>
        /// <param name="integral"></param>
        /// <param name="derivative"></param>
        /// <param name="integralLimit"></param>
        /// <param name="derivativeInterval"></param>
        public override void SetPID(int proportional, int integral, int derivative, int integralLimit, int derivativeInterval)
        {
            // Wird in der Simulation nicht beachtet.
        }


        /// <summary>
        /// Dieser Thread simuliert den Motor
        /// </summary>
        private void Run()
        {
            int idt;
            float dt;
            int time = Environment.TickCount;
            while (!_stopThread)
            {
                idt = Environment.TickCount - time; // = Zeitdiff. in Millisekunden
                time += idt;
                dt = idt / 1000f; // = Zeitdiff. in Sekunden
                
                if (!Stopped) {
                    _ticks += (int)(dt * Constants.TicksPerRevolution);

                    if (_nominalSpeed >= _currentSpeed) {
                        // aktuell zu langsam => beschleunigen
                        _currentSpeed = Math.Min(_nominalSpeed, _currentSpeed + dt * _acceleration);
                    } else {
                        // aktuell zu schnell => bremsen
                        _currentSpeed = Math.Max(_nominalSpeed, _currentSpeed - dt * _acceleration);
                    }
                }
                Thread.Sleep(1);
            }
        }
        public override void Dispose() {
            _stopThread = true;
            _thread.Join();
            base.Dispose();
        }       

        #endregion

    }
}
