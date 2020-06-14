using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.NaglerFormula
{
    public class NaglerFormulaQuery : IQuery<NaglerFormulaResponse>
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