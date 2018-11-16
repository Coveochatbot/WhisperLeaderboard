using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhisperLeaderboard.Models.Dto.Game
{
    public enum PlayerType
    {
        Agent,
        User
    }

    public class NameParameters
    {
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
        public PlayerType Type { get; set; }

        public string Name { get; set; }
    }
}
