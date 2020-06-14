using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.IndexSolovieva
{
    /// <summary>
    /// Request model for IndexSolovieva.
    /// </summary>
    public class IndexSolovievaQuery : IQuery<IndexSolovievaResponse>
    {
        // <summary>
        /// Мужской пол.
        /// </summary>
        public bool IsMen { get; set; }

        /// <summary>
        /// Объем запястья в самом тонком месте.
        /// </summary>
        public int WristLength { get; set; }
    }
}
