using System;
using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.CuperFormula
{
    /// <summary>
    /// Хендлер для получения <see cref="CuperFormulaResponse"/> из <see cref="CuperFormulaQuery"/>
    /// Формула Купера для мужчин:
    /// Идеальный вес = 0.713 * Рост - 58.0
    /// Формула Купера для женщин:
    /// Идеальный вес = 0.624 * Рост - 48.9
    /// </summary>
    public class CuperFormulaHandler : IQueryHandler<CuperFormulaQuery, CuperFormulaResponse>
    {
        public async Task<CuperFormulaResponse> Handle(CuperFormulaQuery input)
        {
            await new CuperFormulaQueryValidator().ValidateAndThrowAsync(input);

            return new CuperFormulaResponse(GetResult(input));
        }

        /// <summary>
        /// Расчет формулы Купера.
        /// </summary>
        /// <param name="input">CuperFormulaQuery</param>
        /// <returns>Результат в кг.</returns>
        private double GetResult(CuperFormulaQuery input)
        {
            return input.IsMen ? Math.Round(0.713 * input.Height - 58, 2) : Math.Round(0.624 * input.Height - 48.9, 2);
        }
    }
}
