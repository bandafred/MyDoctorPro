using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.HamviFormula
{
    /// <summary>
    /// Модель запроса формула Хамви.
    /// </summary>
    public class HamviFormulaQuery : IQuery<HamviFormulaResponse>
    {
        /// <summary>
        /// Рост в сантиметрах.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Мужской пол.
        /// </summary>
        public bool IsMen { get; set; }
    }
}