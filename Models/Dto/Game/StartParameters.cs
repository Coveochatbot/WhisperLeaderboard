using Newtonsoft.Json.Converters;
using System;

namespace WhisperLeaderboard.Models.Dto.Game
{
    public enum GameMode
    {
        Easy,
        Medium,
        Hard,
        Expert
    }

    public static class GameModeToPrettyName
    {
        public static string GetPrettyName(GameMode mode)
        {
            switch (mode)
            {
                case GameMode.Easy: return "Facile";
                case GameMode.Medium: return "Moyen";
                case GameMode.Hard: return "Difficile";
                case GameMode.Expert: return "Expert";
            }
            return mode.ToString("g");
        }
    }

    public class StartParameters
    {
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
        public GameMode Mode { get; set; }

        public DateTime StartTime { get; set; }
        public TimeSpan StartBombTime { get; set; }
    }
}
