using System;

namespace RobotControl.Output
{
    class DigitalOutSim : DigitalOut
    {
        private int _data;

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
