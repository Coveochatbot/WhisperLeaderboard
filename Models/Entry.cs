using Newtonsoft.Json;
using WhisperLeaderboard.Models.Dto.Game;

namespace WhisperLeaderboard.Models
{
    public class Entry
    {
        [JsonProperty("name1")]
        public string Name1 { get; }
        [JsonProperty("name2")]
        public string Name2 { get; }
        [JsonProperty("score")]
        public int Score { get; }
        [JsonProperty("mode")]
        public GameMode Mode { get; }

        public Entry(string name1, string name2, int score, GameMode mode)
        {
            Name1 = name1;
            Name2 = name2;
            Score = score;
            Mode = mode;
        }

        public bool Equals(Entry other)
        {
            return Name1.Equals(other.Name1) && Name2.Equals(other.Name2) && Score == other.Score && Mode == other.Mode;
        }
    }
}
