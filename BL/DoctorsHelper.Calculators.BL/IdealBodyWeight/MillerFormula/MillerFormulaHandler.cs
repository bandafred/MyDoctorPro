using System;
using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.MillerFormula
{
    /// <summary>
    /// Хендлер для получения <see cref="MillerFormulaResponse"/> из <see cref="MillerFormulaQuery"/>
    /// Формула для мужчин:
    /// Идеальный вес = 56.2 + 1.41 * (0.393701 * Рост - 60)
    /// Формула для женщин:
    /// Идеальный вес = 53.1 + 1.36 * (0.393701 * Рост - 60)
    /// </summary>
    public class MillerFormulaHandler : IQueryHandler<MillerFormulaQuery, MillerFormulaResponse>
    {
        public async Task<MillerFormulaResponse> Handle(MillerFormulaQuery input)
        {
            await new MillerFormulaQueryValidator().ValidateAndThrowAsync(input);

            return new MillerFormulaResponse(GetResult(input));
        }

        /// <summary>
        /// Расчет формулы Миллера.
        /// </summary>
        /// <param name="input">MillerFormulaQuery</param>
        /// <returns>Результат в кг.</returns>
        private double GetResult(MillerFormulaQuery input)
        {
            return input.IsMen ?
                Math.Round(56.2 + 1.41 * (0.393701 * input.Height - 60), 2):
                Math.Round(53.1 + 1.36 * (0.393701 * input.Height - 60), 2);
        }
    }
}
