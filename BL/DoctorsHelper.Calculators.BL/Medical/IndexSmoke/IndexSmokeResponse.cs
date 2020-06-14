using System;
using DoctorsHelper.BL.Core.Interfaces;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.Medical.IndexSmoke
{
    /// <summary>
    /// Результат индекса курения.
    /// </summary>
    public class IndexSmokeResponse : IStringResponse
    {
        public const string DeficitResponseString = "достоверный фактор риска хронической обструктивной болезни легких";
        
        [JsonIgnore]
        public double Index { get; }

        public IndexSmokeResponse(double index)
        {
            Index = index;
        }

        public string Result =>
            Index < 10
                ? $"Индекс пачка/лет - {Math.Round(Index, 1)}"
                : $"Индекс пачка/лет - {Math.Round(Index, 1)} - {DeficitResponseString}";
    }
}
