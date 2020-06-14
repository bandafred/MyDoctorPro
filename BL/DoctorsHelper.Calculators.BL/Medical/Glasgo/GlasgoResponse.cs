using DoctorsHelper.BL.Core.Interfaces;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.Medical.Glasgo
{
    /// <summary>
    /// Результат шкалы комы Глазго.
    /// </summary>
    public class GlasgoResponse : IStringResponse
    {
        public const string ClearMind = "сознание ясное";
        public const string LightStunning = "легкое оглушение";
        public const string ModerateStun = "умеренное оглушение";
        public const string DeepStunning = "глубокое оглушение";
        public const string Sopor = "сопор";
        public const string ModerateComa = "умеренная кома";
        public const string DeepComa = "глубокая кома";
        public const string BeyondComa = "запредельная кома, смерть мозга";

        [JsonIgnore]
        public int Index { get; }

        [JsonIgnore]
        public string GetBall
        {
            get
            {
                if (Index == 1) return "балл";
                if (Index >=2 && Index <=4 ) return "балла";
                return "баллов";
            }
        }

        [JsonIgnore]
        public string GetResult
        {
            get
            {
                if (Index == 15) return ClearMind;
                if (Index == 14) return LightStunning;
                if (Index == 13) return ModerateStun;
                if (Index == 12) return DeepStunning;
                if (Index <= 11 & Index >= 9) return Sopor;
                if (Index <= 8 & Index >= 7) return ModerateComa;
                if (Index <= 6 & Index >= 5) return DeepComa;
                return Index < 5 ? BeyondComa : null;
            }
        }

        public GlasgoResponse(int index)
        {
            Index = index;
        }
        
        public string Result => $"{Index} {GetBall} - {GetResult}";
    }
}
