namespace Testat2_GUIWin7
{
  partial class LiveViewForm
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
      this.components = new System.ComponentModel.Container();
      this.image = new System.Windows.Forms.PictureBox();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
      this.SuspendLayout();
      // 
      // image
      // 
      this.image.Dock = System.Windows.Forms.DockStyle.Fill;
      this.image.Location = new System.Drawing.Point(0, 0);
      this.image.Name = "image";
      this.image.Size = new System.Drawing.Size(484, 462);
      this.image.TabIndex = 0;
      this.image.TabStop = false;
      // 
      // timer1
      // 
      this.timer1.Interval = 200;
      this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
      // 
      // LiveViewForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(484, 462);
      this.Controls.Add(this.image);
      this.Name = "LiveViewForm";
      this.Text = "LiveViewForm";
      this.Shown += new System.EventHandler(this.LiveViewFormShown);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LiveViewFormFormClosed);
      ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox image;
    private System.Windows.Forms.Timer timer1;
  }
}