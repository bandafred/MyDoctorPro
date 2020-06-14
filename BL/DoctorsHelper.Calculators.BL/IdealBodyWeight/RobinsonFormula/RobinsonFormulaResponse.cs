using DoctorsHelper.BL.Core.Interfaces;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.RobinsonFormula
{
    /// <summary>
    /// Результат расчета формулы Робинсона.
    /// </summary>
    public class RobinsonFormulaResponse : IStringResponse
    {
        public const string RobinsonFormulaResponsePre = "Идеальная масса тела -";
        public const string RobinsonFormulaResponsePost = "кг.";

        public RobinsonFormulaResponse(double calculationResult)
        {
            CalculationResult = calculationResult;
        }

        [JsonIgnore]
        public double CalculationResult { get; }

        public string Result => $"{RobinsonFormulaResponsePre} {CalculationResult} {RobinsonFormulaResponsePost}";
    }
}