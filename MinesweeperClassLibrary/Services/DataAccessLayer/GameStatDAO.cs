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

namespace MinesweeperClassLibrary.Services.DataAccessLayer
{
    public class GameStatDAO
    {
        // File used to save and load high scores
        private string filePath = "highscores.txt";

        /// <summary>
        /// Saves the list of game statistics to a text file
        /// </summary>
        public void SaveScores(List<GameStat> scores)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (GameStat score in scores)
                {
                    writer.WriteLine(score.Id + "," + score.Name + "," + score.Score + "," + score.GameTime + "," + score.TimeInSeconds);
                }
            }
        }

        /// <summary>
        /// Loads the list of game statistics from a text file
        /// </summary>
        public List<GameStat> LoadScores()
        {
            List<GameStat> scores = new List<GameStat>();

            if (!File.Exists(filePath))
            {
                return scores;
            }

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 5)
                {
                    GameStat stat = new GameStat();

                    stat.Id = int.Parse(parts[0]);
                    stat.Name = parts[1];
                    stat.Score = int.Parse(parts[2]);
                    stat.GameTime = DateTime.Parse(parts[3]);
                    stat.TimeInSeconds = int.Parse(parts[4]);

                    scores.Add(stat);
                }
            }

            return scores;
        }
    }
}