using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhisperLeaderboard.Models
{
    public class Leaderboard
    {
        public List<Entry> Entries { get; }

        public Leaderboard()
        {
            Entries = new List<Entry>();
            Entries.Add(new Entry("Chantale", "Bolduc", 203));
        }
    }
}
