/*
 * Angelo Ellis
 * CST - 250
 * May 24 2026
 * Minesweeper
 * Milestone 5
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MinesweeperClassLibrary.Models;
using MinesweeperClassLibrary.Services.DataAccessLayer;

namespace MinesweeperGUI
{
    public partial class HighScoresForm : Form
    {
        // Stores all high score records
        private List<GameStat> highScores = new List<GameStat>();

        // Data access object for saving and loading high scores
        private GameStatDAO gameStatDAO = new GameStatDAO();

        public HighScoresForm()
        {
            InitializeComponent();

            highScores = gameStatDAO.LoadScores();
            DisplayScores();
        }

        public HighScoresForm(List<GameStat> scores)
        {
            InitializeComponent();

            highScores = scores;
            DisplayScores();
        }

        /// <summary>
        /// Displays the high scores in the DataGridView
        /// </summary>
        private void DisplayScores()
        {
            dgvHighScores.DataSource = null;

            highScores = highScores
                .OrderByDescending(score => score.Score)
                .ThenBy(score => score.TimeInSeconds)
                .ToList();

            for (int i = 0; i < highScores.Count; i++)
            {
                highScores[i].Id = i + 1;
            }

            dgvHighScores.DataSource = highScores;

            dgvHighScores.Columns["Id"].HeaderText = "Place";
            dgvHighScores.Columns["Id"].DisplayIndex = 0;
            dgvHighScores.Columns["Name"].DisplayIndex = 1;
            dgvHighScores.Columns["Score"].DisplayIndex = 2;
            dgvHighScores.Columns["TimeInSeconds"].HeaderText = "Time";
            dgvHighScores.Columns["TimeInSeconds"].DisplayIndex = 3;
            dgvHighScores.Columns["GameTime"].HeaderText = "Date Played";
            dgvHighScores.Columns["GameTime"].DisplayIndex = 4;
        }

        /// <summary>
        /// Saves high scores to a text file
        /// </summary>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameStatDAO.SaveScores(highScores);
            MessageBox.Show("High scores saved.");
        }

        /// <summary>
        /// Loads high scores from a text file
        /// </summary>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            highScores = gameStatDAO.LoadScores();
            DisplayScores();
            MessageBox.Show("High scores loaded.");
        }

        /// <summary>
        /// Closes the high scores form
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Sorts high scores by player name
        /// </summary>
        private void byNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            highScores = highScores.OrderBy(score => score.Name).ToList();
            DisplayScores();
        }

        /// <summary>
        /// Sorts high scores by score
        /// </summary>
        private void byScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            highScores = highScores.OrderByDescending(score => score.Score).ToList();
            DisplayScores();
        }

        /// <summary>
        /// Sorts high scores by date
        /// </summary>
        private void byDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            highScores = highScores.OrderByDescending(score => score.GameTime).ToList();
            DisplayScores();
        }
    }
}
