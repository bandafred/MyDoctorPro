using DoctorsHelper.BL.Core.Interfaces;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.KreffFormula
{
    /// <summary>
    /// Результат формула Креффа.
    /// </summary>
    public class KreffFormulaResponse : IStringResponse
    {
        public const string KreffFormulaResponsePre = "Идеальная масса тела -";
        public const string KreffFormulaResponsePost = "кг.";

        public KreffFormulaResponse(double calculationResult)
        {
            CalculationResult = calculationResult;
        }

        [JsonIgnore]
        public double CalculationResult { get; }

        public string Result => $"{KreffFormulaResponsePre} {CalculationResult} {KreffFormulaResponsePost}";
    }
}