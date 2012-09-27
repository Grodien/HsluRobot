﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;

namespace RobotUI
{
    public partial class LedView : UserControl
    {
        public LedView()
        {
            InitializeComponent();
        }

        public string Index { 
            get { return lblIndex.Text; }
            set { lblIndex.Text = value; }
        }

        public Led Led { get; set; }
    }
}
