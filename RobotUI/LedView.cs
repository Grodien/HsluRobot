using System.Globalization;
using System.Windows.Forms;
using RobotControl.Output;
using RobotUI.Properties;

namespace RobotUI
{
    public partial class LedView : UserControl
    {
        public LedView()
        {
            InitializeComponent();
        }

        public string Index { 
            get { return lblIndex.Text; }
            private set { lblIndex.Text = value; }
        }

        private Led _led;
        public Led Led
        {
            get { return _led; }
            set {
                // Detach first 
                if (_led != null)
                {
                    _led.LedStateChanged -= LedStateChanged;
                }
                //Assign
                _led = value;
                if (value != null) {
                    Index = ((int)_led.LedEnum + 1).ToString(CultureInfo.InvariantCulture);
                    value.LedStateChanged += LedStateChanged;
                }
            }
        }

        private void LedStateChanged(object sender, LedEventArgs e)
        {
            On = e.LedEnabled;
        }

        private bool _on;
        public bool On
        {
            get { return _on; }
            set
            {
                _on = value;
                pbLedState.Image = _on ? Resource.LedOn : Resource.LedOff;
            }
        }
    }
}
