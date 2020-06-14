using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.Medical.IndexSmoke
{
    /// <summary>
    /// Модель запрос для индекса курения.
    /// </summary>
    public class IndexSmokeQuery : IQuery<IndexSmokeResponse>
    {
        /// <summary>
        /// Стаж курения, лет.
        /// </summary>
        public int AgeSmoke { get; set; }

        /// <summary>
        /// Количество сигарет в день.
        /// </summary>
        public int CountSigar { get; set; }

    }
}