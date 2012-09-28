using System;

namespace RobotControl.Output
{
    public abstract class DigitalOut : IDisposable
    {
        private bool _isDisposed;

        public event EventHandler DigitalOutChanged;
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

        protected virtual void OnDispose()
        {
            _isDisposed = true;
        }

        public void Dispose()
        {
            if (_isDisposed == false)
                OnDispose();
            GC.SuppressFinalize(this);
        }
    }
}
