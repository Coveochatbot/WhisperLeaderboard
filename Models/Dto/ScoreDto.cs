using Newtonsoft.Json;
using WhisperLeaderboard.Models.Dto.Game;

namespace WhisperLeaderboard.Models
{
    public class ScoreDto
    {
        [JsonProperty("score")]
        public int Score { get; set; }
        [JsonProperty("mode")]
        public GameMode Mode { get; set; }
    }
}
