/*
 * Angelo Ellis
 * CST - 250
 * May 16 2026
 * Minesweeper
 * Milestone 4
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperClassLibrary.Models
{
    public class CellModel : BaseModel
    {
        // Row position of the cell
        public int Row { get; set; }

        // Column position of the cell
        public int Column { get; set; }

        // Shows if the player already visited this cell
        public bool IsVisited { get; set; }

        // Shows if this cell has a bomb
        public bool IsBomb { get; set; }

        // Shows if the player placed a flag on this cell
        public bool IsFlagged { get; set; }

        // Number of bombs around this cell
        public int NumberOfBombNeighbors { get; set; }

        // Shows if this cell has a special reward
        public bool HasSpecialReward { get; set; }
    }
}