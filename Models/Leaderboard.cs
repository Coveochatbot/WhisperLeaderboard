using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WhisperLeaderboard.Models
{
    public class Leaderboard
    {
        public int Size { get; }
        public List<Entry> Entries => _entries.OrderByDescending(x => x.Score).ToList();

        private List<Entry> _entries = new List<Entry>();

        public Leaderboard()
        {
            Size = 5;
            FillLeaderboard(_entries, Size);
        }

        public Leaderboard(List<Entry> entries, int size)
        {
            if (size < entries.Count)
                throw new ArgumentException("Leaderboard size should be higher or equal than entries count");
            if (size < 1)
            {
                size = 1;
                entries = new List<Entry>();
            }
            if (entries.Count < size)
                FillLeaderboard(entries, size);

            Size = size;
            _entries = entries;
        }

        public Entry GetEntry(int position)
        {
            if (_entries.Count >= position)
                return Entries[position-1];

            throw new KeyNotFoundException($"Position {position} was not found in leaderboard");
        }

        public bool IsEligible(int score)
        {
            return Entries.Last().Score <= score ? true : false;
        }

        public void InsertEntry(string name1, string name2, int score)
        {
            if (IsEligible(score))
            {
                _entries.Add(new Entry(name1, name2, score));
                if(_entries.Count > Size)
                {
                    var lastEntry = _entries.OrderByDescending(x => x.Score).Last();
                    _entries.Remove(lastEntry);
                }
            }
        }

        private void FillLeaderboard(List<Entry> entries, int size)
        {
            for (int i = entries.Count; i < size; i++)
            {
                entries.Add(new Entry("", "", 0));
            }
        }
    }
}
