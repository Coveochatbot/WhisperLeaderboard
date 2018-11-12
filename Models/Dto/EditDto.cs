using Newtonsoft.Json;

namespace WhisperLeaderboard.Models.Dto
{
    public class EditDto
    {
        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("name1")]
        public string Name1 { get; set; }
        [JsonProperty("name2")]
        public string Name2 { get; set; }
        [JsonProperty("score")]
        public int Score { get; set; }
    }
}
