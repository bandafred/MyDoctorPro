using DoctorsHelper.BL.Core.Interfaces;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.NaglerFormula
{
    /// <summary>
    /// Результат формула Наглера.
    /// </summary>
    public class NaglerFormulaResponse : IStringResponse
    {
        public const string NaglerFormulaResponsePre = "Идеальная масса тела -";
        public const string NaglerFormulaResponsePost = "кг.";

        public NaglerFormulaResponse(double calculationResult)
        {
            CalculationResult = calculationResult;
        }

        [JsonIgnore]
        public double CalculationResult { get; }

        public string Result => $"{NaglerFormulaResponsePre} {CalculationResult} {NaglerFormulaResponsePost}";
    }
}