using System;
using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.MonnerotFormula
{
    /// <summary>
    /// Хендлер для получения <see cref="MonnerotFormulaResponse"/> из <see cref="MonnerotFormulaQuery"/>
    /// Идеальный вес = (Рост - 100 + (4 * Запястье ) ) / 2
    /// </summary>
    public class MonnerotFormulaHandler : IQueryHandler<MonnerotFormulaQuery, MonnerotFormulaResponse>
    {
        public async Task<MonnerotFormulaResponse> Handle(MonnerotFormulaQuery input)
        {
            await new MonnerotFormulaQueryValidator().ValidateAndThrowAsync(input);

            return new MonnerotFormulaResponse(GetResult(input));
        }

        /// <summary>
        /// Расчет формулы Моннерота-Думайна.
        /// </summary>
        /// <param name="input">MonnerotFormulaQuery</param>
        /// <returns>Результат в кг.</returns>
        private double GetResult(MonnerotFormulaQuery input)
        {
            return Math.Round(((input.Height - 100 + (4.0 * input.WristLength)) / 2), 2);
        }
    }
}
