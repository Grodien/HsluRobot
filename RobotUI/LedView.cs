using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;
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
                _led = value;
                if (value != null) {
                    value.LedStateChanged += ValueLedStateChanged;
                    Index = ((int)_led.LedEnum + 1).ToString(CultureInfo.InvariantCulture);
                }
            }
        }

        void ValueLedStateChanged(object sender, LedEventArgs e)
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
