namespace RobotUI
{
  partial class CommonRunParameters
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
      this.UPSpeed = new System.Windows.Forms.NumericUpDown();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.UPAcceleration = new System.Windows.Forms.NumericUpDown();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(3, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(168, 20);
      this.label1.Text = "Common Run Parameters:";
      // 
      // UPSpeed
      // 
      this.UPSpeed.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.UPSpeed.Location = new System.Drawing.Point(167, 32);
      this.UPSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.UPSpeed.Name = "UPSpeed";
      this.UPSpeed.Size = new System.Drawing.Size(100, 24);
      this.UPSpeed.TabIndex = 1;
      this.UPSpeed.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(3, 32);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(158, 20);
      this.label2.Text = "Speed (+ mm/s)";
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(3, 65);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(168, 20);
      this.label3.Text = "Acceleration (+ mm/s^2)";
      // 
      // UPAcceleration
      // 
      this.UPAcceleration.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.UPAcceleration.Location = new System.Drawing.Point(167, 61);
      this.UPAcceleration.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
      this.UPAcceleration.Name = "UPAcceleration";
      this.UPAcceleration.Size = new System.Drawing.Size(100, 24);
      this.UPAcceleration.TabIndex = 1;
      this.UPAcceleration.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
      // 
      // CommonRunParameters
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.Controls.Add(this.label2);
      this.Controls.Add(this.UPAcceleration);
      this.Controls.Add(this.UPSpeed);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.label3);
      this.Name = "CommonRunParameters";
      this.Size = new System.Drawing.Size(274, 93);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    public System.Windows.Forms.NumericUpDown UPSpeed;
    public System.Windows.Forms.NumericUpDown UPAcceleration;
  }
}
