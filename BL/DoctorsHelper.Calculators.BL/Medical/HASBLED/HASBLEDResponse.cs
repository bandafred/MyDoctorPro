using DoctorsHelper.BL.Core.Interfaces;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.Medical.HASBLED
{
    /// <summary>
    /// Результат шкалы HAS-BLED.
    /// </summary>
    public class HASBLEDResponse : IStringResponse
    {
        public const string LowRiskOfBleeding = "Низкий риск кровотечения";
        public const string HighRiskOfBleeding = "Высокий риск кровотечения, применение любого антитромботического препарата требует особой осторожности";

        [JsonIgnore] public int Index { get; }

        public HASBLEDResponse(int index)
        {
            Index = index;
        }

        public string Result => Index < 3 ? LowRiskOfBleeding : HighRiskOfBleeding;
    }
}
