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

namespace MinesweeperGUI
{
    public partial class PlayerNameForm : Form
    {
        // Stores the player's name entered on the form
        public string PlayerName { get; private set; }

        public PlayerNameForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Saves the player's name and closes the form
        /// </summary>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            PlayerName = txtPlayerName.Text.Trim();

            if (PlayerName == "")
            {
                MessageBox.Show("Please enter your name.");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}