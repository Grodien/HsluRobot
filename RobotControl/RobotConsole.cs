//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: RobotConsole.cs 564 2011-03-07 07:31:52Z zajost $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{

    /// <summary>
    /// Bildet die Konsole des Roboters ab, die aus den LED's und Schaltern besteht.
    /// </summary>
    public class RobotConsole
    {

        #region members
        private Led[] leds;
        private Switch[] switches;
        #endregion


        #region constructor & destructor
        /// <summary>
        /// Initialisiert die Roboter-Konsole mit den dazugehörigen LED's und Schalter.
        /// </summary>
        public RobotConsole()
        {
            leds = new Led[4];
            for (int i = 0; i < leds.Length; i++)
            {
                leds[i] = new Led((Leds)i);
            }

            switches = new Switch[4];
            for (int i = 0; i < switches.Length; i++)
            {
                switches[i] = new Switch((Switches)i);
                switches[i].SwitchStateChanged += RobotConsoleSwitchStateChanged;
            }
        }

        void RobotConsoleSwitchStateChanged(object sender, SwitchEventArgs e) {
            leds[(int) e.Swi].LedEnabled = e.SwitchEnabled;
        }
        #endregion


        #region methods
        /// <summary>
        /// Zugriff auf die Led's per Indexer
        /// </summary>
        /// <param name="led"></param>
        /// <returns></returns>
        public Led this[Leds led]
        {
            get { return leds[(int)led]; }
        }


        /// <summary>
        /// Zugriff auf die Schalter per Indexer
        /// </summary>
        /// <param name="swi"></param>
        /// <returns></returns>
        public Switch this[Switches swi]
        {
            get { return switches[(int)swi]; }
        }
        #endregion

    }
}
