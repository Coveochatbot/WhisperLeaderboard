using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhisperLeaderboard.Models.Dto.Game
{
    public class GameContext : IGameContext
    {
        public GameContext()
        {

        }

        public void NewGame(StartParameters startParams)
        {
            GameStartTime = startParams.StartTime;
            FirstStrikeTime = null;
            SecondStrikeTime = null;
            Mode = startParams.Mode;
            StartBombTime = startParams.StartBombTime;
        }

        public void NamePlayer(NameParameters nameParams)
        {
            switch (nameParams.Type)
            {
                case PlayerType.Agent:
                    AgentName = nameParams.Name;
                    break;
                case PlayerType.User:
                    DisarmerName = nameParams.Name;
                    break;
                default:
                    break;
            }
        }

        public void Strike(StrikeParameters strikeParams)
        {
            switch (strikeParams.StrikeNumber)
            {
                case 1:
                    FirstStrikeTime = strikeParams.When;
                    break;
                case 2:
                    SecondStrikeTime = strikeParams.When;
                    break;
                default:
                    break;
            }
        }

        public void EndGame()
        {
            AgentName = null;
            DisarmerName = null;
        }

        public TimeSpan GetBombRemainingTime(DateTime current)
        {
            if (FirstStrikeTime == null)
            {
                return StartBombTime - (current - GameStartTime);
            }
            else if (SecondStrikeTime == null)
            {
                return StartBombTime - (FirstStrikeTime.Value - GameStartTime) - 1.25 * (current - FirstStrikeTime.Value);
            }
            else
            {
                return StartBombTime - (FirstStrikeTime.Value - GameStartTime) - 1.25 * (SecondStrikeTime.Value - FirstStrikeTime.Value) - 1.5 * (current - SecondStrikeTime.Value);
            }
        }

        public string AgentName { get; set; }
        public string DisarmerName { get; set; }
        public DateTime GameStartTime { get; set; }
        public DateTime? FirstStrikeTime { get; set; }
        public DateTime? SecondStrikeTime { get; set; }
        public GameMode Mode { get; set; }
        public TimeSpan StartBombTime { get; set; }
    }
}
