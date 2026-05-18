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
using MinesweeperClassLibrary.Models;

namespace MinesweeperClassLibrary.Services.BusinessLogicLayer
{
    public interface IBoardService
    {
        BoardModel CreateBoard(int size);

        void SetupBombs(BoardModel board, int difficulty);

        void CountBombsNearby(BoardModel board);

        string DetermineGameState(BoardModel board);

        void FloodFill(BoardModel board, int row, int col);
    }
}
