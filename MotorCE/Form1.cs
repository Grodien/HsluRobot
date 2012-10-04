using System.Windows.Forms;
using RobotControl.Engine;
using RobotCtrl;
using RobotIO;

namespace MotorCE
{
    public partial class Form1 : Form
    {
        private MotorCtrl _leftMotorControl, _rightMotorControl;
        private DriveCtrl _driveControl;

        public Form1()
        {
            InitializeComponent();
            if (Constants.IsWinCE) {
                _leftMotorControl = new MotorCtrlHW(Constants.IOMotorCtrlLeft);
                _rightMotorControl = new MotorCtrlHW(Constants.IOMotorCtrlRight);
                _driveControl = new DriveCtrlHW(Constants.IODriveCtrl);
            } else {
                _leftMotorControl = new MotorCtrlSim();
                _rightMotorControl = new MotorCtrlSim();
                _driveControl = new DriveCtrlSim();
            }

            leftMotorCtrlView.MotorCtrl = _leftMotorControl;
            rightMotorCtrlView.MotorCtrl = _rightMotorControl;
            driveCtrlView.DriveCtrl = _driveControl;
        }
    }
}