/*
 * Angelo Ellis
 * CST - 250
 * June 6 2026
 * Minesweeper
 * Milestone 6
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
using MinesweeperClassLibrary.Services.BusinessLogicLayer;

namespace MinesweeperGUI
{
    public partial class HighScoresForm : Form
    {
        // Stores all high score records
        private List<GameStat> highScores = new List<GameStat>();

        // Data access object for saving and loading high scores
        private GameStatDAO gameStatDAO = new GameStatDAO();

        // Business logic service used to calculate summary statistics
        private GameStatService gameStatService = new GameStatService();

        // Summary stat controls
        private Panel summaryPanel;
        private Label lblTotalGames;
        private Label lblAverageScore;
        private Label lblAverageTime;
        private Label lblHighestScore;
        private Label lblBestPlayer;

        public HighScoresForm()
        {
            InitializeComponent();

            SetupSummaryPanel();

            highScores = gameStatDAO.LoadScores();
            DisplayScores();
        }

        public HighScoresForm(List<GameStat> scores)
        {
            InitializeComponent();

            SetupSummaryPanel();

            highScores = scores;
            DisplayScores();
        }

        /// <summary>
        /// Creates the summary panel used for enhanced statistics
        /// </summary>
        private void SetupSummaryPanel()
        {
            summaryPanel = new Panel();
            summaryPanel.Dock = DockStyle.Bottom;
            summaryPanel.Height = 150;
            summaryPanel.Padding = new Padding(10);
            summaryPanel.BackColor = Color.LightGray;

            lblTotalGames = new Label();
            lblTotalGames.AutoSize = true;
            lblTotalGames.Location = new Point(15, 15);

            lblAverageScore = new Label();
            lblAverageScore.AutoSize = true;
            lblAverageScore.Location = new Point(15, 45);

            lblAverageTime = new Label();
            lblAverageTime.AutoSize = true;
            lblAverageTime.Location = new Point(15, 75);

            lblHighestScore = new Label();
            lblHighestScore.AutoSize = true;
            lblHighestScore.Location = new Point(350, 15);

            lblBestPlayer = new Label();
            lblBestPlayer.AutoSize = true;
            lblBestPlayer.Location = new Point(350, 45);

            summaryPanel.Controls.Add(lblTotalGames);
            summaryPanel.Controls.Add(lblAverageScore);
            summaryPanel.Controls.Add(lblAverageTime);
            summaryPanel.Controls.Add(lblHighestScore);
            summaryPanel.Controls.Add(lblBestPlayer);

            Controls.Add(summaryPanel);
        }

        /// <summary>
        /// Displays summary statistics under the high score table
        /// </summary>
        private void DisplaySummaryStats()
        {
            GameStatSummary summary = gameStatService.CalculateSummary(highScores);

            lblTotalGames.Text = "Total Games Played: " + summary.TotalGamesPlayed;
            lblAverageScore.Text = "Average Score: " + summary.AverageScore.ToString("0.00");
            lblAverageTime.Text = "Average Time: " + FormatTime((int)summary.AverageTimeInSeconds);
            lblHighestScore.Text = "Highest Score: " + summary.HighestScore;
            lblBestPlayer.Text = "Best Player: " + summary.BestPlayerName;
        }

        /// <summary>
        /// Formats time in seconds to a MM:SS format for display
        /// </summary>
        /// <param name="totalSeconds"></param>
        /// <returns></returns>
        private string FormatTime(int totalSeconds)
        {
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            return minutes.ToString("00") + ":" + seconds.ToString("00");
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
            dgvHighScores.Columns["TimeInSeconds"].Visible = false;

            dgvHighScores.Columns["FormattedTime"].HeaderText = "Time";
            dgvHighScores.Columns["FormattedTime"].DisplayIndex = 3;

            dgvHighScores.Columns["GameTime"].HeaderText = "Date Played";
            dgvHighScores.Columns["GameTime"].DisplayIndex = 4;

            DisplaySummaryStats();
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
