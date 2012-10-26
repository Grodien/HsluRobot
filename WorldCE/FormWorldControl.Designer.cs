namespace WorldCE
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
      this.runArcView1 = new RobotUI.RunArcView();
      this.runLineView1 = new RobotUI.RunLineView();
      this.runTurnView1 = new RobotUI.RunTurnView();
      this.SuspendLayout();
      // 
      // driveView1
      // 
      this.driveView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.driveView1.Drive = null;
      this.driveView1.Location = new System.Drawing.Point(0, 3);
      this.driveView1.Name = "driveView1";
      this.driveView1.Size = new System.Drawing.Size(293, 303);
      this.driveView1.TabIndex = 0;
      // 
      // commonRunParameters1
      // 
      this.commonRunParameters1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.commonRunParameters1.Location = new System.Drawing.Point(0, 312);
      this.commonRunParameters1.Name = "commonRunParameters1";
      this.commonRunParameters1.Size = new System.Drawing.Size(274, 93);
      this.commonRunParameters1.TabIndex = 1;
      // 
      // runArcView1
      // 
      this.runArcView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.runArcView1.Location = new System.Drawing.Point(299, 183);
      this.runArcView1.Name = "runArcView1";
      this.runArcView1.Size = new System.Drawing.Size(257, 111);
      this.runArcView1.TabIndex = 2;
      // 
      // runLineView1
      // 
      this.runLineView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.runLineView1.Location = new System.Drawing.Point(299, 3);
      this.runLineView1.Name = "runLineView1";
      this.runLineView1.Size = new System.Drawing.Size(257, 84);
      this.runLineView1.TabIndex = 3;
      // 
      // runTurnView1
      // 
      this.runTurnView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.runTurnView1.Location = new System.Drawing.Point(299, 93);
      this.runTurnView1.Name = "runTurnView1";
      this.runTurnView1.Size = new System.Drawing.Size(257, 84);
      this.runTurnView1.TabIndex = 4;
      // 
      // FormWorldControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(638, 455);
      this.Controls.Add(this.runTurnView1);
      this.Controls.Add(this.runLineView1);
      this.Controls.Add(this.runArcView1);
      this.Controls.Add(this.commonRunParameters1);
      this.Controls.Add(this.driveView1);
      this.Name = "FormWorldControl";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion

    private RobotUI.DriveView driveView1;
    private RobotUI.CommonRunParameters commonRunParameters1;
    private RobotUI.RunArcView runArcView1;
    private RobotUI.RunLineView runLineView1;
    private RobotUI.RunTurnView runTurnView1;
  }
}

