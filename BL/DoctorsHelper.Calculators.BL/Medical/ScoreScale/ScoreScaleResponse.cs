using System;
using System.Drawing;
using DoctorsHelper.BL.Core.Interfaces;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.Medical.ScoreScale
{
    /// <summary>
    /// Результат шкалы SCORE.
    /// </summary>
    public class ScoreScaleResponse : IStringResponse
    {
        public ScoreScaleResponse(int index, bool isUnder40)
        {
            Index = index;
            IsUnder40 = isUnder40;
        }

        public const string IsUnder40VeryLowRiskResponseString = "Очень низкий риск развития смертельного сердечно-сосудистого заболевания в течение 10 лет";
        public const string IsUnder40LowRiskResponseString = "Низкий риск развития смертельного сердечно-сосудистого заболевания в течение 10 лет";
        public const string IsUnder40AverageRiskResponseString = "Средний риск развития смертельного сердечно-сосудистого заболевания в течение 10 лет";
        public const string IsUnder40HighRiskResponseString = "Высокий риск развития смертельного сердечно-сосудистого заболевания в течение 10 лет";
        public const string IsUnder40VeryHighRiskResponseString = "Очень высокий риск развития смертельного сердечно-сосудистого заболевания в течение 10 лет";
        public const string LowRiskResponseString = "Низкий уровень риска развития смертельного сердечно-сосудистого заболевания в течение 10 лет";
        public const string AverageRiskResponseString = "Средний уровень риска развития смертельного сердечно-сосудистого заболевания в течение 10 лет";
        public const string HighRiskResponseString = "Высокий уровень риска развития смертельного сердечно-сосудистого заболевания в течение 10 лет";
        public const string VeryHighRiskResponseString = "Очень высокий уровень риска развития смертельного сердечно-сосудистого заболевания в течение 10 лет";
        
        [JsonIgnore]
        public int Index { get; }

        [JsonIgnore]
        public bool IsUnder40 { get; }

        public string Result => $"Индекс SCORE = {Index}";

        public string Level
        {
            get
            {
                if (IsUnder40)
                {
                    if (Index == 1)
                        return IsUnder40VeryLowRiskResponseString;
                    if (Index == 2)
                        return IsUnder40LowRiskResponseString;
                    if (Index >= 3 & Index < 5)
                        return IsUnder40AverageRiskResponseString;
                    if (Index >= 5 & Index < 10)
                        return IsUnder40HighRiskResponseString;
                    return IsUnder40VeryHighRiskResponseString;
                }

                if (Index <= 2)
                    return LowRiskResponseString;
                if (Index > 2 && Index < 5)
                    return AverageRiskResponseString;
                if (Index >= 5 && Index < 15)
                    return HighRiskResponseString;
                return VeryHighRiskResponseString;
            }
        }

        private Color Color
        {
            get
            {
                if (IsUnder40)
                {
                    if (Index <= 2)
                        return Color.DarkGreen;
                    if (Index >= 3 & Index < 5)
                        return Color.DarkOrange;
                    return Color.DarkRed;
                }

                if (Index <= 2)
                    return Color.DarkGreen;
                if (Index > 2 && Index < 5)
                    return Color.GreenYellow;
                if (Index >= 5 && Index < 15)
                    return Color.DarkOrange;
                return Color.DarkRed;
            }
        }
    }
}
