namespace RobotUI
{
  partial class RunLineView
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
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(3, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(100, 20);
      this.label1.Text = "Run Line:";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(3, 29);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(116, 20);
      this.label2.Text = "Length (+/- mm):";
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
      this.UPLength.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
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
      this.BtnStart.Location = new System.Drawing.Point(153, 55);
      this.BtnStart.Name = "BtnStart";
      this.BtnStart.Size = new System.Drawing.Size(100, 20);
      this.BtnStart.TabIndex = 3;
      this.BtnStart.Text = "Start";
      // 
      // RunLineView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.Controls.Add(this.BtnStart);
      this.Controls.Add(this.UPLength);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "RunLineView";
      this.Size = new System.Drawing.Size(257, 84);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button BtnStart;
    public System.Windows.Forms.NumericUpDown UPLength;
  }
}
