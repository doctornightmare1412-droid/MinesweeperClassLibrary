/* 
 * Angelo Ellis
 * CST - 250
 * April 27 2026
 * Minesweeper
 * Milestone 1
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperClassLibrary.Models
{
    public class BoardModel
    {
        // Size of the board
        public int Size { get; set; }

        // Time when the game starts
        public DateTime StartTime { get; set; }

        // Time when the game ends
        public DateTime EndTime { get; set; }

        // 2D array of cells
        public CellModel[,] Cells { get; set; }

        // Difficulty level for the game
        public int Difficulty { get; set; }

        // Number of rewards the player has collected
        public int RewardsRemaining { get; set; }

        // Current state of the game
        public string GameState { get; set; }

        // Constructor
        public BoardModel(int size)
        {
            Size = size;
            StartTime = DateTime.Now;
            EndTime = DateTime.MinValue;
            Cells = new CellModel[size, size];
            Difficulty = 1;
            RewardsRemaining = 0;
            GameState = "StillPlaying";
        }
    }
}