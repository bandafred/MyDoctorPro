using DoctorsHelper.BL.Core.Interfaces;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.LorentzFormula
{
    /// <summary>
    /// Результат формула Лоренца.
    /// </summary>
    public class LorentzFormulaResponse : IStringResponse
    {
        public const string LorentzFormulaResponsePre = "Идеальная масса тела -";
        public const string LorentzFormulaResponsePost = "кг.";

        public LorentzFormulaResponse(int calculationResult)
        {
            CalculationResult = calculationResult;
        }

        [JsonIgnore]
        public int CalculationResult { get; }

        public string Result => $"{LorentzFormulaResponsePre} {CalculationResult} {LorentzFormulaResponsePost}";
    }
}