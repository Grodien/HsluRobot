using System.ComponentModel;
using System.Windows.Forms;
using RobotControl;
using RobotControl.Input;
using RobotControl.Output;

namespace RobotUI
{
    public partial class ConsoleView : UserControl
    {
        public ConsoleView()
        {
            InitializeComponent();
            RobotConsole = new RobotConsole();
        }

        public RobotConsole RobotConsole { 
            get { return _robotConsole;  }
            set 
            { 
                _robotConsole = value;
                if (_robotConsole != null)
                {
                    ledView1.Led = _robotConsole[Leds.Led1];
                    ledView2.Led = _robotConsole[Leds.Led2];
                    ledView3.Led = _robotConsole[Leds.Led3];
                    ledView4.Led = _robotConsole[Leds.Led4];

                    switchView1.Switch = _robotConsole[Switches.Switch1];
                    switchView2.Switch = _robotConsole[Switches.Switch2];
                    switchView3.Switch = _robotConsole[Switches.Switch3];
                    switchView4.Switch = _robotConsole[Switches.Switch4];
                }
            } 
        }
        private RobotConsole _robotConsole;
    }
}
