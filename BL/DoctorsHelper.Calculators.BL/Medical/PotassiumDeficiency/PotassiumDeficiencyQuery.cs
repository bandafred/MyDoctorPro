using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.Medical.PotassiumDeficiency
{
    /// <summary>
    /// Модель запроса для расчета дефицита калия.
    /// </summary>
    public class PotassiumDeficiencyQuery : IQuery<PotassiumDeficiencyResponse>
    {
        /// <summary>Калий сыворотки, ммоль/л.</summary>
        public double BloodKaliumLevel { get; set; }

        /// <summary>Вес пациента, кг.</summary>
        public int BodyMass { get; set; }

    }
}