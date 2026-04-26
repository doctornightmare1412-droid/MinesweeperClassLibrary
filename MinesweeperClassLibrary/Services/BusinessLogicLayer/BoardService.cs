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
using MinesweeperClassLibrary.Models;

namespace MinesweeperClassLibrary.Services.BusinessLogicLayer
{
    public class BoardService
    {
        /// <summary>
        /// Creates and initializes the board
        /// </summary>
        public BoardModel CreateBoard(int size)
        {
            // Create the board
            BoardModel board = new BoardModel(size);

            // Loop through rows and columns
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    // Create each cell
                    board.Cells[row, col] = new CellModel();

                    // Set position
                    board.Cells[row, col].Row = row;
                    board.Cells[row, col].Column = col;

                    // Default values
                    board.Cells[row, col].IsVisited = false;
                    board.Cells[row, col].IsBomb = false;
                    board.Cells[row, col].IsFlagged = false;
                    board.Cells[row, col].NumberOfBombNeighbors = 0;
                    board.Cells[row, col].HasSpecialReward = false;
                }
            }

            return board;
        }

        /// <summary>
        /// Randomly place bombs on the board
        /// </summary>
        public void SetupBombs(BoardModel board, int difficulty)
        {
            Random rand = new Random();

            int bombsToPlace = difficulty * 5;

            int size = board.Size;

            int bombsPlaced = 0;

            // Keep placing bombs until we reach the amount
            while (bombsPlaced < bombsToPlace)
            {
                int row = rand.Next(size);
                int col = rand.Next(size);

                // Only place bomb if there is not one already
                if (!board.Cells[row, col].IsBomb)
                {
                    board.Cells[row, col].IsBomb = true;
                    bombsPlaced++;
                }
            }
        }

        /// <summary>
        /// Count the bombs around each cell
        /// </summary>
        public void CountBombsNearby(BoardModel board)
        {
            int size = board.Size;

            // Loop through every cell on the board
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    // If this cell is a bomb, set neighbor count to 9
                    if (board.Cells[row, col].IsBomb)
                    {
                        board.Cells[row, col].NumberOfBombNeighbors = 9;
                    }
                    else
                    {
                        int bombCount = 0;

                        // Check the cells around the current cell
                        for (int checkRow = row - 1; checkRow <= row + 1; checkRow++)
                        {
                            for (int checkCol = col - 1; checkCol <= col + 1; checkCol++)
                            {
                                // Make sure the row and column are inside the board
                                if (checkRow >= 0 && checkRow < size && checkCol >= 0 && checkCol < size)
                                {
                                    // Do not count the current cell
                                    if (!(checkRow == row && checkCol == col))
                                    {
                                        if (board.Cells[checkRow, checkCol].IsBomb)
                                        {
                                            bombCount++;
                                        }
                                    }
                                }
                            }
                        }

                        board.Cells[row, col].NumberOfBombNeighbors = bombCount;
                    }
                }
            }
        }
    }
}