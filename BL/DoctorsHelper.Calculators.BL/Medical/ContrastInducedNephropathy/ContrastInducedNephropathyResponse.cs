using System.Collections.Generic;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.Medical.ContrastInducedNephropathy
{
    /// <summary>
    /// Результат вероятности развития контраст индуцированной нефропатии.
    /// </summary>
    public class ContrastInducedNephropathyResponse
    {
        public const string LowRisk = "Низкий риск";
        public const string MediumRisk = "Средний риск";
        public const string HighRisk = "Высокий риск";
        public const string VeryHighRisk = "Очень высокий риск";
        public const string DialysisChance = "Вероятность диализа";
        public const string KINChance = "вероятность развития КИН";
        
        [JsonIgnore] public double Index { get; }
        [JsonIgnore] public double Risk { get; }
        [JsonIgnore] public string RiskString { get; }
        [JsonIgnore] public double DialysisChanceProcent { get; }

        public ContrastInducedNephropathyResponse(int index)
        {
            Index = index;
            if (index <=5)
            {
                Risk = 7.5;
                DialysisChanceProcent = 0.04;
                RiskString = LowRisk;
            }
            if (Index > 5 & Index <= 10)
            {
                Risk = 14;
                DialysisChanceProcent = 0.12;
                RiskString = MediumRisk;
            }
            if (Index > 10 & Index <= 15)
            {
                Risk = 26.1;
                DialysisChanceProcent = 1.09;
                RiskString = HighRisk;
            }
            if (Index > 15)
            {
                Risk = 57.3;
                DialysisChanceProcent = 12.6;
                RiskString = VeryHighRisk;
            }
        }

        public List<string> Result =>
            new List<string>
            {
                $"{RiskString} - {KINChance} - {Risk}%",
                $"{DialysisChance} - {DialysisChanceProcent}%"
            };
    }
}
