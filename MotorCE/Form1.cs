using System.Windows.Forms;
using RobotControl.Engine;
using RobotCtrl;
using RobotIO;

namespace MotorCE
{
    public partial class Form1 : Form
    {
        private readonly MotorCtrl _leftMotorControl;
        private readonly MotorCtrl _rightMotorControl;
        private readonly DriveCtrl _driveControl;

        public Form1()
        {
            InitializeComponent();
            if (Constants.IsWinCE) {
                _driveControl = new DriveCtrlHW(Constants.IODriveCtrl);
                _leftMotorControl = new MotorCtrlHW(Constants.IOMotorCtrlLeft);
                _rightMotorControl = new MotorCtrlHW(Constants.IOMotorCtrlRight);
            } else {
                _driveControl = new DriveCtrlSim();
                _leftMotorControl = new MotorCtrlSim();
                _rightMotorControl = new MotorCtrlSim();
            }

            leftMotorCtrlView.MotorCtrl = _leftMotorControl;
            rightMotorCtrlView.MotorCtrl = _rightMotorControl;
            driveCtrlView.DriveCtrl = _driveControl;

        }
    }
}