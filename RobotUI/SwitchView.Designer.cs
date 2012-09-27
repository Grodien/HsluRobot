namespace RobotUI
{
    partial class SwitchView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SwitchView));
            this.pbSwitchState = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // pbSwitchState
            // 
            this.pbSwitchState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSwitchState.Image = ((System.Drawing.Image)(resources.GetObject("pbSwitchState.Image")));
            this.pbSwitchState.Location = new System.Drawing.Point(0, 0);
            this.pbSwitchState.Name = "pbSwitchState";
            this.pbSwitchState.Size = new System.Drawing.Size(20, 40);
            this.pbSwitchState.Click += new System.EventHandler(this.PbSwitchStateClick);
            // 
            // SwitchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pbSwitchState);
            this.Name = "SwitchView";
            this.Size = new System.Drawing.Size(20, 40);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSwitchState;
    }
}
