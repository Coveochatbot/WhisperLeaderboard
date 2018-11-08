using Newtonsoft.Json;

namespace WhisperLeaderboard.Models
{
    public class ScoreDto
    {
        [JsonProperty("score")]
        public int Score { get; set; }
    }
}
