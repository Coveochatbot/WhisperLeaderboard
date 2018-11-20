using System.Collections.Generic;

namespace WhisperLeaderboard.Models
{
    public interface ILeaderboard
    {

        void RemoveEntry(int position);
        
        Entry GetEntry(int position);

        List<Entry> GetTopEntries();

        List<Entry> GetAllEntries();

        bool IsEligible(int score);

        void Resize(int size);
        
        void InsertEntry(string name1, string name2, int score);
    }
}
