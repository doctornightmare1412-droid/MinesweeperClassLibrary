/*
 * Angelo Ellis
 * CST - 250
 * May 24 2026
 * Minesweeper
 * Milestone 5
 */

namespace MinesweeperGUI
{
    partial class PlayerNameForm
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
            lblPlayerName = new Label();
            txtPlayerName = new TextBox();
            btnSubmit = new Button();
            SuspendLayout();
            // 
            // lblPlayerName
            // 
            lblPlayerName.AutoSize = true;
            lblPlayerName.Location = new Point(79, 177);
            lblPlayerName.Name = "lblPlayerName";
            lblPlayerName.Size = new Size(196, 32);
            lblPlayerName.TabIndex = 0;
            lblPlayerName.Text = "Enter your name:";
            // 
            // txtPlayerName
            // 
            txtPlayerName.Location = new Point(281, 170);
            txtPlayerName.Name = "txtPlayerName";
            txtPlayerName.Size = new Size(274, 39);
            txtPlayerName.TabIndex = 1;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(573, 166);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(150, 46);
            btnSubmit.TabIndex = 2;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // PlayerNameForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSubmit);
            Controls.Add(txtPlayerName);
            Controls.Add(lblPlayerName);
            Name = "PlayerNameForm";
            Text = "Enter Player Name";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPlayerName;
        private TextBox txtPlayerName;
        private Button btnSubmit;
    }
}