using DoctorsHelper.BL.Core.Interfaces;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.Medical.TimiScale
{
    /// <summary>
    /// Результат шкалы TIMI.
    /// </summary>
    public class TimiScaleResponse : IStringResponse
    {
        public TimiScaleResponse(double index)
        {
            Index = index;
        }
        [JsonIgnore]
        public double Index { get; }

        public string Result => $"Риск смерти или инфаркта миокарда в ближайшие 2 недели - {Index}%";
    }
}
