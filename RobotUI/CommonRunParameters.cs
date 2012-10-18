using System;
using System.Windows.Forms;

namespace RobotUI
{
  public partial class CommonRunParameters : UserControl
  {
    /// <summary>
    /// Occurs when [speed changed].
    /// </summary>
    public event EventHandler SpeedChanged
    {
      add { UPSpeed.Click += value; }
      remove { UPSpeed.Click -= value; }
    }

    /// <summary>
    /// Occurs when [acceleration changed].
    /// </summary>
    public event EventHandler AccelerationChanged
    {
      add { UPAcceleration.Click += value; }
      remove { UPAcceleration.Click -= value; }
    }

    public CommonRunParameters()
    {
      InitializeComponent();
    }
  }
}
