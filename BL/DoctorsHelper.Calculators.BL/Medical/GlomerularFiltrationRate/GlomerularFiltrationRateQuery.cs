using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.Medical.GlomerularFiltrationRate
{
    /// <summary>
    /// Модель запрос для расчета скорости клубочковой фильтрации.
    /// </summary>
    public class GlomerularFiltrationRateQuery : IQuery<GlomerularFiltrationRateResponse>
    {
        /// <summary>Креатинин.</summary>
        public double Creatinin { get; set; }

        /// <summary>Возраст.</summary>
        public int Age { get; set; }

        /// <summary>Вес.</summary>
        public int Weight { get; set; }

        /// <summary>Рост в сантиметрах.</summary>
        public int Height { get; set; }

        /// <summary>Признак мужского пола.</summary>
        public bool IsMen { get; set; }

    }
}