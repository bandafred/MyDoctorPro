using DoctorsHelper.BL.Core.Interfaces;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.HamviFormula
{
    /// <summary>
    /// Результат формула Хамви.
    /// </summary>
    public class HamviFormulaResponse : IStringResponse
    {
        public const string HamviFormulaResponsePre = "Идеальная масса тела -";
        public const string HamviFormulaResponsePost = "кг.";

        public HamviFormulaResponse(double calculationResult)
        {
            CalculationResult = calculationResult;
        }

        [JsonIgnore]
        public double CalculationResult { get; }

        public string Result => $"{HamviFormulaResponsePre} {CalculationResult} {HamviFormulaResponsePost}";
    }
}