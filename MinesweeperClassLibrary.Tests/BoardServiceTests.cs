/*
 * Angelo Ellis
 * CST - 250
 * May 16 2026
 * Minesweeper
 * Milestone 4
 */

using MinesweeperClassLibrary.Models;
using MinesweeperClassLibrary.Services.BusinessLogicLayer;

namespace MinesweeperClassLibrary.Tests
{
    public class BoardServiceTests
    {
        [Fact]
        public void CreateBoard_ShouldCreateBoardWithCorrectSize()
        {
            // Arrange
            BoardService boardService = new BoardService();

            // Act
            BoardModel board = boardService.CreateBoard(10);

            // Assert
            Assert.Equal(10, board.Size);
        }

        [Fact]
        public void CreateBoard_ShouldInitializeCells()
        {
            // Arrange
            BoardService boardService = new BoardService();

            // Act
            BoardModel board = boardService.CreateBoard(10);

            // Assert
            Assert.NotNull(board.Cells[0, 0]);
            Assert.Equal(0, board.Cells[0, 0].Row);
            Assert.Equal(0, board.Cells[0, 0].Column);
        }

        [Fact]
        public void SetupBombs_ShouldPlaceBombsOnBoard()
        {
            // Arrange
            BoardService boardService = new BoardService();
            BoardModel board = boardService.CreateBoard(10);

            // Act
            boardService.SetupBombs(board, 1);

            // Assert
            int bombCount = 0;

            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    if (board.Cells[row, col].IsBomb)
                    {
                        bombCount++;
                    }
                }
            }

            Assert.True(bombCount > 0);
        }

        [Fact]
        public void CountBombsNearby_ShouldSetBombCellsToNine()
        {
            // Arrange
            BoardService boardService = new BoardService();
            BoardModel board = boardService.CreateBoard(3);

            board.Cells[1, 1].IsBomb = true;

            // Act
            boardService.CountBombsNearby(board);

            // Assert
            Assert.Equal(9, board.Cells[1, 1].NumberOfBombNeighbors);
        }

        [Fact]
        public void DetermineGameState_ShouldReturnLost_WhenBombIsVisited()
        {
            // Arrange
            BoardService boardService = new BoardService();
            BoardModel board = boardService.CreateBoard(3);

            board.Cells[1, 1].IsBomb = true;
            board.Cells[1, 1].IsVisited = true;

            // Act
            string result = boardService.DetermineGameState(board);

            // Assert
            Assert.Equal("Lost", result);
        }

        [Fact]
        public void DetermineGameState_ShouldReturnStillPlaying_WhenSafeCellsRemain()
        {
            // Arrange
            BoardService boardService = new BoardService();
            BoardModel board = boardService.CreateBoard(3);

            // Act
            string result = boardService.DetermineGameState(board);

            // Assert
            Assert.Equal("StillPlaying", result);
        }

        [Fact]
        public void DetermineGameState_ShouldReturnWon_WhenAllSafeCellsAreVisitedOrFlagged()
        {
            // Arrange
            BoardService boardService = new BoardService();
            BoardModel board = boardService.CreateBoard(3);

            board.Cells[0, 0].IsBomb = true;

            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    if (!board.Cells[row, col].IsBomb)
                    {
                        board.Cells[row, col].IsVisited = true;
                    }
                }
            }

            board.Cells[1, 1].IsVisited = false;
            board.Cells[1, 1].IsFlagged = true;

            // Act
            string result = boardService.DetermineGameState(board);

            // Assert
            Assert.Equal("Won", result);
        }

        [Fact]
        public void FloodFill_ShouldVisitEmptyCells()
        {
            // Arrange
            BoardService boardService = new BoardService();
            BoardModel board = boardService.CreateBoard(5);

            // Act
            boardService.FloodFill(board, 0, 0);

            // Assert
            Assert.True(board.Cells[0, 0].IsVisited);
        }
    }
}