using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhisperLeaderboard.Models.Dto.Game
{
    public enum GameMode
    {
        Easy,
        Medium,
        Hard,
        Expert
    }

    public class StartParameters
    {
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
        public GameMode Mode { get; set; }

        public DateTime StartTime { get; set; }
        public TimeSpan StartBombTime { get; set; }
    }
}
