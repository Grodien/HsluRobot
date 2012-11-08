namespace RobotUI
{
    partial class WorldView
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
          this.pictureBox = new System.Windows.Forms.PictureBox();
          this.timer1 = new System.Windows.Forms.Timer();
          this.SuspendLayout();
          // 
          // pictureBox
          // 
          this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
          this.pictureBox.Location = new System.Drawing.Point(0, 0);
          this.pictureBox.Name = "pictureBox";
          this.pictureBox.Size = new System.Drawing.Size(524, 292);
          // 
          // timer1
          // 
          this.timer1.Enabled = true;
          this.timer1.Interval = 20;
          this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
          // 
          // WorldView
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
          this.Controls.Add(this.pictureBox);
          this.Name = "WorldView";
          this.Size = new System.Drawing.Size(524, 292);
          this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WorldView_KeyPress);
          this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WorldView_KeyDown);
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Timer timer1;
    }
}
