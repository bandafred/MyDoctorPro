using DoctorsHelper.BL.Core.Interfaces;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.Borngardt
{
    public class BorngardtResponse : IStringResponse
    {
        public const string BorngardtResponsePre = "Идеальная масса тела -";
        public const string BorngardtResponsePost = "кг.";

        public BorngardtResponse(int calculationResult)
        {
            CalculationResult = calculationResult;
        }

        [JsonIgnore]
        public int CalculationResult { get; }

        public string Result => $"{BorngardtResponsePre} {CalculationResult} {BorngardtResponsePost}";
    }
}