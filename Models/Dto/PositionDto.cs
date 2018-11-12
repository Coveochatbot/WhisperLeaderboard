using Newtonsoft.Json;

namespace WhisperLeaderboard.Models.Dto
{
    public class PositionDto
    {
        [JsonProperty("position")]
        public int Position { get; set; }
    }
}
