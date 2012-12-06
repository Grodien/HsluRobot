namespace Testat2_GUIWin7
{
  partial class FormDriveControl
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
      this.grpBoxCommands = new System.Windows.Forms.GroupBox();
      this.runTurnView1 = new RobotUI.RunTurnView();
      this.runArcView1 = new RobotUI.RunArcView();
      this.runLineView1 = new RobotUI.RunLineView();
      this.grpBoxRobot = new System.Windows.Forms.GroupBox();
      this.btnConnect = new System.Windows.Forms.Button();
      this.btnStart = new System.Windows.Forms.Button();
      this.lsbCommands = new System.Windows.Forms.ListBox();
      this.grpBoxCommands.SuspendLayout();
      this.grpBoxRobot.SuspendLayout();
      this.SuspendLayout();
      // 
      // grpBoxCommands
      // 
      this.grpBoxCommands.Controls.Add(this.runTurnView1);
      this.grpBoxCommands.Controls.Add(this.runArcView1);
      this.grpBoxCommands.Controls.Add(this.runLineView1);
      this.grpBoxCommands.Location = new System.Drawing.Point(12, 12);
      this.grpBoxCommands.Name = "grpBoxCommands";
      this.grpBoxCommands.Size = new System.Drawing.Size(271, 319);
      this.grpBoxCommands.TabIndex = 3;
      this.grpBoxCommands.TabStop = false;
      this.grpBoxCommands.Text = "Commands";
      // 
      // runTurnView1
      // 
      this.runTurnView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.runTurnView1.ButtonText = "Add";
      this.runTurnView1.Location = new System.Drawing.Point(6, 108);
      this.runTurnView1.Name = "runTurnView1";
      this.runTurnView1.Size = new System.Drawing.Size(257, 84);
      this.runTurnView1.TabIndex = 1;
      this.runTurnView1.StartClicked += new System.EventHandler(this.RunTurnView1StartClicked);
      // 
      // runArcView1
      // 
      this.runArcView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.runArcView1.ButtonText = "Add";
      this.runArcView1.Location = new System.Drawing.Point(6, 198);
      this.runArcView1.Name = "runArcView1";
      this.runArcView1.Size = new System.Drawing.Size(257, 111);
      this.runArcView1.TabIndex = 2;
      this.runArcView1.StartClicked += new System.EventHandler(this.RunArcView1StartClicked);
      // 
      // runLineView1
      // 
      this.runLineView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.runLineView1.ButtonText = "Add";
      this.runLineView1.Location = new System.Drawing.Point(6, 18);
      this.runLineView1.Name = "runLineView1";
      this.runLineView1.Size = new System.Drawing.Size(257, 84);
      this.runLineView1.TabIndex = 0;
      this.runLineView1.StartClicked += new System.EventHandler(this.RunLineView1StartClicked);
      // 
      // grpBoxRobot
      // 
      this.grpBoxRobot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.grpBoxRobot.Controls.Add(this.btnConnect);
      this.grpBoxRobot.Controls.Add(this.btnStart);
      this.grpBoxRobot.Controls.Add(this.lsbCommands);
      this.grpBoxRobot.Location = new System.Drawing.Point(289, 14);
      this.grpBoxRobot.Name = "grpBoxRobot";
      this.grpBoxRobot.Size = new System.Drawing.Size(309, 317);
      this.grpBoxRobot.TabIndex = 4;
      this.grpBoxRobot.TabStop = false;
      this.grpBoxRobot.Text = "Robot";
      // 
      // btnConnect
      // 
      this.btnConnect.Location = new System.Drawing.Point(6, 16);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.Size = new System.Drawing.Size(75, 23);
      this.btnConnect.TabIndex = 3;
      this.btnConnect.Text = "Connect";
      this.btnConnect.UseVisualStyleBackColor = true;
      this.btnConnect.Click += new System.EventHandler(this.BtnConnectClick);
      // 
      // btnStart
      // 
      this.btnStart.Location = new System.Drawing.Point(87, 16);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new System.Drawing.Size(75, 23);
      this.btnStart.TabIndex = 2;
      this.btnStart.Text = "Start";
      this.btnStart.UseVisualStyleBackColor = true;
      this.btnStart.Click += new System.EventHandler(this.BtnStartClick);
      // 
      // lsbCommands
      // 
      this.lsbCommands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lsbCommands.FormattingEnabled = true;
      this.lsbCommands.Location = new System.Drawing.Point(6, 45);
      this.lsbCommands.Name = "lsbCommands";
      this.lsbCommands.Size = new System.Drawing.Size(297, 264);
      this.lsbCommands.TabIndex = 1;
      this.lsbCommands.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LsbCommandsKeyDown);
      // 
      // FormDriveControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(610, 343);
      this.Controls.Add(this.grpBoxRobot);
      this.Controls.Add(this.grpBoxCommands);
      this.Name = "FormDriveControl";
      this.Text = "FormDriveControl";
      this.grpBoxCommands.ResumeLayout(false);
      this.grpBoxRobot.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private RobotUI.RunLineView runLineView1;
    private RobotUI.RunTurnView runTurnView1;
    private RobotUI.RunArcView runArcView1;
    private System.Windows.Forms.GroupBox grpBoxCommands;
    private System.Windows.Forms.GroupBox grpBoxRobot;
    private System.Windows.Forms.ListBox lsbCommands;
    private System.Windows.Forms.Button btnConnect;
    private System.Windows.Forms.Button btnStart;
  }
}

