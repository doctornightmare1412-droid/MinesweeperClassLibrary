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
    public class BoardService : IBoardService
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

            int bombsToPlace = board.Size * board.Size * difficulty / 100;

            if (bombsToPlace < 1)
            {
                bombsToPlace = 1;
            }

            if (bombsToPlace >= board.Size * board.Size)
            {
                bombsToPlace = board.Size * board.Size - 1;
            }

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

        /// <summary>
        /// Determine if the player won, lost, or is still playing
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public string DetermineGameState(BoardModel board)
        {
            bool safeCellsRemain = false;

            // Loop through every cell on the board
            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    CellModel cell = board.Cells[row, col];

                    // If a bomb cell was visited, the player loses
                    if (cell.IsBomb && cell.IsVisited)
                    {
                        board.GameState = "Lost";
                        return "Lost";
                    }

                    // Check if there are still safe cells left to visit or correctly flag
                    if (!cell.IsBomb && !cell.IsVisited && !cell.IsFlagged)
                    {
                        safeCellsRemain = true;
                    }
                }
            }

            // If any safe cells remain, the game continues
            if (safeCellsRemain)
            {
                board.GameState = "StillPlaying";
                return "StillPlaying";
            }

            // If all safe cells are visited, the player wins
            board.GameState = "Won";
            return "Won";
        } // End of DetermineGameState method

        /// <summary>
        /// Recursively reveals empty cells and nearby neighbors
        /// </summary>
        /// <param name="board"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void FloodFill(BoardModel board, int row, int col)
        {
            // Check if row or column is outside the board
            if (row < 0 || row >= board.Size || col < 0 || col >= board.Size)
            {
                return;
            }

            // Get the current cell
            CellModel cell = board.Cells[row, col];

            // Stop if the cell was already visited
            if (cell.IsVisited)
            {
                return;
            }

            // Stop if the cell is flagged
            if (cell.IsFlagged)
            {
                return;
            }

            // Stop if the cell is a bomb
            if (cell.IsBomb)
            {
                return;
            }

            // Visit the current cell
            cell.IsVisited = true;

            // Stop recursion if neighboring bombs exist
            if (cell.NumberOfBombNeighbors > 0)
            {
                return;
            }

            // Recursive calls in all 8 directions
            FloodFill(board, row - 1, col);     // North
            FloodFill(board, row + 1, col);     // South
            FloodFill(board, row, col - 1);     // West
            FloodFill(board, row, col + 1);     // East
            FloodFill(board, row - 1, col - 1); // Northwest
            FloodFill(board, row - 1, col + 1); // Northeast
            FloodFill(board, row + 1, col - 1); // Southwest
            FloodFill(board, row + 1, col + 1); // Southeast
        }
    }
}