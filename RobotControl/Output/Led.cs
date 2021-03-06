﻿//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: Led.cs 513 2011-02-17 15:17:16Z zajost $
//------------------------------------------------------------------------------

using System;

namespace RobotControl.Output
{
    /// <summary>
    /// Diese Klasse bildet eine LED des Roboters ab.
    /// </summary>
    public class Led
    {
        #region members
        public Leds LedEnum { get; private set; }
        private readonly DigitalOut _digitalOut;

        #endregion


        #region eventhandler
        public event EventHandler<LedEventArgs> LedStateChanged;
        #endregion


        #region constructor & destructor
        /// <summary>
        /// Initialisiert die gewünschte LED und verknüpft sie mit einem digitalOut-Objekt.
        /// </summary>
        /// <param name="digitalOut"></param>
        /// <param name="led"></param>
        public Led(Leds led, DigitalOut digitalOut)
        {
            if (digitalOut == null)
                throw new ArgumentNullException("digitalOut");

            LedEnum = led;
            _digitalOut = digitalOut;
        }
        #endregion


        #region properties
        /// <summary>
        /// Liefert bzw. setzt den Zustand der LED (ein-/ausgeschaltet)
        /// </summary>
        public bool LedEnabled
        {
            get { return _digitalOut[(int)LedEnum]; }
            set {
                //if (LedEnabled != value) {
                    _digitalOut[(int) LedEnum] = value;
                    OnLedStateChanged(new LedEventArgs(LedEnum, value));
                //}
            }
        }
        #endregion


        #region methods
        /// <summary>
        /// Diese Methode informiert alle registrierten Eventhandler über den Zustandswechsel 
        /// (ein-/ausgeschaltet) der LED.
        /// </summary>
        public void OnLedStateChanged(LedEventArgs args)
        {
            if (LedStateChanged != null)
            {
                LedStateChanged(this, args);
            }
        }
        #endregion

    }
}
