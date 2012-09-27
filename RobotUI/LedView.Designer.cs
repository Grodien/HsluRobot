namespace RobotUI
{
    partial class LedView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LedView));
            this.lblIndex = new System.Windows.Forms.Label();
            this.pbLedState = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // lblIndex
            // 
            this.lblIndex.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblIndex.Location = new System.Drawing.Point(0, 24);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(20, 16);
            this.lblIndex.Text = "0";
            this.lblIndex.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbLedState
            // 
            this.pbLedState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLedState.Image = ((System.Drawing.Image)(resources.GetObject("pbLedState.Image")));
            this.pbLedState.Location = new System.Drawing.Point(0, 0);
            this.pbLedState.Name = "pbLedState";
            this.pbLedState.Size = new System.Drawing.Size(20, 40);
            // 
            // LedView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lblIndex);
            this.Controls.Add(this.pbLedState);
            this.Name = "LedView";
            this.Size = new System.Drawing.Size(20, 40);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLedState;
        private System.Windows.Forms.Label lblIndex;

    }
}
