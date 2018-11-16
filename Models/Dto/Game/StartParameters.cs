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
        Expert
    }

    public class StartParameters
    {
        public GameMode Mode { get; set; }
        public DateTime StartTime { get; set; }
    }
}
