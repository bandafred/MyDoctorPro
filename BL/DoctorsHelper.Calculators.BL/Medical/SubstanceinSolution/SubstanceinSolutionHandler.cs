using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.Medical.SubstanceinSolution
{
    /// <summary>
    /// Расчет содержания вещества в растворе (пересчет процентов в миллиграммы).
    /// </summary>
    public class SubstanceinSolutionHandler : IQueryHandler<SubstanceinSolutionQuery, SubstanceinSolutionResponse>
    {
        public async Task<SubstanceinSolutionResponse> Handle(SubstanceinSolutionQuery input)
        {
            await new SubstanceinSolutionQueryValidator().ValidateAndThrowAsync(input);

            var result = new SubstanceinSolutionResponse(GetResult(input.Procent, input.Volume));

            return result;
        }

        /// <summary>
        /// Расчет содержания вещества в растворе (пересчет процентов в миллиграммы)
        /// </summary>
        /// <param name="procent">Процент.</param>
        /// <param name="volume">Объем ампулы.</param>
        /// <returns></returns>
        private double GetResult(double procent, double volume)
        {
            return procent * volume / 100;
           
        }
    }
}