using DoctorsHelper.BL.Core.Interfaces;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.CuperFormula
{
    /// <summary>
    /// Результат формула Купера.
    /// </summary>
    public class CuperFormulaResponse : IStringResponse
    {
        public const string CuperFormulaResponsePre = "Идеальная масса тела -";
        public const string CuperFormulaResponsePost = "кг.";

        public CuperFormulaResponse(double calculationResult)
        {
            CalculationResult = calculationResult;
        }

        [JsonIgnore]
        public double CalculationResult { get; }

        public string Result => $"{CuperFormulaResponsePre} {CalculationResult} {CuperFormulaResponsePost}";
    }
}