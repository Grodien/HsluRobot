using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotControl.Input
{
    class DigitalInSim : DigitalIn
    {
        private int _data;

        public DigitalInSim() {
            
        }

        public override void Dispose() {
        }

        public override int Data {
            get {
                return _data;
            }
            set {
                _data = value;
                OnDigitalInChanged(EventArgs.Empty);
            }
        }
    }
}
