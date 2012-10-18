using RobotUI;

namespace DriveCE
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
      this.runLineView1 = new RobotUI.RunLineView();
      this.commonRunParameters1 = new RobotUI.CommonRunParameters();
      this.driveView1 = new RobotUI.DriveView();
      this.runArcView1 = new RobotUI.RunArcView();
      this.runTurnView1 = new RobotUI.RunTurnView();
      this.SuspendLayout();
      // 
      // runLineView1
      // 
      this.runLineView1.Location = new System.Drawing.Point(312, 113);
      this.runLineView1.Name = "runLineView1";
      this.runLineView1.Size = new System.Drawing.Size(257, 84);
      this.runLineView1.TabIndex = 2;
      // 
      // commonRunParameters1
      // 
      this.commonRunParameters1.Location = new System.Drawing.Point(312, 3);
      this.commonRunParameters1.Name = "commonRunParameters1";
      this.commonRunParameters1.Size = new System.Drawing.Size(274, 93);
      this.commonRunParameters1.TabIndex = 1;
      // 
      // driveView1
      // 
      this.driveView1.Location = new System.Drawing.Point(3, 3);
      this.driveView1.Name = "driveView1";
      this.driveView1.Size = new System.Drawing.Size(292, 303);
      this.driveView1.TabIndex = 0;
      // 
      // runArcView1
      // 
      this.runArcView1.Location = new System.Drawing.Point(312, 293);
      this.runArcView1.Name = "runArcView1";
      this.runArcView1.Size = new System.Drawing.Size(257, 111);
      this.runArcView1.TabIndex = 3;
      // 
      // runTurnView1
      // 
      this.runTurnView1.Location = new System.Drawing.Point(312, 203);
      this.runTurnView1.Name = "runTurnView1";
      this.runTurnView1.Size = new System.Drawing.Size(257, 84);
      this.runTurnView1.TabIndex = 4;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(638, 455);
      this.Controls.Add(this.runTurnView1);
      this.Controls.Add(this.runArcView1);
      this.Controls.Add(this.runLineView1);
      this.Controls.Add(this.commonRunParameters1);
      this.Controls.Add(this.driveView1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion

    private DriveView driveView1;
    private CommonRunParameters commonRunParameters1;
    private RunLineView runLineView1;
    private RunArcView runArcView1;
    private RunTurnView runTurnView1;

  }
}

