using System;

namespace RobotControl.Input
{
    public abstract class DigitalIn : IDisposable
    {
        public event EventHandler DigitalInChanged;
        public abstract void Dispose();
        public abstract int Data { get; set; }
        protected void OnDigitalInChanged(EventArgs e)
        {
            if (DigitalInChanged != null)
            {
                DigitalInChanged(this, e);
            }
        }
        public virtual bool this[int bit]
        {
            get { return (Data & (1 << bit)) != 0; }
            set {
                if (value)
                    Data |= (1 << bit);
                else
                    Data &= ~(1 << bit);
            }
        }
    }
}
