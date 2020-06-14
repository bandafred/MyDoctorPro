using DoctorsHelper.BL.Core.Interfaces;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.MillerFormula
{
    /// <summary>
    /// Результат формула Купера.
    /// </summary>
    public class MillerFormulaResponse : IStringResponse
    {
        public const string MillerFormulaResponsePre = "Идеальная масса тела -";
        public const string MillerFormulaResponsePost = "кг.";

        public MillerFormulaResponse(double calculationResult)
        {
            CalculationResult = calculationResult;
        }

        [JsonIgnore]
        public double CalculationResult { get; }

        public string Result => $"{MillerFormulaResponsePre} {CalculationResult} {MillerFormulaResponsePost}";
    }
}