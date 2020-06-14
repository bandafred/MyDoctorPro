using DoctorsHelper.BL.Core.Interfaces;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.IndexBrokaBruksha
{
    /// <summary>
    /// Результат индекс Брака-Бругша.
    /// </summary>
    public class IndexBrokaBrukshaResponse : IStringResponse
    {
        public const string IndexBrokaBrukshaResponsePre = "Идеальная масса тела -";
        public const string IndexBrokaBrukshaResponsePost = "кг.";

        public IndexBrokaBrukshaResponse(int calculationResult)
        {
            CalculationResult = calculationResult;
        }

        [JsonIgnore]
        public int CalculationResult { get; }

        public string Result => $"{IndexBrokaBrukshaResponsePre} {CalculationResult} {IndexBrokaBrukshaResponsePost}";
    }
}