using System;
using System.Windows.Forms;

namespace RobotUI
{
  public partial class RunTurnView : UserControl
  {
    public string ButtonText { 
      get { return BtnStart.Text; }
      set { BtnStart.Text = value; }
    }

    /// <summary>
    /// Occurs when [start clicked].
    /// </summary>
    public event EventHandler StartClicked
    {
      add { BtnStart.Click += value; }
      remove { BtnStart.Click -= value; }
    }

    public RunTurnView()
    {
      InitializeComponent();
    }
  }
}
