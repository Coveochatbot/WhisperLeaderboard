using Newtonsoft.Json;
using System.Collections.Generic;

namespace WhisperLeaderboard.Models.Dto
{
    public class LeaderboardDto
    {
        [JsonProperty("entries")]
        public List<Entry> Entries { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
    }
}
