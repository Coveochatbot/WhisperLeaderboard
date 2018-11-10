using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WhisperLeaderboard.Models
{
    public class Leaderboard
    {
        public int Size { get; }
        public List<Entry> Entries => _entries.OrderByDescending(x => x.Score).Take(Size).ToList();

        private List<Entry> _entries = new List<Entry>();

        public Leaderboard()
        {
            Size = 5;
            FillLeaderboard(_entries, Size);
        }

        public Leaderboard(List<Entry> entries, int size)
        {
            if (size < 1)
                throw new ArgumentException("Leaderboard size should be higher than 0");
            if (size < entries.Count)
                throw new ArgumentException("Leaderboard size should be higher or equal than entries count");
            if (entries.Count < size)
                FillLeaderboard(entries, size);
            Size = size;
            _entries = entries;
        }

        public void RemoveEntry(int position)
        {
            var entry = GetEntry(position);
            _entries.Remove(entry);
            FillLeaderboard(_entries, Size);
        }

        public Entry GetEntry(int position)
        {
            if (_entries.Count >= position && position > 0)
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
                _entries.Add(new Entry(TruncateName(name1), TruncateName(name2), score));
                if(_entries.Count > Size*2)
                {
                    var lastEntry = _entries.OrderByDescending(x => x.Score).Last();
                    _entries.Remove(lastEntry);
                }
            }
        }

        private string TruncateName(string name)
        {
            if (name.Length <= 14)
                return name;

            var result = name.Substring(0, 13);
            return result += ".";
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
