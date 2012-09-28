using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotControl.Output
{
    public abstract class DigitalOut : IDisposable
    {
        public event EventHandler DigitalOutChanged;
        public abstract void Dispose();
        public abstract int Data { get; set; }
        protected void OnDigitalOutChanged(EventArgs e)
        {
            if (DigitalOutChanged != null)
            {
                DigitalOutChanged(this, e);
            }
        }
        public virtual bool this[int bit]
        {
            get { return (Data & (1 << bit)) != 0; }
            set
            {
                if (value)
                    Data |= (1 << bit);
                else
                    Data &= ~(1 << bit);
            }
        }
    }
}
