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
            if (string.IsNullOrEmpty(w) || w.Length != 2) continue;
            if (w[0] == w[1]) continue; // Skip identical letters like "aa"

            char[] charArray = w.ToCharArray();
            Array.Reverse(charArray);
            string rev = new string(charArray);

            if (seen.Contains(rev))
            {
                string pair = string.Compare(w, rev) < 0 ? $"{w} & {rev}" : $"{rev} & {w}";
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
    /// Problem 2: Read census.txt and summarize degrees found in column 4.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        if (File.Exists(filename))
        {
            foreach (var line in File.ReadLines(filename))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var fields = line.Split(',');
                
                // Column 4 is standard for the education/degree field in CSE 212 census.txt
                if (fields.Length > 4)
                {
                    string degree = fields[4].Trim().Trim('"');
                    
                    if (!string.IsNullOrEmpty(degree) && !degree.Equals("education", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!degrees.ContainsKey(degree))
                        {
                            degrees[degree] = 0;
                        }
                        degrees[degree]++;
                    }
                }
            }
        }

        return degrees;
    }

    /// <summary>
    /// Problem 3: Determine if two words are anagrams (ignoring spaces and case).
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        if (word1 == null || word2 == null) return false;

        var clean1 = word1.Replace(" ", "").ToLower();
        var clean2 = word2.Replace(" ", "").ToLower();

        if (clean1.Length != clean2.Length) return false;

        var counts = new Dictionary<char, int>();
        foreach (var c in clean1)
        {
            if (!counts.ContainsKey(c)) counts[c] = 0;
            counts[c]++;
        }

        foreach (var c in clean2)
        {
            if (!counts.ContainsKey(c)) return false;
            counts[c]--;
            if (counts[c] < 0) return false;
        }

        return true;
    }

    /// <summary>
    /// Problem 5: Fetch today's earthquake summaries from USGS GeoJSON synchronously.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        
        try
        {
            var response = client.GetAsync(uri).GetAwaiter().GetResult();
            if (!response.IsSuccessStatusCode)
                return Array.Empty<string>();

            var featureCollection = response.Content.ReadFromJsonAsync<FeatureDataContainer>().GetAwaiter().GetResult();

            if (featureCollection?.Features == null)
                return Array.Empty<string>();

            var summaries = new List<string>();
            foreach (var feature in featureCollection.Features)
            {
                string place = feature.Properties?.Place ?? "Unknown Location";
                double mag = feature.Properties?.Mag ?? 0.0;
                summaries.Add($"{place} - Mag {mag}");
            }

            return summaries.ToArray();
        }
        catch
        {
            return Array.Empty<string>();
        }
    }
}

// JSON Deserialization classes
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
