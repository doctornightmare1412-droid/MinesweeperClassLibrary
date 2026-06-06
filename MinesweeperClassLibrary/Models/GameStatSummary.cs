/*
 * Angelo Ellis
 * CST - 250
 * June 6 2026
 * Minesweeper
 * Milestone 6
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperClassLibrary.Models
{
    public class GameStatSummary : BaseModel
    {
        public int TotalGamesPlayed { get; set; }

        public double AverageScore { get; set; }

        public double AverageTimeInSeconds { get; set; }

        public int HighestScore { get; set; }

        public string BestPlayerName { get; set; }
    }
}
