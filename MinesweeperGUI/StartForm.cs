/*
 * Angelo Ellis
 * CST - 250
 * May 16 2026
 * Minesweeper
 * Milestone 4
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Updates the size label when the trackbar changes
        /// </summary>
        private void trackBarSize_Scroll(object sender, EventArgs e)
        {
            lblSize.Text = "Size: " + trackBarSize.Value;
        }

        /// <summary>
        /// Updates the difficulty label when the trackbar changes
        /// </summary>
        private void trackBarDifficulty_Scroll(object sender, EventArgs e)
        {
            lblDifficulty.Text = "Difficulty: " + trackBarDifficulty.Value + "%";
        }

        /// <summary>
        /// Starts the game
        /// </summary>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            int boardSize = trackBarSize.Value;
            int difficulty = trackBarDifficulty.Value;

            GameForm gameForm = new GameForm(boardSize, difficulty);

            gameForm.Show();

            this.Hide();
        }
    }
}