﻿using System;
using System.Threading;
using RobotIO;

namespace RobotControl.Input
{
    public class DigitalInHW : DigitalIn
    {
        private readonly int _ioPort;
        private readonly Timer _pollTimer;
        private int _oldData;

        public DigitalInHW(int ioPort) {
            _ioPort = ioPort;
            _pollTimer = new Timer(PollTimerCallback, null, 0, 50);
            _oldData = 0;
        }

        private void PollTimerCallback(object state) {
            int newData = Data;
            if (_oldData != newData)
            {
                _oldData = newData;
                OnDigitalInChanged(EventArgs.Empty);
            }
        }
        
        protected override void OnDispose() {
            _pollTimer.Dispose();
            base.OnDispose();
        }

        public override int Data
        {
            get { return IOPortEx.Read(_ioPort); } 
            set {IOPortEx.Write(_ioPort, value); }
        }
    }
}
