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
            Entries.Add(new Entry("Félix", "Albin", 187));
            Entries.Add(new Entry("Cloé", "Gauthier", 89));
            Entries.Add(new Entry("Léonne", "lucinde", 222));
            Entries.Add(new Entry("Adrien", "Côme", 167));
            Entries.Add(new Entry("Chantale", "Bolduc", 203));
        }
    }
}
