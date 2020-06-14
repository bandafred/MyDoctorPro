using System;
using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.MochammedFormula
{
    /// <summary>
    /// Хендлер для получения <see cref="MochammedFormulaResponse"/> из <see cref="MochammedFormulaQuery"/>
    /// Идеальный вес = Рост * Рост * 0.00225
    /// </summary>
    public class MochammedFormulaHandler : IQueryHandler<MochammedFormulaQuery, MochammedFormulaResponse>
    {
        public async Task<MochammedFormulaResponse> Handle(MochammedFormulaQuery input)
        {
            await new MochammedFormulaQueryValidator().ValidateAndThrowAsync(input);

            return new MochammedFormulaResponse(GetResult(input));
        }

        /// <summary>
        /// Расчет формулы Мохамеда.
        /// </summary>
        /// <param name="input">MochammedFormulaQuery</param>
        /// <returns>Результат в кг.</returns>
        private double GetResult(MochammedFormulaQuery input)
        {
            return Math.Round(input.Height * input.Height * 0.00225, 2);
        }
    }
}
