using System.Collections.Generic;
using WhisperLeaderboard.Models.Dto.Game;

namespace WhisperLeaderboard.Models
{
    public interface ILeaderboard
    {

        void RemoveEntry(int position);
        
        Entry GetEntry(int position);

        List<Entry> GetTopEntries(GameMode mode);

        List<Entry> GetAllEntries();

        List<Entry> GetEntries(GameMode mode);

        bool IsEligible(int score, GameMode mode);

        void Resize(int size);
        
        void InsertEntry(string name1, string name2, int score, GameMode mode);
    }
}
