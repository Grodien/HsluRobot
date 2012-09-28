using System.Windows.Forms;
using RobotControl.Input;
using RobotUI.Properties;

namespace RobotUI
{
    public partial class SwitchView : UserControl
    {
        private delegate void onSwitchChange();

        public SwitchView()
        {
            InitializeComponent();
        }

        private Switch _switch;
        public Switch Switch
        {
            get { return _switch; }
            set { 
                // detach first
                if (_switch != null)
                    _switch.SwitchStateChanged -= SwitchStateChanged;

                // Assign
                _switch = value;
                if (value != null)
                    _switch.SwitchStateChanged += SwitchStateChanged;
            }
        }

        private void SwitchStateChanged(object sender, SwitchEventArgs e)
        {
            On = e.SwitchEnabled;
        }

        private void SetSwitchImage() {
            pbSwitchState.Image = _on ? Resource.SwitchOn : Resource.SwitchOff;
        }

        private bool _on;
        public bool On
        {
            get { return _on; }
            set { 
                _on = value;
                if (this.InvokeRequired) {
                    this.Invoke(new onSwitchChange(SetSwitchImage));
                } else {
                    SetSwitchImage();
                }
            }
        }

        private void PbSwitchStateClick(object sender, System.EventArgs e)
        {
            if (_switch != null)
                _switch.SwitchEnabled = !_switch.SwitchEnabled;
        }
    }
}
