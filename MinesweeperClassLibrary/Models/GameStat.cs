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
    public class GameStat : BaseModel
    {
        public string Name { get; set; }

        public int Score { get; set; }

        public DateTime GameTime { get; set; }

        public int TimeInSeconds { get; set; }

        public string FormattedTime
        {
            get
            {
                int minutes = TimeInSeconds / 60;
                int seconds = TimeInSeconds % 60;

                return minutes.ToString("00") + ":" + seconds.ToString("00");
            }
        }
    }
}
