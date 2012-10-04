//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: DriveCtrlHW.cs 735 2011-10-13 09:16:14Z zajost $
//------------------------------------------------------------------------------

using RobotIO;
using System.Threading;

namespace RobotControl.Engine
{

    public class DriveCtrlHW : DriveCtrl
    {

        #region members
        private int _ioAddress;
        #endregion


        #region constructor & destructor
        public DriveCtrlHW(int ioAddress) {
            _ioAddress = ioAddress;
            Reset();
        }
        #endregion


        #region properties

        public override int DriveState {
            get { return IOPortEx.Read(_ioAddress); }
            protected set { IOPortEx.Write(_ioAddress, value);} 
        }

        #endregion

        #region methods

        public override void Reset() {
            DriveState = 0x00;
            Thread.Sleep(5);
            DriveState = 0x80;
            Thread.Sleep(5);
            DriveState = 0x00;
        }        

        #endregion
    }
}
