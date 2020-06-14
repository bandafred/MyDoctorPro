using DoctorsHelper.BL.Core.Interfaces;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.MonnerotFormula
{
    /// <summary>
    /// Результат формулы Моннерота-Думайна.
    /// </summary>
    public class MonnerotFormulaResponse : IStringResponse
    {
        public const string MonnerotFormulaResponsePre = "Идеальная масса тела -";
        public const string MonnerotFormulaResponsePost = "кг.";

        public MonnerotFormulaResponse(double calculationResult)
        {
            CalculationResult = calculationResult;
        }

        [JsonIgnore]
        public double CalculationResult { get; }

        public string Result => $"{MonnerotFormulaResponsePre} {CalculationResult} {MonnerotFormulaResponsePost}";
    }
}