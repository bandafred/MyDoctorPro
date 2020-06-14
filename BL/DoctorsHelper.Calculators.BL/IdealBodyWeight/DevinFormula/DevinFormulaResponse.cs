using DoctorsHelper.BL.Core.Interfaces;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.DevinFormula
{
    /// <summary>
    /// Результат формула Девина.
    /// </summary>
    public class DevinFormulaResponse : IStringResponse
    {
        public const string DevinFormulaResponsePre = "Идеальная масса тела -";
        public const string DevinFormulaResponsePost = "кг.";

        public DevinFormulaResponse(double calculationResult)
        {
            CalculationResult = calculationResult;
        }

        [JsonIgnore]
        public double CalculationResult { get; }

        public string Result => $"{DevinFormulaResponsePre} {CalculationResult} {DevinFormulaResponsePost}";
    }
}