namespace MotorCE
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.driveCtrlView = new RobotUI.DriveCtrlView();
            this.leftMotorCtrlView = new RobotUI.MotorCtrlView();
            this.rightMotorCtrlView = new RobotUI.MotorCtrlView();
            this.SuspendLayout();
            // 
            // driveCtrlView
            // 
            this.driveCtrlView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.driveCtrlView.DriveCtrl = null;
            this.driveCtrlView.Location = new System.Drawing.Point(3, 3);
            this.driveCtrlView.Name = "driveCtrlView";
            this.driveCtrlView.Size = new System.Drawing.Size(480, 75);
            this.driveCtrlView.TabIndex = 0;
            // 
            // leftMotorCtrlView
            // 
            this.leftMotorCtrlView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leftMotorCtrlView.Location = new System.Drawing.Point(3, 90);
            this.leftMotorCtrlView.MotorCtrl = null;
            this.leftMotorCtrlView.Name = "leftMotorCtrlView";
            this.leftMotorCtrlView.Size = new System.Drawing.Size(480, 330);
            this.leftMotorCtrlView.TabIndex = 1;
            // 
            // rightMotorCtrlView
            // 
            this.rightMotorCtrlView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightMotorCtrlView.Location = new System.Drawing.Point(498, 90);
            this.rightMotorCtrlView.MotorCtrl = null;
            this.rightMotorCtrlView.Name = "rightMotorCtrlView";
            this.rightMotorCtrlView.Size = new System.Drawing.Size(480, 330);
            this.rightMotorCtrlView.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(984, 443);
            this.Controls.Add(this.rightMotorCtrlView);
            this.Controls.Add(this.leftMotorCtrlView);
            this.Controls.Add(this.driveCtrlView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private RobotUI.DriveCtrlView driveCtrlView;
        private RobotUI.MotorCtrlView leftMotorCtrlView;
        private RobotUI.MotorCtrlView rightMotorCtrlView;

    }
}

