using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.RobinsonFormula
{
    /// <summary>
    /// Модель запроса для расчета по формуле Робинсона.
    /// </summary>
    public class RobinsonFormulaQuery : IQuery<RobinsonFormulaResponse>
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