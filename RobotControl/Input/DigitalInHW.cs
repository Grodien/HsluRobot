using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using RobotIO;

namespace RobotControl.Input
{
    class DigitalInHW : DigitalIn
    {
        private readonly int _ioPort;
        private readonly Timer _pollTimer;
        private int _oldData;
        private bool _isDisposed;

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
        
        public override void Dispose() {
            if (_isDisposed)
            {
                _isDisposed = true;
                _pollTimer.Dispose();
            }   
        }

        public override int Data
        {
            get { return IOPortEx.Read(_ioPort); } 
            set {IOPortEx.Write(_ioPort, value); }
        }
    }
}
