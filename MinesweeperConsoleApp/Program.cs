/* 
 * Angelo Ellis
 * CST - 250
 * April 27 2026
 * Minesweeper
 * Milestone 1
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

            // Create a size 10 board
            BoardModel boardSizeTen = boardService.CreateBoard(10);
            boardSizeTen.Difficulty = 1;

            // Set up bombs and count nearby bombs for size 10 board
            boardService.SetupBombs(boardSizeTen, boardSizeTen.Difficulty);
            boardService.CountBombsNearby(boardSizeTen);

            // Print the size 10 board
            Console.WriteLine("Minesweeper Board Size 10");
            PrintAnswers(boardSizeTen);

            Console.WriteLine();

            // Create a size 15 board
            BoardModel boardSizeFifteen = boardService.CreateBoard(15);
            boardSizeFifteen.Difficulty = 2;

            // Set up bombs and count nearby bombs for size 15 board
            boardService.SetupBombs(boardSizeFifteen, boardSizeFifteen.Difficulty);
            boardService.CountBombsNearby(boardSizeFifteen);

            // Print the size 15 board
            Console.WriteLine("Minesweeper Board Size 15");
            PrintAnswers(boardSizeFifteen);

            // Keep the console window open
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
    }
}