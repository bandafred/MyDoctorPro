using DoctorsHelper.BL.Core.Interfaces;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.EgorovaTable
{
    /// <summary>
    /// Результат таблицы Егорова-Левитского.
    /// </summary>
    public class EgorovaTableResponse : IStringResponse
    {
        public const string EgorovaTableResponsePre = "Идеальная масса тела -";
        public const string EgorovaTableResponsePost = "кг.";

        public EgorovaTableResponse(double calculationResult)
        {
            CalculationResult = calculationResult;
        }

        [JsonIgnore]
        public double CalculationResult { get; }

        public string Result => $"{EgorovaTableResponsePre} {CalculationResult} {EgorovaTableResponsePost}";
    }
}