using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RobotUI;

namespace WorldCE
{
  public partial class FormWorldView : Form
  {
    public FormWorldView()
    {
      InitializeComponent();
    }

    public ViewPort ViewPort { 
      get { return worldView1.ViewPort; } 
      set { worldView1.ViewPort = value; } 
    }
  }
}