using System;
using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.IndexSolovieva
{
    /// <summary>
    /// Хендлер для получения <see cref="IndexSolovievaResponse"/> из <see cref="IndexSolovievaQuery"/>
    /// Астенический: менее 18 см у мужчин, менее 15 см у женщин.
    /// Нормостенический: 18 - 20 см у мужчин, 15 - 17 у женщин.
    /// Гиперстенический: более 20 см у мужчин, более 17 см у женщин.
    /// </summary>
    public class IndexSolovievaHandler : IQueryHandler<IndexSolovievaQuery, IndexSolovievaResponse>
    {
        public async Task<IndexSolovievaResponse> Handle(IndexSolovievaQuery input)
        {
            await new IndexSolovievaQueryValidator().ValidateAndThrowAsync(input);

            var result = new IndexSolovievaResponse(input.IsMen
                ? GetValueResultForMen(input.WristLength)
                : GetValueResultForWomen(input.WristLength)
            );

            return result;
        }

        /// <summary>
        /// Получить результат для мужчин.
        /// </summary>
        /// <param name="wristLength">Объем запястья в самом тонком месте.</param>
        /// <returns>Результат в виде <see cref="IndexSolovievaResultsEnum"/>.</returns>
        private IndexSolovievaResultsEnum GetValueResultForMen(int wristLength)
        {
            if (wristLength < 18)
                return IndexSolovievaResultsEnum.Asthenic;
            if (wristLength >= 18 & wristLength <= 20)
                return IndexSolovievaResultsEnum.Norma;
            if (wristLength > 20)
                return IndexSolovievaResultsEnum.Hyper;
            throw new ArgumentException(IndexSolovievaQueryValidator.WristLengthIncorrectMessage);
        }

        /// <summary>
        /// Получить результат для женщин.
        /// </summary>
        /// <param name="wristLength">Объем запястья в самом тонком месте.</param>
        /// <returns>Результат в виде <see cref="IndexSolovievaResultsEnum"/>.</returns>
        private IndexSolovievaResultsEnum GetValueResultForWomen(int wristLength)
        {
            if (wristLength < 15)
                return IndexSolovievaResultsEnum.Asthenic;

            if (wristLength >= 15 & wristLength <= 17)
                return IndexSolovievaResultsEnum.Norma;

            if (wristLength > 17)
                return IndexSolovievaResultsEnum.Hyper;
            throw new ArgumentException(IndexSolovievaQueryValidator.WristLengthIncorrectMessage);
        }
    }
}