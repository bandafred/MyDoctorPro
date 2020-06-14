using System;
using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.HamviFormula
{
    /// <summary>
    /// Хендлер для получения <see cref="HamviFormulaResponse"/> из <see cref="HamviFormulaQuery"/>
    /// Формула для мужчин:
    /// Идеальный вес = 48 + 2.7 * (0.393701 * Рост - 60)
    /// Формула для женщин:
    /// Идеальный вес = 45.5 + 2.2 * (0.393701 * Рост - 60)
    /// </summary>
    public class HamviFormulaHandler : IQueryHandler<HamviFormulaQuery, HamviFormulaResponse>
    {
        public async Task<HamviFormulaResponse> Handle(HamviFormulaQuery input)
        {
            await new HamviFormulaQueryValidator().ValidateAndThrowAsync(input);

            return new HamviFormulaResponse(GetResult(input));
        }

        /// <summary>
        /// Расчет формулы Хамви.
        /// </summary>
        /// <param name="input">HamviFormulaQuery</param>
        /// <returns>Результат в кг.</returns>
        private double GetResult(HamviFormulaQuery input)
        {
            return input.IsMen
                ? Math.Round(48 + 2.7 * (0.393701 * input.Height - 60), 2)
                : Math.Round(45.5 + 2.2 * (0.393701 * input.Height - 60), 2);
        }
    }
}