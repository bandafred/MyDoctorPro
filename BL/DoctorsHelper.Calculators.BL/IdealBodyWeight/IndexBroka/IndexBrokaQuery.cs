using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.IndexBroka
{
    public class IndexBrokaQuery : IQuery<IndexBrokaResponse>
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