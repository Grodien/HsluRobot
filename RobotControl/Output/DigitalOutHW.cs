using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using RobotIO;

namespace RobotControl.Output
{
    class DigitalOutHW : DigitalOut
    {
        private readonly int _ioPort;

        public DigitalOutHW(int ioPort) {
            _ioPort = ioPort;
        }

        public override void Dispose() {
        }

        public override int Data {
            get { return IOPortEx.Read(_ioPort); } 
            set {
                IOPortEx.Write(_ioPort, value);
                OnDigitalOutChanged(EventArgs.Empty);
            }
        }
    }
}
