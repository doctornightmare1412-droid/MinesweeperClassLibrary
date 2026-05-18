namespace MinesweeperGUI
{
    partial class StartForm
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
            lblTitle = new Label();
            lblSize = new Label();
            lblDifficulty = new Label();
            trackBarDifficulty = new TrackBar();
            trackBarSize = new TrackBar();
            btnPlay = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBarDifficulty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarSize).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(29, 26);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(207, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Play Minesweeper";
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Location = new Point(65, 92);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(82, 32);
            lblSize.TabIndex = 1;
            lblSize.Text = "Size: 8";
            // 
            // lblDifficulty
            // 
            lblDifficulty.AutoSize = true;
            lblDifficulty.Location = new Point(65, 246);
            lblDifficulty.Name = "lblDifficulty";
            lblDifficulty.Size = new Size(155, 32);
            lblDifficulty.TabIndex = 2;
            lblDifficulty.Text = "Difficulty: 5%";
            // 
            // trackBarDifficulty
            // 
            trackBarDifficulty.Location = new Point(65, 291);
            trackBarDifficulty.Maximum = 20;
            trackBarDifficulty.Minimum = 1;
            trackBarDifficulty.Name = "trackBarDifficulty";
            trackBarDifficulty.Size = new Size(662, 90);
            trackBarDifficulty.TabIndex = 3;
            trackBarDifficulty.Value = 5;
            trackBarDifficulty.Scroll += trackBarDifficulty_Scroll;
            // 
            // trackBarSize
            // 
            trackBarSize.Location = new Point(65, 144);
            trackBarSize.Maximum = 15;
            trackBarSize.Minimum = 5;
            trackBarSize.Name = "trackBarSize";
            trackBarSize.Size = new Size(662, 90);
            trackBarSize.TabIndex = 4;
            trackBarSize.Value = 8;
            trackBarSize.Scroll += trackBarSize_Scroll;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(391, 387);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(150, 46);
            btnPlay.TabIndex = 5;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPlay);
            Controls.Add(trackBarSize);
            Controls.Add(trackBarDifficulty);
            Controls.Add(lblDifficulty);
            Controls.Add(lblSize);
            Controls.Add(lblTitle);
            Name = "StartForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Start a New Game";
            ((System.ComponentModel.ISupportInitialize)trackBarDifficulty).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarSize).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSize;
        private Label lblDifficulty;
        private TrackBar trackBarDifficulty;
        private TrackBar trackBarSize;
        private Button btnPlay;
    }
}