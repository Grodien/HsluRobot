﻿//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: MotorCtrlHW.cs 735 2011-10-13 09:16:14Z zajost $
//------------------------------------------------------------------------------

using System;
using System.Threading;
using RobotIO;

namespace RobotControl.Engine
{
    public class MotorCtrlHW : MotorCtrl
    {

        #region members
        // LM629 Commands:
        private const byte RESET = 0x00;
        private const byte START_MOTION = 0x01;
        private const byte LOAD_TRAJECTORY = 0x1F;
        private const byte READ_REAL_POSITION = 0x0A;
        private const byte LOAD_FILTER_PARAMETERS = 0x1E;
        private const byte UPDATE_FILTER = 0x04;
        private const byte DEFINE_HOME = 0x02;

        protected const float SAMPLE_PERIOD = 256E-6f;
        protected const float SPEED_SCALE = SAMPLE_PERIOD / Constants.MeterPerTick * (1 << 16);
        protected const float ACCELERATION_SCALE = SAMPLE_PERIOD * SAMPLE_PERIOD / Constants.MeterPerTick * (1 << 16);


        private float nominalSpeed;		// aktuell eingestellte Geschwindigkeit [m/s]
        private float acceleration;     // Beschleunigung [m/s^2]

        private int _ioAddress;
        private static object syncObj = new object();
        #endregion


        #region constructor & destructor
        /// <summary>
        /// Initialisiert den Motorencontroller und setzt ihn dabei zurück (Reset)
        /// </summary>
        /// 
        /// <param name="IOAddress">die Adresse für den Zugriff auf den Motorencontroller LM629</param>
        public MotorCtrlHW(int IOAddress)
        {
            _ioAddress = IOAddress;
            Reset();
        }
        #endregion


        #region properties
        /// <summary>
        /// Liefert bzw. setzt die Geschwindigkeit in [m/s]
        /// </summary>
        public override float Speed
        {
            get { return this.nominalSpeed; }

            set
            {
                lock (syncObj) // TODO_joc, hinzgefügt
                {
                    nominalSpeed = value;
                    int velocity = (int)Math.Abs(SPEED_SCALE * nominalSpeed);
                    int mode = (nominalSpeed >= 0) ? 0x1808 : 0x0808;
                    WriteCmd(LOAD_TRAJECTORY);
                    WriteShort(mode);
                    WriteInt(velocity);
                }
            }
        }

        
        /// <summary>
        /// Liefert die aktuelle Geschwindigkeit [m/s].
        /// 
        /// Achtung
        /// Es handelt sich um die eingestellte (Sollwert des Reglers) Geschwindigkeit intern im LM629 
        /// und nicht die gemessene Geschwindigkeit.
        /// </summary>
        public override float CurrentSpeed
        {
            get
            {
                lock (syncObj)
                {
                    //WriteCmd(0x0B); // Current velocity
                    WriteCmd(0x07);   // Desired velocity
                    return (float)Math.Round(ReadInt() / SPEED_SCALE, 3);
                }
            }
        }


        /// <summary>
        /// Liefert bzw. setzt die Beschleunigung [m/s^2]
        /// </summary>
        public override float Acceleration
        {
            get { return this.acceleration; }
            
            set
            {
                lock (syncObj)
                {
                    this.acceleration = value;
                    int accel = (int)(ACCELERATION_SCALE * value);
                    WriteCmd(LOAD_TRAJECTORY);
                    WriteShort(0x0820);
                    WriteInt(accel);
                }
            }
        }


        /// <summary>
        /// Liefert das Statusbyte des Motorencontrollers
        /// Bit7: 0 => Motor läuft, 1 => Motor gestoppt.
        /// </summary>
        public override int Status
        {
            get
            {
                lock (syncObj) // TODO_joc, hinzugefügt
                {
                    return IOPortEx.Read(_ioAddress);
                }
            }
        }


        /// <summary>
        /// Liefert die Anzahl Ticks.
        /// </summary>
        public override int Ticks
        {
            get
            {
                lock (syncObj)
                {
                    WriteCmd(READ_REAL_POSITION);
                    return ReadInt();
                }
            }
        }
        #endregion


        #region methods
        /// <summary>
        /// Übernimmt die Einstellungen wie Geschwindigkeit oder Beschleunigung
        /// und führt sie aus.
        /// </summary>
        public override void Go()
        {
            lock (syncObj)
            {
                WriteCmd(START_MOTION);
            }
        }


        /// <summary>
        /// Stoppt den Motor.
        /// </summary>
        public override void Stop()
        {
            lock (syncObj)
            {
                WriteCmd(LOAD_TRAJECTORY);
                WriteShort(0x0100);         // Trajectory Control Word => Turn Off Motor Bit8
                WriteCmd(START_MOTION);     // Execute Command
            }
        }


        /// <summary>
        /// Setzt den Motorencontroller zurück
        /// </summary>
        public override void Reset()
        {
            lock (syncObj)
            {
                Thread.Sleep(20);
                IOPortEx.Write(_ioAddress, RESET);
                Thread.Sleep(20);
                IOPortEx.Write(_ioAddress, DEFINE_HOME);			// Define Home
                Thread.Sleep(50);
                SetPID(100, 20, 1000, 1000, 1);
                //	SetPID(1500, 200, 8000, 1000, 1);

                WriteCmd(DEFINE_HOME);                  // Reset Tick-Counter
            }
        }


        /// <summary>
        /// Setzt den Ticks-Zähler auf Null zurück
        /// </summary>
        public override void ResetTicks()
        {
            lock (syncObj)
            {
                WriteCmd(DEFINE_HOME);
            }
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
            lock (syncObj)
            {
                WriteCmd(LOAD_FILTER_PARAMETERS);
                WriteShort(((derivativeInterval & 0xFF) << 8) | 0x0F);
                WriteShort(proportional);
                WriteShort(integral);
                WriteShort(derivative);
                WriteShort(integralLimit);
                WriteCmd(UPDATE_FILTER);
            }
        }
        #endregion


        #region internal helper methods
        /// <summary>
        /// Liefert true, falls der LM629 bereit ist, neue Befehle entgegen
        /// zu nehmen - ansonsten false.
        /// </summary>
        private bool Ready { get { return (Status & 0x01) == 0; } }


        /// <summary>
        /// Wartet max. 200ms bis der LM629 bereit ist, 
        /// neue Befehle entgegen zu nehmen
        /// </summary>
        /// <exception cref="ApplicationException">falls Timeout eintritt.</exception>
        void WaitReady()
        {
            WaitReady(200);
        }

        /// <summary>
        /// Wartet bis der LM629 bereit ist, neue Befehle entgegen zu nehmen
        /// </summary>
        /// <param name="timeout">Timeout in Millisekunden</param>
        /// <exception cref="ApplicationException">falls Timeout eintritt.</exception>
        void WaitReady(int timeout)
        {
            const int sleepTime = 1;
            int time = 0;
            while (!Ready)
            {
                Thread.Sleep(sleepTime);
                time += sleepTime;
                if (time > timeout)
                    throw new ApplicationException("waitReady-Timeout: Motor Controller IC LM629.");
            }
        }

        /// <summary>
        /// Sendet einen Befehl an den LM629
        /// </summary>
        /// <param name="cmd"></param>
        private void WriteCmd(byte cmd)
        {
            WaitReady();
            IOPortEx.Write(_ioAddress, cmd);
        }

        /// <summary>
        /// Sendet eine 16 Bit Zahl als Daten an den LM629
        /// </summary>
        /// <param name="val"></param>
        private void WriteShort(int val)
        {
            WaitReady();
            IOPortEx.Write(_ioAddress + 1, (val >> 8) & 0xFF);
            IOPortEx.Write(_ioAddress + 1, val & 0xFF);
        }

        /// <summary>
        /// Sendet eine 32 Bit Zahl als Daten an den LM629
        /// </summary>
        /// <param name="val"></param>
        private void WriteInt(int val)
        {
            WriteShort(((val >> 16) & 0xFFFF));
            WriteShort(((val >> 0) & 0xFFFF));
        }

        /// <summary>
        /// Liest eine 16 Bit Zahl vom LM629 (Daten)
        /// </summary>
        /// <returns></returns>
        private int ReadShort()
        {
            WaitReady();
            int val = IOPortEx.Read(_ioAddress + 1);
            val = (val << 8) | IOPortEx.Read(_ioAddress + 1);
            return val;
        }

        /// <summary>
        /// Liest eine 32 Bit Zahl vom LM629 (Daten)
        /// </summary>
        /// <returns></returns>
        private int ReadInt()
        {
            int val = ReadShort();
            val = (val << 16) | ReadShort();
            return val;
        }
        #endregion

    }
}
