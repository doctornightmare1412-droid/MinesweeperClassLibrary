/*
 * Angelo Ellis
 * CST - 250
 * May 16 2026
 * Minesweeper
 * Milestone 4
 */

using MinesweeperClassLibrary.Models;
using MinesweeperClassLibrary.Services.BusinessLogicLayer;

namespace MinesweeperConsoleApp
{
    internal class Program
    {
        /// <summary>
        /// Main method for the console application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Create the board service object
            BoardService boardService = new BoardService();

            // Create one game board
            BoardModel board = boardService.CreateBoard(10);
            board.Difficulty = 1;

            // Set up bombs and count nearby bombs
            boardService.SetupBombs(board, board.Difficulty);
            boardService.CountBombsNearby(board);

            // Set one special reward cell for testing
            board.Cells[1, 1].HasSpecialReward = true;

            // Show answer key first for testing
            Console.WriteLine("Hello, welcome to Minesweeper");
            Console.WriteLine("Here is the answer key for the first board");
            PrintAnswers(board);

            Console.WriteLine();
            Console.WriteLine("Here is the current board");
            PrintBoard(board);

            // Declare game loop variables
            bool victory = false;
            bool death = false;

            // Repeat until the game is over
            while (!victory && !death)
            {
                int row, col, choice;

                // Row input
                Console.Write("Enter the row number: ");
                while (!int.TryParse(Console.ReadLine(), out row) || row < 0 || row >= board.Size)
                {
                    Console.WriteLine("Invalid row. Try again.");
                    Console.Write("Enter the row number: ");
                }

                // Column input
                Console.Write("Enter the column number: ");
                while (!int.TryParse(Console.ReadLine(), out col) || col < 0 || col >= board.Size)
                {
                    Console.WriteLine("Invalid column. Try again.");
                    Console.Write("Enter the column number: ");
                }

                // Choice input
                Console.Write("Enter 1 to visit, 2 to flag, 3 to use a reward: ");
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
                {
                    Console.WriteLine("Invalid choice. Try again.");
                    Console.Write("Enter 1 to visit, 2 to flag, 3 to use a reward: ");
                }

                CellModel cell = board.Cells[row, col];

                if (choice == 1)
                {
                    // If the cell has zero bomb neighbors, use flood fill
                    if (!cell.IsBomb && cell.NumberOfBombNeighbors == 0)
                    {
                        boardService.FloodFill(board, row, col);
                    }
                    else
                    {
                        cell.IsVisited = true;
                    }

                    if (cell.HasSpecialReward)
                    {
                        board.RewardsRemaining++;
                        cell.HasSpecialReward = false;
                        Console.WriteLine("You found a reward!");
                    }
                }
                else if (choice == 2)
                {
                    cell.IsFlagged = true;
                }
                else if (choice == 3)
                {
                    if (board.RewardsRemaining > 0)
                    {
                        board.RewardsRemaining--;

                        if (cell.IsBomb)
                        {
                            Console.WriteLine("Reward used: This cell has a bomb.");
                        }
                        else
                        {
                            Console.WriteLine("Reward used: This cell is safe.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You do not have any rewards to use.");
                    }
                }

                string gameState = boardService.DetermineGameState(board);

                if (gameState == "Won")
                {
                    victory = true;
                }
                else if (gameState == "Lost")
                {
                    death = true;
                }

                Console.WriteLine();
                Console.WriteLine("Here is the current board");
                PrintBoard(board);
            }

            Console.WriteLine();

            if (victory)
            {
                Console.WriteLine("Congratulations, you won!");
            }
            else if (death)
            {
                Console.WriteLine("Game over. You hit a bomb.");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Print the answers for the minesweeper board
        /// </summary>
        /// <param name="board"></param>
        static void PrintAnswers(BoardModel board)
        {
            // Print column numbers
            Console.Write("    ");
            for (int col = 0; col < board.Size; col++)
            {
                Console.Write($"{col,3}");
            }

            Console.WriteLine();

            // Print divider line
            Console.Write("    ");
            for (int col = 0; col < board.Size; col++)
            {
                Console.Write("---");
            }

            Console.WriteLine();

            // Loop through each row
            for (int row = 0; row < board.Size; row++)
            {
                // Print row number
                Console.Write($"{row,2} |");

                // Loop through each column
                for (int col = 0; col < board.Size; col++)
                {
                    CellModel cell = board.Cells[row, col];

                    // Print B if the cell is a bomb
                    if (cell.IsBomb)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" B ");
                    }
                    // Print a dot if there are no bombs nearby
                    else if (cell.NumberOfBombNeighbors == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(" . ");
                    }
                    // Print the number of bombs nearby
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($" {cell.NumberOfBombNeighbors} ");
                    }

                    // Reset the color after each cell
                    Console.ResetColor();
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print the current game board for the player
        /// </summary>
        /// <param name="board"></param>
        static void PrintBoard(BoardModel board)
        {
            // Print column numbers
            Console.Write("    ");
            for (int col = 0; col < board.Size; col++)
            {
                Console.Write($"{col,3}");
            }

            Console.WriteLine();

            // Print divider line
            Console.Write("    ");
            for (int col = 0; col < board.Size; col++)
            {
                Console.Write("---");
            }

            Console.WriteLine();

            // Loop through each row
            for (int row = 0; row < board.Size; row++)
            {
                // Print row number
                Console.Write($"{row,2} |");

                // Loop through each column
                for (int col = 0; col < board.Size; col++)
                {
                    CellModel cell = board.Cells[row, col];

                    if (cell.IsFlagged)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" F ");
                    }
                    else if (!cell.IsVisited)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(" ? ");
                    }
                    else if (cell.IsBomb)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" B ");
                    }
                    else if (cell.NumberOfBombNeighbors == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(" . ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($" {cell.NumberOfBombNeighbors} ");
                    }

                    Console.ResetColor();
                }

                Console.WriteLine();
            }
        } // End of PrintBoard method
    }
}