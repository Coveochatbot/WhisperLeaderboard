using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhisperLeaderboard.Models
{
    public class Entry
    {
        public string Name1 { get; }
        public string Name2 { get; }
        public int Score { get; }

        public Entry(string name1, string name2, int score)
        {
            Name1 = name1;
            Name2 = name2;
            Score = score;
        }
    }
}
