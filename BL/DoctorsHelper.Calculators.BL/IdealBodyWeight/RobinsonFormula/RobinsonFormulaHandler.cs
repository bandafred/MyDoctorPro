using System;
using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.RobinsonFormula
{
    /// <summary>
    /// Хендлер для получения <see cref="RobinsonFormulaResponse"/> из <see cref="RobinsonFormulaQuery"/>
    /// Формула для мужчин:
    /// Идеальный вес = 52 + 1.9 * (Рост * 0.393701 - 60)
    /// Формула для женщин:
    /// Идеальный вес = 49 + 1.7 * (Рост * 0.393701 - 60)
    /// </summary>
    public class RobinsonFormulaHandler : IQueryHandler<RobinsonFormulaQuery, RobinsonFormulaResponse>
    {
        public async Task<RobinsonFormulaResponse> Handle(RobinsonFormulaQuery input)
        {
            await new RobinsonFormulaQueryValidator().ValidateAndThrowAsync(input);

            return new RobinsonFormulaResponse(GetResult(input));
        }

        /// <summary>
        /// Расчет формулы Робинсона.
        /// </summary>
        /// <param name="input">RobinsonFormulaQuery</param>
        /// <returns>Результат в кг.</returns>
        private double GetResult(RobinsonFormulaQuery input)
        {
            return
                input.IsMen 
                    ? Math.Round(52 + 1.9 * (0.393701 * input.Height - 60), 2)
                    : Math.Round(49 + 1.7 * (0.393701 * input.Height - 60), 2);
        }
    }
}
