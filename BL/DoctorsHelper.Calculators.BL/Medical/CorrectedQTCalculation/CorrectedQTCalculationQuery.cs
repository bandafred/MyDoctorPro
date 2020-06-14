using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.Medical.CorrectedQTCalculation
{
    /// <summary>
    /// Модель запрос для расчета корригированного QT.
    /// </summary>
    public class CorrectedQTCalculationQuery : IQuery<CorrectedQTCalculationResponse>
    {
        /// <summary>
        /// Частота сердечных сокращений.
        /// </summary>
        public int HeartRate { get; set; }

        /// <summary>
        /// Интервал QT мсек.
        /// </summary>
        public double IntervalQT { get; set; }

    }
}