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
        public PlayerType Type { get; set; }
        public string Name { get; set; }
    }
}
