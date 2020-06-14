using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.EgorovaTable
{
    /// <summary>
    /// Хендлер для получения <see cref="EgorovaTableResponse"/> из <see cref="EgorovaTableQuery"/>
    /// Формула для мужчин:
    /// Идеальный вес = 48 + 2.7 * (Рост * 0.393701 - 60)
    /// Формула для женщин:
    /// Идеальный вес = 45.3 + 2.27 * (Рост * 0.393701 - 60)
    /// </summary>
    public class EgorovaTableHandler : IQueryHandler<EgorovaTableQuery, EgorovaTableResponse>
    {
        public async Task<EgorovaTableResponse> Handle(EgorovaTableQuery input)
        {
            await new EgorovaTableQueryValidator().ValidateAndThrowAsync(input);

            return new EgorovaTableResponse(GetResult(input));
        }

        /// <summary>
        /// Таблица Егорова-Левитского.
        /// </summary>
        /// <param name="input">EgorovaTableQuery</param>
        /// <returns>Результат в кг.</returns>
        private double GetResult(EgorovaTableQuery input)
        {
            if (input.Age >= 20 & input.Age <= 29)
                return input.IsMen
                    ? EgorovaTable.ManOld20_29.First(x => x.Key == input.Height).Value
                    : EgorovaTable.WomanOld20_29.First(x => x.Key == input.Height).Value;

            if (input.Age >= 30 & input.Age <= 39)
                return input.IsMen
                    ? EgorovaTable.ManOld30_39.First(x => x.Key == input.Height).Value
                    : EgorovaTable.WomanOld30_39.First(x => x.Key == input.Height).Value;

            if (input.Age >= 40 & input.Age <= 49)
                return input.IsMen
                    ? EgorovaTable.ManOld40_49.First(x => x.Key == input.Height).Value
                    : EgorovaTable.WomanOld40_49.First(x => x.Key == input.Height).Value;

            if (input.Age >= 50 & input.Age <= 59)
                return input.IsMen
                    ? EgorovaTable.ManOld50_59.First(x => x.Key == input.Height).Value
                    : EgorovaTable.WomanOld50_59.First(x => x.Key == input.Height).Value;

            if (input.Age >= 60 & input.Age <= 69)
                return input.IsMen
                    ? EgorovaTable.ManOld60_69.First(x => x.Key == input.Height).Value
                    : EgorovaTable.WomanOld60_69.First(x => x.Key == input.Height).Value;

            throw new ArgumentException(EgorovaTableQueryValidator.AgeIncorrectMessage);
        }
    }
}
