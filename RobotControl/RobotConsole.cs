//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: RobotConsole.cs 564 2011-03-07 07:31:52Z zajost $
//------------------------------------------------------------------------------

using RobotControl.Input;
using RobotControl.Output;
using System;

namespace RobotControl
{
    /// <summary>
    /// Bildet die Konsole des Roboters ab, die aus den LED's und Schaltern besteht.
    /// </summary>
    public class RobotConsole : IDisposable
    {
        #region members
        private readonly Led[] _leds;
        private readonly Switch[] _switches;
        private readonly DigitalIn _digitalIn;
        private readonly DigitalOut _digitalOut;
        #endregion

        #region constructor & destructor
        /// <summary>
        /// Initialisiert die Roboter-Konsole mit den dazugehörigen LED's und Schalter.
        /// </summary>
        public RobotConsole(RunMode runMode)
        {
            if (!Constants.IsWinCE) runMode = RunMode.Virtual;
            if (runMode == RunMode.Virtual)
            {
                _digitalIn = new DigitalInSim();
                _digitalOut = new DigitalOutSim();
            } else {
                _digitalIn = new DigitalInHW(Constants.IOConsoleSWITCH);
                _digitalOut = new DigitalOutHW(Constants.IOConsoleLED);
            }

            _leds = new Led[4];
            for (int i = 0; i < _leds.Length; i++)
            {
                _leds[i] = new Led((Leds)i, _digitalOut);
            }

            _switches = new Switch[4];
            for (int i = 0; i < _switches.Length; i++)
            {
                _switches[i] = new Switch((Switches)i, _digitalIn);
            }
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
            get { return _leds[(int)led]; }
        }

        /// <summary>
        /// Zugriff auf die Schalter per Indexer
        /// </summary>
        /// <param name="swi"></param>
        /// <returns></returns>
        public Switch this[Switches swi]
        {
            get { return _switches[(int)swi]; }
        }

        public void Dispose() {
           _digitalIn.Dispose();
           _digitalOut.Dispose();
        }

        #endregion
    }
}
