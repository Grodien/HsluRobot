//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: Switch.cs 513 2011-02-17 15:17:16Z zajost $
//------------------------------------------------------------------------------

using System;

namespace RobotControl.Input
{
    /// <summary>
    /// Diese Klasse bildet einen Schalter des Roboters ab
    /// </summary>
    public class Switch
    {
        #region members
        private readonly Switches _switch;
        private readonly DigitalIn _digitalIn;
        private bool _oldState;
        #endregion

        #region eventhandler
        public event EventHandler<SwitchEventArgs> SwitchStateChanged;
        #endregion

        #region constructor & destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Switch" /> class.
        /// </summary>
        /// <param name="swi">The swi.</param>
        /// <param name="digitalIn">The digital in.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public Switch(Switches swi, DigitalIn digitalIn)
        {
            if (digitalIn == null)
                throw new ArgumentNullException("digitalIn");

            _switch = swi;
            _digitalIn = digitalIn;
            _digitalIn.DigitalInChanged += DigitalInChanged;
            _oldState = false;
        }

        private void DigitalInChanged(object sender, EventArgs e)
        {
            bool newState = SwitchEnabled;
            if (_oldState != newState)
            {
                _oldState = newState;
                OnSwitchStateChanged(new SwitchEventArgs(_switch, newState));
            }
        }

        #endregion

        #region properties
        public bool SwitchEnabled {
            get { return _digitalIn[(int) _switch]; }
            set { _digitalIn[(int) _switch] = value; }
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
