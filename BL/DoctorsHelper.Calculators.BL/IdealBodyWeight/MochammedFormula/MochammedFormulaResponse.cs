using DoctorsHelper.BL.Core.Interfaces;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.MochammedFormula
{
    /// <summary>
    /// Результат формула Мохамеда.
    /// </summary>
    public class MochammedFormulaResponse : IStringResponse
    {
        public const string MochammedFormulaResponsePre = "Идеальная масса тела -";
        public const string MochammedFormulaResponsePost = "кг.";

        public MochammedFormulaResponse(double calculationResult)
        {
            CalculationResult = calculationResult;
        }

        [JsonIgnore]
        public double CalculationResult { get; }

        public string Result => $"{MochammedFormulaResponsePre} {CalculationResult} {MochammedFormulaResponsePost}";
    }
}