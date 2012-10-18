using System;
using System.Windows.Forms;

namespace RobotUI
{
  public partial class RunArcView : UserControl
  {
    /// <summary>
    /// Occurs when [start clicked].
    /// </summary>
    public event EventHandler StartClicked
    {
      add { BtnStart.Click += value; }
      remove { BtnStart.Click -= value; }
    }

    public RunArcView()
    {
      InitializeComponent();
    }
  }
}
