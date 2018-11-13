using Newtonsoft.Json;

namespace WhisperLeaderboard.Models.Dto
{
    public class PasswordDto
    {
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
