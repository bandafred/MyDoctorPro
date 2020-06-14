using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.MochammedFormula
{
    public class MochammedFormulaQuery : IQuery<MochammedFormulaResponse>
    {
        /// <summary>
        /// Рост в сантиметрах.
        /// </summary>
        public int Height { get; set; }
    }
}