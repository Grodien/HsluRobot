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
      this.UPLength = new System.Windows.Forms.NumericUpDown();
      this.BtnStart = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
      this.radioButton1 = new System.Windows.Forms.RadioButton();
      this.radioButton2 = new System.Windows.Forms.RadioButton();
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
      // UPLength
      // 
      this.UPLength.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
      this.UPLength.Location = new System.Drawing.Point(153, 25);
      this.UPLength.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
      this.UPLength.Name = "UPLength";
      this.UPLength.Size = new System.Drawing.Size(100, 24);
      this.UPLength.TabIndex = 2;
      this.UPLength.Value = new decimal(new int[] {
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
      // numericUpDown1
      // 
      this.numericUpDown1.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
      this.numericUpDown1.Location = new System.Drawing.Point(153, 54);
      this.numericUpDown1.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
      this.numericUpDown1.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new System.Drawing.Size(100, 24);
      this.numericUpDown1.TabIndex = 2;
      this.numericUpDown1.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
      // 
      // radioButton1
      // 
      this.radioButton1.Location = new System.Drawing.Point(201, 3);
      this.radioButton1.Name = "radioButton1";
      this.radioButton1.Size = new System.Drawing.Size(52, 20);
      this.radioButton1.TabIndex = 7;
      this.radioButton1.Text = "Right";
      // 
      // radioButton2
      // 
      this.radioButton2.Location = new System.Drawing.Point(143, 3);
      this.radioButton2.Name = "radioButton2";
      this.radioButton2.Size = new System.Drawing.Size(52, 20);
      this.radioButton2.TabIndex = 7;
      this.radioButton2.Text = "Left";
      // 
      // RunArcView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.Controls.Add(this.radioButton2);
      this.Controls.Add(this.radioButton1);
      this.Controls.Add(this.BtnStart);
      this.Controls.Add(this.numericUpDown1);
      this.Controls.Add(this.UPLength);
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
    private System.Windows.Forms.NumericUpDown UPLength;
    private System.Windows.Forms.Button BtnStart;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.NumericUpDown numericUpDown1;
    private System.Windows.Forms.RadioButton radioButton1;
    private System.Windows.Forms.RadioButton radioButton2;
  }
}
