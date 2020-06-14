using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.Borngardt
{
    public class BorngardtQuery : IQuery<BorngardtResponse>
    {
        /// <summary>
        /// Рост в сантиметрах.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Обхват груди в сантиметрах.
        /// </summary>
        public int ChestСircumference { get; set; }
    }
}