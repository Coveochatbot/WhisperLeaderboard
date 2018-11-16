using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhisperLeaderboard.Models.Dto.Game
{
    public class EndParameters
    {
        public bool Success { get; set; }

        /// <summary>
        /// How long did it take to disarm the bomb if success.
        /// </summary>
        public TimeSpan HowLong { get; set; }
    }
}
