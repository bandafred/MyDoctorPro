using System;
using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.IndexBroka
{
    /// <summary>
    /// Хендлер для получения <see cref="IndexBrokaResponse"/> из <see cref="IndexBrokaQuery"/>
    /// Индекс Брока для женщин:
    /// Идеальный вес = (Рост - 100) * 0,85
    /// Индекс Брока для мужчин
    /// Идеальный вес = (Рост - 100) * 0,9
    /// </summary>
    public class IndexBrokaHandler : IQueryHandler<IndexBrokaQuery, IndexBrokaResponse>
    {
        public async Task<IndexBrokaResponse> Handle(IndexBrokaQuery input)
        {
            await new IndexBrokaQueryValidator().ValidateAndThrowAsync(input);

            return new IndexBrokaResponse(GetResult(input));
        }

        /// <summary>
        /// Расчет индекса Брока.
        /// </summary>
        /// <param name="input">IndexBrokaQuery</param>
        /// <returns>Результат в кг.</returns>
        private double GetResult(IndexBrokaQuery input)
        {
            return Math.Round(input.Height - 100 * (input.IsMen ? 0.9 : 0.85), 2);
        }
    }
}
