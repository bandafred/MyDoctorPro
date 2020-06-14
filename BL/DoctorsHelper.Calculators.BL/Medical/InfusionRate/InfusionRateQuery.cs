using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.Medical.InfusionRate
{
    /// <summary>
    /// Расчет скорости инфузии.
    /// </summary>
    public class InfusionRateQuery : IQuery<InfusionRateResponse>
    {
        /// <summary>Масса тела кг.</summary>
        public int BodyMass { get; set; }

        /// <summary>Количество препарата мг.</summary>
        public double AmountDrug { get; set; }

        /// <summary>Объем раствора, мл.</summary>
        public double VolumeSolution { get; set; }

        /// <summary>Доза препарата мкг*кг/мин.</summary>
        public double Dose { get; set; }

    }
}