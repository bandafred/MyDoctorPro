using DoctorsHelper.BL.Core.Interfaces;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.IndexBroka
{
    /// <summary>
    /// Результат формула Лоренца.
    /// </summary>
    public class IndexBrokaResponse : IStringResponse
    {
        public const string IndexBrokaResponsePre = "Идеальная масса тела -";
        public const string IndexBrokaResponsePost = "кг.";

        public IndexBrokaResponse(double calculationResult)
        {
            CalculationResult = calculationResult;
        }

        [JsonIgnore]
        public double CalculationResult { get; }

        public string Result => $"{IndexBrokaResponsePre} {CalculationResult} {IndexBrokaResponsePost}";
    }
}