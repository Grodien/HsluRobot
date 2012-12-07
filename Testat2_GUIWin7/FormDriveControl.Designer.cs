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
      this.btnRefresh = new System.Windows.Forms.Button();
      this.btnConnect = new System.Windows.Forms.Button();
      this.btnStart = new System.Windows.Forms.Button();
      this.lsbCommands = new System.Windows.Forms.ListBox();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.grpBoxCommands.SuspendLayout();
      this.grpBoxRobot.SuspendLayout();
      this.statusStrip1.SuspendLayout();
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
      this.runTurnView1.Enabled = false;
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
      this.runArcView1.Enabled = false;
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
      this.runLineView1.Enabled = false;
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
      this.grpBoxRobot.Controls.Add(this.btnRefresh);
      this.grpBoxRobot.Controls.Add(this.btnConnect);
      this.grpBoxRobot.Controls.Add(this.btnStart);
      this.grpBoxRobot.Controls.Add(this.lsbCommands);
      this.grpBoxRobot.Location = new System.Drawing.Point(289, 14);
      this.grpBoxRobot.Name = "grpBoxRobot";
      this.grpBoxRobot.Size = new System.Drawing.Size(322, 317);
      this.grpBoxRobot.TabIndex = 4;
      this.grpBoxRobot.TabStop = false;
      this.grpBoxRobot.Text = "Robot";
      // 
      // btnRefresh
      // 
      this.btnRefresh.Location = new System.Drawing.Point(6, 16);
      this.btnRefresh.Name = "btnRefresh";
      this.btnRefresh.Size = new System.Drawing.Size(75, 23);
      this.btnRefresh.TabIndex = 4;
      this.btnRefresh.Text = "Search";
      this.btnRefresh.UseVisualStyleBackColor = true;
      this.btnRefresh.Click += new System.EventHandler(this.BtnRefreshClick);
      // 
      // btnConnect
      // 
      this.btnConnect.Enabled = false;
      this.btnConnect.Location = new System.Drawing.Point(87, 16);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.Size = new System.Drawing.Size(75, 23);
      this.btnConnect.TabIndex = 3;
      this.btnConnect.Text = "Connect";
      this.btnConnect.UseVisualStyleBackColor = true;
      this.btnConnect.Click += new System.EventHandler(this.BtnConnectClick);
      // 
      // btnStart
      // 
      this.btnStart.Enabled = false;
      this.btnStart.Location = new System.Drawing.Point(241, 16);
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
      this.lsbCommands.Size = new System.Drawing.Size(310, 264);
      this.lsbCommands.TabIndex = 1;
      this.lsbCommands.SelectedIndexChanged += new System.EventHandler(this.LsbCommandsSelectedIndexChanged);
      this.lsbCommands.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LsbCommandsKeyDown);
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
      this.statusStrip1.Location = new System.Drawing.Point(0, 335);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(623, 22);
      this.statusStrip1.TabIndex = 5;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // statusLabel
      // 
      this.statusLabel.Name = "statusLabel";
      this.statusLabel.Size = new System.Drawing.Size(39, 17);
      this.statusLabel.Text = "Ready";
      // 
      // FormDriveControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(623, 357);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.grpBoxRobot);
      this.Controls.Add(this.grpBoxCommands);
      this.Name = "FormDriveControl";
      this.Text = "FormDriveControl";
      this.grpBoxCommands.ResumeLayout(false);
      this.grpBoxRobot.ResumeLayout(false);
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

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
    private System.Windows.Forms.Button btnRefresh;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel statusLabel;
  }
}

