using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhisperLeaderboard.Models.Dto
{
    public class EditDto
    {
        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("entry")]
        public Entry Entry { get; set; }
    }
}
