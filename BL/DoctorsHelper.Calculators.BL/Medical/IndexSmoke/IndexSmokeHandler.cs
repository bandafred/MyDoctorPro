using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.Medical.IndexSmoke
{
    /// <summary>
    /// Индекс курения.
    /// </summary>
    public class IndexSmokeHandler : IQueryHandler<IndexSmokeQuery, IndexSmokeResponse>
    {
        public async Task<IndexSmokeResponse> Handle(IndexSmokeQuery input)
        {
            await new IndexSmokeQueryValidator().ValidateAndThrowAsync(input);

            var result = new IndexSmokeResponse(GetResult(input.AgeSmoke, input.CountSigar));

            return result;
        }

        /// <summary>
        /// Расчет индекса курения.
        /// </summary>
        /// <param name="ageSmoke"></param>
        /// <param name="countSigar"></param>
        /// <returns></returns>
       private double GetResult(double ageSmoke, double countSigar)
        {
            return  (countSigar * ageSmoke) / 20;
        }
    }
}