/*
 * Angelo Ellis
 * CST - 250
 * June 6 2026
 * Minesweeper
 * Milestone 6
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MinesweeperClassLibrary.Models;

namespace MinesweeperClassLibrary.Services.BusinessLogicLayer
{
    public class GameStatService
    {
        /// <summary>
        /// Calculates summary statistics for the high score screen
        /// </summary>
        /// <param name="scores"></param>
        /// <returns></returns>
        public GameStatSummary CalculateSummary(List<GameStat> scores)
        {
            GameStatSummary summary = new GameStatSummary();

            if (scores == null || scores.Count == 0)
            {
                summary.TotalGamesPlayed = 0;
                summary.AverageScore = 0;
                summary.AverageTimeInSeconds = 0;
                summary.HighestScore = 0;
                summary.BestPlayerName = "N/A";

                return summary;
            }

            GameStat bestScore = scores
                .OrderByDescending(score => score.Score)
                .ThenBy(score => score.TimeInSeconds)
                .First();

            summary.TotalGamesPlayed = scores.Count;
            summary.AverageScore = scores.Average(score => score.Score);
            summary.AverageTimeInSeconds = scores.Average(score => score.TimeInSeconds);
            summary.HighestScore = bestScore.Score;
            summary.BestPlayerName = bestScore.Name;

            return summary;
        }
    }
}
