/*
 * Angelo Ellis
 * CST - 250
 * May 16 2026
 * Minesweeper
 * Milestone 4
 */

namespace MinesweeperGUI
{
    partial class GameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelBoard = new Panel();
            lblStartTime = new Label();
            lblScore = new Label();
            lblStatus = new Label();
            btnRestart = new Button();
            btnUseReward = new Button();
            lblRewards = new Label();
            SuspendLayout();
            // 
            // panelBoard
            // 
            panelBoard.BorderStyle = BorderStyle.FixedSingle;
            panelBoard.Location = new Point(43, 12);
            panelBoard.Name = "panelBoard";
            panelBoard.Size = new Size(545, 537);
            panelBoard.TabIndex = 0;
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Location = new Point(43, 689);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(127, 32);
            lblStartTime.TabIndex = 1;
            lblStartTime.Text = "Start Time:";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(549, 689);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(78, 32);
            lblScore.TabIndex = 2;
            lblScore.Text = "Score:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(297, 689);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(83, 32);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Status:";
            // 
            // btnRestart
            // 
            btnRestart.Location = new Point(52, 606);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(150, 46);
            btnRestart.TabIndex = 4;
            btnRestart.Text = "Restart";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Click += btnRestart_Click;
            // 
            // btnUseReward
            // 
            btnUseReward.Location = new Point(438, 606);
            btnUseReward.Name = "btnUseReward";
            btnUseReward.Size = new Size(150, 46);
            btnUseReward.TabIndex = 5;
            btnUseReward.Text = "Use Reward";
            btnUseReward.UseVisualStyleBackColor = true;
            btnUseReward.Click += btnUseReward_Click;
            // 
            // lblRewards
            // 
            lblRewards.AutoSize = true;
            lblRewards.Location = new Point(306, 613);
            lblRewards.Name = "lblRewards";
            lblRewards.Size = new Size(126, 32);
            lblRewards.TabIndex = 6;
            lblRewards.Text = "Rewards: 0";
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1110, 777);
            Controls.Add(lblRewards);
            Controls.Add(btnUseReward);
            Controls.Add(btnRestart);
            Controls.Add(lblStatus);
            Controls.Add(lblScore);
            Controls.Add(lblStartTime);
            Controls.Add(panelBoard);
            Name = "GameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Minesweeper GUI";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelBoard;
        private Button btnRestart;
        private Label lblStartTime;
        private Label lblScore;
        private Label lblStatus;
        private Button btnUseReward;
        private Label lblRewards;
    }
}
