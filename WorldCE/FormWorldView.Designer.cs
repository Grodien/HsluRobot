namespace WorldCE
{
  partial class FormWorldView
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
      this.worldView1 = new RobotUI.WorldView();
      this.SuspendLayout();
      // 
      // worldView1
      // 
      this.worldView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.worldView1.Location = new System.Drawing.Point(0, 0);
      this.worldView1.Name = "worldView1";
      this.worldView1.Size = new System.Drawing.Size(638, 455);
      this.worldView1.TabIndex = 0;
      // 
      // FormWorldView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(638, 455);
      this.Controls.Add(this.worldView1);
      this.Name = "FormWorldView";
      this.Text = "FormWorldView";
      this.ResumeLayout(false);

    }

    #endregion

    public RobotUI.WorldView worldView1;

  }
}