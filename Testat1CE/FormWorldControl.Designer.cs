namespace Testat1CE
{
  partial class FormWorldControl
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
      this.driveView1 = new RobotUI.DriveView();
      this.commonRunParameters1 = new RobotUI.CommonRunParameters();
      this.consoleView1 = new RobotUI.ConsoleView();
      this.SuspendLayout();
      // 
      // driveView1
      // 
      this.driveView1.Drive = null;
      this.driveView1.Location = new System.Drawing.Point(3, 0);
      this.driveView1.Name = "driveView1";
      this.driveView1.Size = new System.Drawing.Size(290, 300);
      this.driveView1.TabIndex = 0;
      // 
      // commonRunParameters1
      // 
      this.commonRunParameters1.Location = new System.Drawing.Point(3, 306);
      this.commonRunParameters1.Name = "commonRunParameters1";
      this.commonRunParameters1.Size = new System.Drawing.Size(274, 93);
      this.commonRunParameters1.TabIndex = 1;
      // 
      // consoleView1
      // 
      this.consoleView1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.consoleView1.Location = new System.Drawing.Point(37, 405);
      this.consoleView1.Name = "consoleView1";
      this.consoleView1.RobotConsole = null;
      this.consoleView1.Size = new System.Drawing.Size(213, 50);
      this.consoleView1.TabIndex = 2;
      // 
      // FormWorldControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(297, 465);
      this.Controls.Add(this.consoleView1);
      this.Controls.Add(this.commonRunParameters1);
      this.Controls.Add(this.driveView1);
      this.Name = "FormWorldControl";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion

    private RobotUI.DriveView driveView1;
    private RobotUI.CommonRunParameters commonRunParameters1;
    private RobotUI.ConsoleView consoleView1;
  }
}

