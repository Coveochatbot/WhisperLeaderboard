using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using WhisperLeaderboard.Models.Dto.Game;

namespace WhisperLeaderboard.Models.Dto
{
    public class EditDto
    {
        [JsonProperty("position")]
        public int Position { get; set; }

        [Required]
        [JsonProperty("name1")]
        public string Name1 { get; set; }

        [Required]
        [JsonProperty("name2")]
        public string Name2 { get; set; }

        [Required]
        [JsonProperty("score")]
        public int Score { get; set; }

        [Required]
        [JsonProperty("mode")]
        public GameMode Mode { get; set; }
    }
}
