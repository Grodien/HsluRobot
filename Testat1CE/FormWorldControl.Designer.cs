using System.Drawing;

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
      this.upDownMap = new System.Windows.Forms.NumericUpDown();
      this.label1 = new System.Windows.Forms.Label();
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
      this.consoleView1.Location = new System.Drawing.Point(38, 446);
      this.consoleView1.Name = "consoleView1";
      this.consoleView1.RobotConsole = null;
      this.consoleView1.Size = new System.Drawing.Size(213, 50);
      this.consoleView1.TabIndex = 2;
      // 
      // upDownMap
      // 
      this.upDownMap.Location = new System.Drawing.Point(168, 405);
      this.upDownMap.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
      this.upDownMap.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.upDownMap.Name = "upDownMap";
      this.upDownMap.Size = new System.Drawing.Size(100, 24);
      this.upDownMap.TabIndex = 3;
      this.upDownMap.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.upDownMap.Visible = false;
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(3, 409);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(100, 20);
      this.label1.Text = "ObstacleMap";
      this.label1.Visible = false;
      // 
      // FormWorldControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(298, 499);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.upDownMap);
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
    private System.Windows.Forms.NumericUpDown upDownMap;
    private System.Windows.Forms.Label label1;
  }
}

