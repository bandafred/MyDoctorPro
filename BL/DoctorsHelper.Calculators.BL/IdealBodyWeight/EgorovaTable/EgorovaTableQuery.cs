using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.EgorovaTable
{
    /// <summary>
    /// Модель запроса для таблицы Егорова-Левитского.
    /// </summary>
    public class EgorovaTableQuery : IQuery<EgorovaTableResponse>
    {
        /// <summary>
        /// Рост в сантиметрах.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Мужской пол.
        /// </summary>
        public bool IsMen { get; set; }

        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { get; set; }
    }
}