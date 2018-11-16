using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhisperLeaderboard.Models.Dto.Game
{
    public interface IGameContext
    {
        string AgentName { get; set; }
        string DisarmerName { get; set; }
        DateTime GameStartTime { get; set; }
        DateTime? FirstStrikeTime { get; set; }
        DateTime? SecondStrikeTime { get; set; }
        GameMode Mode { get; set; }
        TimeSpan StartBombTime { get; set; }
        TimeSpan RemainingTime { get; }

        void NewGame(StartParameters startParams);
        void NamePlayer(NameParameters nameParams);
        void Strike(StrikeParameters strikeParams);
        void EndGame();
    }
}
