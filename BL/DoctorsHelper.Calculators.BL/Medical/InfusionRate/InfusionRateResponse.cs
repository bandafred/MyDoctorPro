using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.Medical.InfusionRate
{
    /// <summary>
    /// Результат скорости инфузии.
    /// </summary>
    public class InfusionRateResponse
    {
        private const string SpeedInfusiaString = "Скорость инфузии =";
        private const string MlinHour = "мл/час";
        private const string DropsString = "капель в минуту";

        [JsonIgnore] public double  SpeedInfusion { get; }
        [JsonIgnore] public double  Drops { get; }

        public InfusionRateResponse(double speedInfusion, double drops)
        {
            SpeedInfusion = speedInfusion;
            Drops = drops;
        }

        public List<string> Result =>
            new List<string>
            {
                $"{SpeedInfusiaString} {Math.Round(SpeedInfusion, 2)} {MlinHour}",
                $"{SpeedInfusiaString} {Math.Round(Drops, 2)} {DropsString}"
            };
    }
}
