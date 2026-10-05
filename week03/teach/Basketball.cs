using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace week03.teach;

public static class Basketball
{
    public static void Run()
    {
        var playerPoints = new Dictionary<string, int>();

        string filePath = "week03/teach/basketball.csv";
        if (!File.Exists(filePath))
        {
            filePath = "basketball.csv";
        }

        if (File.Exists(filePath))
        {
            using var reader = new StreamReader(filePath);
            bool header = true;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (header)
                {
                    header = false;
                    continue;
                }

                var values = line.Split(',');
                if (values.Length > 8)
                {
                    string playerId = values[0];
                    if (int.TryParse(values[8], out int points))
                    {
                        if (!playerPoints.ContainsKey(playerId))
                        {
                            playerPoints[playerId] = 0;
                        }
                        playerPoints[playerId] += points;
                    }
                }
            }
        }

        var topPlayers = playerPoints
            .OrderByDescending(p => p.Value)
            .Take(10);

        Console.WriteLine("Top 10 NBA Players by Total Points:");
        foreach (var player in topPlayers)
        {
            Console.WriteLine($"Player: {player.Key}, Total Points: {player.Value}");
        }
    }
}
