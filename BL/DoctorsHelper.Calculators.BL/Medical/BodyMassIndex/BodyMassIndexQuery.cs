using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.Medical.BodyMassIndex
{
    /// <summary>
    /// Модель запрос для ИМТ.
    /// </summary>
    public class BodyMassIndexQuery : IQuery<BodyMassIndexResponse>
    {
        /// <summary>
        /// Рост в сантиметрах.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Вес в кг.
        /// </summary>
        public int Weight { get; set; }

    }
}