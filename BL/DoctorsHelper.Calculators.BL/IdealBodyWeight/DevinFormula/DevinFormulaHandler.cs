using System;
using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.DevinFormula
{
    /// <summary>
    /// Хендлер для получения <see cref="DevinFormulaResponse"/> из <see cref="DevinFormulaQuery"/>
    /// Формула для мужчин:
    /// Идеальный вес = 50 + 2.3 * (0.393701 * Рост - 60)
    /// Формула для женщин:
    /// Идеальный вес = 45.5 + 2.3 * (0.393701 * Рост - 60)
    /// </summary>
    public class DevinFormulaHandler : IQueryHandler<DevinFormulaQuery, DevinFormulaResponse>
    {
        public async Task<DevinFormulaResponse> Handle(DevinFormulaQuery input)
        {
            await new DevinFormulaQueryValidator().ValidateAndThrowAsync(input);

            return new DevinFormulaResponse(GetResult(input));
        }

        /// <summary>
        /// Расчет формулы Девина.
        /// </summary>
        /// <param name="input">DevinFormulaQuery</param>
        /// <returns>Результат в кг.</returns>
        private double GetResult(DevinFormulaQuery input)
        {
            return Math.Round((input.IsMen ? 50 : 45.5) + 2.3 * (0.393701 * input.Height - 60), 2);
        }
    }
}
