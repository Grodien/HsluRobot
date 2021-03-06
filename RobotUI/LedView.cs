﻿using System;
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
            _setLedImageAction = SetLedImage;
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

        private readonly Action _setLedImageAction;

        private void SetLedImage() {
            if (InvokeRequired) {
                Invoke(_setLedImageAction);
            } else {
                pbLedState.Image = _on ? Resource.LedOn : Resource.LedOff;
            }
        }

        private bool _on;
        public bool On
        {
            get { return _on; }
            set {
                _on = value;
                SetLedImage();
            }
        }
    }
}
