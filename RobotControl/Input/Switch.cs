//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: Switch.cs 513 2011-02-17 15:17:16Z zajost $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{

    public enum Switches
    {
        Switch1 = 0,
        Switch2,
        Switch3,
        Switch4
    }


    /// <summary>
    /// Diese Klasse bildet einen Schalter des Roboters ab
    /// </summary>
    public class Switch
    {

        #region members
        private Switches swi;
        private bool switchEnabled;
        #endregion


        #region eventhandler
        public event EventHandler<SwitchEventArgs> SwitchStateChanged;
        #endregion


        #region constructor & destructor
        /// <summary>
        /// Initialisiert den Schalter.
        /// </summary>
        /// <param name="swi">der abzubildende Schalter</param>
        public Switch(Switches swi)
        {
            this.swi = swi;
            this.switchEnabled = false;
        }
        #endregion


        #region properties
        /// <summary>
        /// Liefert bzw. setzt den Zustand des Schalters (ein-/ausgeschaltet)
        /// </summary>
        public bool SwitchEnabled
        {
            get { return switchEnabled; }
            set
            {
                switchEnabled = value;
                OnSwitchStateChanged(new SwitchEventArgs(this.swi, value));
            }
        }
        #endregion


        #region methods
        /// <summary>
        /// Diese Methode informiert alle registrierten Eventhandler über den Zustandswechsel 
        /// (ein-/ausgeschaltet) des Schalters.
        /// </summary>
        public void OnSwitchStateChanged(SwitchEventArgs e)
        {
            if (SwitchStateChanged != null)
            {
                SwitchStateChanged(this, e);
            }
        }
        #endregion

    }
}
