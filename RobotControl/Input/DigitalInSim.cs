using System;

namespace RobotControl.Input
{
    public class DigitalInSim : DigitalIn
    {
        private int _data;

        public override int Data {
            get { return _data; }
            set {
                _data = value;
                OnDigitalInChanged(EventArgs.Empty);
            }
        }
    }
}
