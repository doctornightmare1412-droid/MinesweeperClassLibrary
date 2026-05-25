/*
 * Angelo Ellis
 * CST - 250
 * May 24 2026
 * Minesweeper
 * Milestone 5
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperClassLibrary.Models
{
    public class GameStat : BaseModel
    {
        public string Name { get; set; }

        public int Score { get; set; }

        public DateTime GameTime { get; set; }

        public int TimeInSeconds { get; set; }
    }
}
