using Newtonsoft.Json;
using System;

namespace WhisperLeaderboard.Models
{
    public class Entry : IEquatable<Entry>
    {
        [JsonProperty("name1")]
        public string Name1 { get; }
        [JsonProperty("name2")]
        public string Name2 { get; }
        [JsonProperty("score")]
        public int Score { get; }

        public Entry(string name1, string name2, int score)
        {
            Name1 = name1;
            Name2 = name2;
            Score = score;
        }

        public bool Equals(Entry other)
        {
            return Name1.Equals(other.Name1) && Name2.Equals(other.Name2) && Score == other.Score;
        }
    }
}
