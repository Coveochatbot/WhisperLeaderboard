using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WhisperLeaderboard.Models
{
    public class Leaderboard : ILeaderboard
    {
        public int Size { get; private set; }
        private List<Entry> _entries = new List<Entry>();

        public Leaderboard()
        {
            Size = 5;
        }

        public Leaderboard(List<Entry> entries, int size)
        {
            Initialize(entries, size);
        }

        public List<Entry> GetTopEntries()
        {
            return GetAllEntries().Take(Size).ToList();
        }

        public List<Entry> GetAllEntries()
        {
            return _entries.OrderBy(x => x.Score).ToList();
        }

        public void RemoveEntry(int position)
        {
            var entry = GetEntry(position);
            _entries.Remove(entry);
        }

        public Entry GetEntry(int position)
        {
            if (_entries.Count >= position && position > 0)
                return GetAllEntries()[position-1];

            throw new KeyNotFoundException($"Position {position} was not found in leaderboard");
        }

        public bool IsEligible(int score)
        {
            return GetTopEntries().Last().Score < score;
        }

        public void InsertEntry(string name1, string name2, int score)
        {
            _entries.Add(new Entry(TruncateName(name1), TruncateName(name2), score));
        }

        public void Resize(int size)
        {
            if (size < 1)
                throw new ArgumentException("Leaderboard size should be higher than 0");
            Size = size;
        }

        private void Initialize(List<Entry> entries, int size)
        {
            Resize(size);
            _entries = entries;
        }

        private string TruncateName(string name)
        {
            if (name.Length <= 14)
                return name;

            var result = name.Substring(0, 13);
            return result += ".";
        }
    }
}
