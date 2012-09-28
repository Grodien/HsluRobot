using System.Windows.Forms;
using System;
using RobotControl;
using RobotControl.Input;
using RobotControl.Output;

namespace ConsoleCE
{
    public partial class Form1 : Form
    {
        private readonly RobotConsole _robotConsole;

        public Form1()
        {
            InitializeComponent();
            _robotConsole = new RobotConsole(RunMode.Real);
            _robotConsole[Switches.Switch1].SwitchStateChanged += SwitchStateChanged;
            _robotConsole[Switches.Switch2].SwitchStateChanged += SwitchStateChanged;
            _robotConsole[Switches.Switch3].SwitchStateChanged += SwitchStateChanged;
            _robotConsole[Switches.Switch4].SwitchStateChanged += SwitchStateChanged;

            consoleView1.RobotConsole = _robotConsole;
            consoleView2.RobotConsole = _robotConsole;
        }

        private void SwitchStateChanged(object sender, SwitchEventArgs e)
        {
            _robotConsole[(Leds)e.Swi].LedEnabled = e.SwitchEnabled;
        }
    }
}