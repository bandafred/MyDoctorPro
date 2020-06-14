using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.IndexBrokaBruksha
{
    public class IndexBrokaBrukshaQuery : IQuery<IndexBrokaBrukshaResponse>
    {
        /// <summary>
        /// Рост в сантиметрах.
        /// </summary>
        public int Height { get; set; }
    }
}