using System;
using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.NaglerFormula
{
    /// <summary>
    /// Хендлер для получения <see cref="NaglerFormulaResponse"/> из <see cref="NaglerFormulaQuery"/>
    /// Формула для мужчин:
    /// Идеальный вес = 48 + 2.7 * (Рост * 0.393701 - 60)
    /// Формула для женщин:
    /// Идеальный вес = 45.3 + 2.27 * (Рост * 0.393701 - 60)
    /// </summary>
    public class NaglerFormulaHandler : IQueryHandler<NaglerFormulaQuery, NaglerFormulaResponse>
    {
        public async Task<NaglerFormulaResponse> Handle(NaglerFormulaQuery input)
        {
            await new NaglerFormulaQueryValidator().ValidateAndThrowAsync(input);

            return new NaglerFormulaResponse(GetResult(input));
        }

        /// <summary>
        /// Расчет формулы Наглера.
        /// </summary>
        /// <param name="input">NaglerFormulaQuery</param>
        /// <returns>Результат в кг.</returns>
        private double GetResult(NaglerFormulaQuery input)
        {
            return input.IsMen? Math.Round(48 + 2.7 * (input.Height * 0.393701 - 60), 2):
                                Math.Round(45.3 + 2.27 * (input.Height * 0.393701 - 60), 2);
        }
    }
}
