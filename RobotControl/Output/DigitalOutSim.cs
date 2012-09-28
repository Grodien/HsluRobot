using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotControl.Output
{
    class DigitalOutSim : DigitalOut
    {
        private int _data;
        public DigitalOutSim() {
            
        }

        public override void Dispose() {
            
        }

        public override int Data
        {
            get { return _data; }
            set { 
                _data = value;
                OnDigitalOutChanged(EventArgs.Empty);
            }
        }
    }
}
