using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.KreffFormula
{
    public class KreffFormulaQuery : IQuery<KreffFormulaResponse>
    {
        /// <summary>
        /// Рост в сантиметрах.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Объем запястья в самом тонком месте.
        /// </summary>
        public int LenСarpus { get; set; }
    }
}