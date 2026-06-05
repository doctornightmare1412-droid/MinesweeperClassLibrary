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

        string UseBombDefuseReward(BoardModel board, int row, int col);
    }
}
