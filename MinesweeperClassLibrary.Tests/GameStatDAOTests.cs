/*
 * Angelo Ellis
 * CST - 250
 * May 24 2026
 * Minesweeper
 * Milestone 5
 */

using System;
using System.Collections.Generic;
using System.IO;
using MinesweeperClassLibrary.Models;
using MinesweeperClassLibrary.Services.DataAccessLayer;
using Xunit;

namespace MinesweeperClassLibrary.Tests
{
    public class GameStatDAOTests
    {
        [Fact]
        public void SaveScores_ShouldCreateHighScoresFile()
        {
            // Arrange
            GameStatDAO dao = new GameStatDAO();

            List<GameStat> scores = new List<GameStat>
            {
                new GameStat
                {
                    Id = 1,
                    Name = "TestPlayer",
                    Score = 500,
                    GameTime = DateTime.Now,
                    TimeInSeconds = 45
                }
            };

            // Act
            dao.SaveScores(scores);

            // Assert
            Assert.True(File.Exists("highscores.txt"));
        }

        [Fact]
        public void LoadScores_ShouldReturnSavedScore()
        {
            // Arrange
            GameStatDAO dao = new GameStatDAO();

            List<GameStat> scores = new List<GameStat>
            {
                new GameStat
                {
                    Id = 1,
                    Name = "TestPlayer",
                    Score = 500,
                    GameTime = DateTime.Now,
                    TimeInSeconds = 45
                }
            };

            dao.SaveScores(scores);

            // Act
            List<GameStat> loadedScores = dao.LoadScores();

            // Assert
            Assert.NotEmpty(loadedScores);
            Assert.Equal("TestPlayer", loadedScores[0].Name);
            Assert.Equal(500, loadedScores[0].Score);
            Assert.Equal(45, loadedScores[0].TimeInSeconds);
        }
    }
}