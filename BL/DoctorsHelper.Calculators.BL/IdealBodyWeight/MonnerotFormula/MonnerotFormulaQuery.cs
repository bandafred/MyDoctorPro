using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.MonnerotFormula
{
    /// <summary>
    /// Модель запроса для расчета формулы Моннерота-Думайна.
    /// </summary>
    public class MonnerotFormulaQuery : IQuery<MonnerotFormulaResponse>
    {
        /// <summary>
        /// Рост в сантиметрах.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Объем запястья в самом тонком месте.
        /// </summary>
        public int WristLength { get; set; }
    }
}