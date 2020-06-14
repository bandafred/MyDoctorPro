using System;
using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.IndexBrokaBruksha
{
    /// <summary>
    /// Хендлер для получения <see cref="IndexBrokaBrukshaResponse"/> из <see cref="IndexBrokaBrukshaQuery"/>
    /// Индекс Брока-Бругша при росте менее 165 см:
    /// Идеальный вес = Рост - 100
    /// Индекс Брока-Бругша при росте от 165 см до 175 см:
    /// Идеальный вес = Рост - 105
    /// Индекс Брока-Бругша при росте более 175 см:
    /// Идеальный вес = Рост - 110
    /// </summary>
    public class IndexBrokaBrukshaHandler : IQueryHandler<IndexBrokaBrukshaQuery, IndexBrokaBrukshaResponse>
    {
        public async Task<IndexBrokaBrukshaResponse> Handle(IndexBrokaBrukshaQuery input)
        {
            await new IndexBrokaBrukshaQueryValidator().ValidateAndThrowAsync(input);

            return new IndexBrokaBrukshaResponse(GetResult(input.Height));
        }

        /// <summary>
        /// Расчет индекса Брока-Бругша.
        /// </summary>
        /// <param name="height">Рост в см.</param>
        /// <returns>Результат в кг.</returns>
        private int GetResult(int height)
        {
            if (height < 165) return height - 100;

            if (height >= 165 & height <= 175) return height - 105;

            if (height > 175 & height <= 350) return height - 110;

            throw new ArgumentException(IndexBrokaBrukshaQueryValidator.HeightIncorrectMessage);
        }
    }
}
