using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.Medical.SubstanceinSolution
{
    /// <summary>
    /// Расчет содержания вещества в растворе (пересчет процентов в миллиграммы).
    /// </summary>
    public class SubstanceinSolutionQuery : IQuery<SubstanceinSolutionResponse>
    {
        /// <summary>Процентное содержание, %.</summary>
        public double Procent { get; set; }

        /// <summary>Объем ампулы, мл.</summary>
        public double Volume { get; set; }

    }
}