namespace RobotUI
{
  partial class RunArcView
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
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.UPRadius = new System.Windows.Forms.NumericUpDown();
      this.BtnStart = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.UPAngle = new System.Windows.Forms.NumericUpDown();
      this.radioRight = new System.Windows.Forms.RadioButton();
      this.radioLeft = new System.Windows.Forms.RadioButton();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(3, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(100, 20);
      this.label1.Text = "Run Arc:";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(3, 29);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(116, 20);
      this.label2.Text = "Radius (+ mm):";
      // 
      // UPRadius
      // 
      this.UPRadius.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
      this.UPRadius.Location = new System.Drawing.Point(153, 25);
      this.UPRadius.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
      this.UPRadius.Name = "UPRadius";
      this.UPRadius.Size = new System.Drawing.Size(100, 24);
      this.UPRadius.TabIndex = 2;
      this.UPRadius.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      // 
      // BtnStart
      // 
      this.BtnStart.Location = new System.Drawing.Point(153, 84);
      this.BtnStart.Name = "BtnStart";
      this.BtnStart.Size = new System.Drawing.Size(100, 20);
      this.BtnStart.TabIndex = 3;
      this.BtnStart.Text = "Start";
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(3, 58);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(128, 20);
      this.label3.Text = "Angle (+/- degree):";
      // 
      // UPAngle
      // 
      this.UPAngle.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.UPAngle.Location = new System.Drawing.Point(153, 54);
      this.UPAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
      this.UPAngle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
      this.UPAngle.Name = "UPAngle";
      this.UPAngle.Size = new System.Drawing.Size(100, 24);
      this.UPAngle.TabIndex = 2;
      this.UPAngle.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
      // 
      // radioRight
      // 
      this.radioRight.Location = new System.Drawing.Point(196, 3);
      this.radioRight.Name = "radioRight";
      this.radioRight.Size = new System.Drawing.Size(57, 20);
      this.radioRight.TabIndex = 7;
      this.radioRight.Text = "Right";
      // 
      // radioLeft
      // 
      this.radioLeft.Checked = true;
      this.radioLeft.Location = new System.Drawing.Point(140, 3);
      this.radioLeft.Name = "radioLeft";
      this.radioLeft.Size = new System.Drawing.Size(55, 20);
      this.radioLeft.TabIndex = 7;
      this.radioLeft.Text = "Left";
      // 
      // RunArcView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.Controls.Add(this.radioLeft);
      this.Controls.Add(this.radioRight);
      this.Controls.Add(this.BtnStart);
      this.Controls.Add(this.UPAngle);
      this.Controls.Add(this.UPRadius);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "RunArcView";
      this.Size = new System.Drawing.Size(257, 111);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button BtnStart;
    private System.Windows.Forms.Label label3;
    public System.Windows.Forms.NumericUpDown UPRadius;
    public System.Windows.Forms.NumericUpDown UPAngle;
    public System.Windows.Forms.RadioButton radioRight;
    public System.Windows.Forms.RadioButton radioLeft;
  }
}
