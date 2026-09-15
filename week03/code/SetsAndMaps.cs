using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

public static class SetsAndMaps
{
    /// <summary>
    /// Problem 1: Find symmetric pairs of two letter words in O(n) time using a set.
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var result = new List<string>();
        var addedPairs = new HashSet<string>();

        foreach (var w in words)
        {
            if (string.IsNullOrEmpty(w) || w.Length != 2)
                continue;

            char first = w[0];
            char second = w[1];

            if (first == second)
                continue;

            string reverse = new string(new[] { second, first });

            if (seen.Contains(reverse))
            {
                string pair = string.CompareOrdinal(w, reverse) < 0
                    ? $"{w} & {reverse}"
                    : $"{reverse} & {w}";

                if (addedPairs.Add(pair))
                {
                    result.Add(pair);
                }
            }

            seen.Add(w);
        }

        return result.ToArray();
    }

    /// <summary>
    /// Problem 2: Read census.txt and summarize degrees.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        if (!File.Exists(filename))
            return degrees;

        foreach (var line in File.ReadLines(filename))
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            var fields = line.Split(',');

            if (fields.Length <= 4)
                continue;

            string degree = fields[3].Trim().Trim('"');

            if (degree.Equals("education", StringComparison.OrdinalIgnoreCase))
                continue;

            if (string.IsNullOrWhiteSpace(degree))
                continue;

            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Problem 3: Determine if two words are anagrams.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        if (word1 == null || word2 == null)
            return false;

        string clean1 = word1.Replace(" ", "").ToLower();
        string clean2 = word2.Replace(" ", "").ToLower();

        if (clean1.Length != clean2.Length)
            return false;

        var counts = new Dictionary<char, int>();

        foreach (char c in clean1)
        {
            if (!counts.ContainsKey(c))
                counts[c] = 0;

            counts[c]++;
        }

        foreach (char c in clean2)
        {
            if (!counts.ContainsKey(c))
                return false;

            counts[c]--;

            if (counts[c] < 0)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Problem 5: Fetch today's earthquake summaries from USGS GeoJSON synchronously.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        string uri =
            "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();

        try
        {
            var response = client
                .GetAsync(uri)
                .GetAwaiter()
                .GetResult();

            if (!response.IsSuccessStatusCode)
                return Array.Empty<string>();

            var featureCollection = response.Content
                .ReadFromJsonAsync<FeatureDataContainer>()
                .GetAwaiter()
                .GetResult();

            if (featureCollection?.Features == null)
                return Array.Empty<string>();

            var summaries = new List<string>();

            foreach (var feature in featureCollection.Features)
            {
                string place =
                    feature.Properties?.Place ?? "Unknown Location";

                double magnitude =
                    feature.Properties?.Mag ?? 0.0;

                summaries.Add($"{place} - Mag {magnitude}");
            }

            return summaries.ToArray();
        }
        catch
        {
            return Array.Empty<string>();
        }
    }
}

public class FeatureDataContainer
{
    [JsonPropertyName("features")]
    public EarthquakeFeature[] Features { get; set; }
}

public class EarthquakeFeature
{
    [JsonPropertyName("properties")]
    public EarthquakeProperties Properties { get; set; }
}

public class EarthquakeProperties
{
    [JsonPropertyName("mag")]
    public double Mag { get; set; }

    [JsonPropertyName("place")]
    public string Place { get; set; }
}
