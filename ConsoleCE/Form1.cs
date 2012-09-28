using System.Windows.Forms;
using System;
using RobotControl;

namespace ConsoleCE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RobotConsole robotConsole = new RobotConsole();

            consoleView1.RobotConsole = robotConsole;
            consoleView2.RobotConsole = robotConsole;
        }
    }
}