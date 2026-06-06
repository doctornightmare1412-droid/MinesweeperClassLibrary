/*
 * Angelo Ellis
 * CST - 250
 * June 2026
 * Minesweeper
 * Milestone 6
 */

using System;
using System.Collections.Generic;
using System.Text;
using MinesweeperClassLibrary.Models;
using MinesweeperClassLibrary.Services.BusinessLogicLayer;
using Xunit;

namespace MinesweeperClassLibrary.Tests
{
    public class GameStatServiceTests
    {
        [Fact]
        public void CalculateSummary_ShouldReturnCorrectStats()
        {
            // Arrange
            GameStatService gameStatService = new GameStatService();

            List<GameStat> scores = new List<GameStat>
            {
                new GameStat
                {
                    Id = 1,
                    Name = "Angelo",
                    Score = 500,
                    GameTime = DateTime.Now,
                    TimeInSeconds = 60
                },
                new GameStat
                {
                    Id = 2,
                    Name = "Billy",
                    Score = 700,
                    GameTime = DateTime.Now,
                    TimeInSeconds = 30
                }
            };

            // Act
            GameStatSummary summary = gameStatService.CalculateSummary(scores);

            // Assert
            Assert.Equal(2, summary.TotalGamesPlayed);
            Assert.Equal(600, summary.AverageScore);
            Assert.Equal(45, summary.AverageTimeInSeconds);
            Assert.Equal(700, summary.HighestScore);
            Assert.Equal("Billy", summary.BestPlayerName);
        }

        [Fact]
        public void CalculateSummary_ShouldReturnZeroStats_WhenNoScoresExist()
        {
            // Arrange
            GameStatService gameStatService = new GameStatService();

            List<GameStat> scores = new List<GameStat>();

            // Act
            GameStatSummary summary = gameStatService.CalculateSummary(scores);

            // Assert
            Assert.Equal(0, summary.TotalGamesPlayed);
            Assert.Equal(0, summary.AverageScore);
            Assert.Equal(0, summary.AverageTimeInSeconds);
            Assert.Equal(0, summary.HighestScore);
            Assert.Equal("N/A", summary.BestPlayerName);
        }
    }
}