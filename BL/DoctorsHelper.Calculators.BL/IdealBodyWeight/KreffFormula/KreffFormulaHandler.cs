using System;
using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.KreffFormula
{
    /// <summary>
    /// Хендлер для получения <see cref="KreffFormulaResponse"/> из <see cref="KreffFormulaQuery"/>
    /// (Рост - 100 + (Возраст / 10)) * 0,9 * Коэффициент
    ///            Коэффициент телосложения:
    /// Коэффициент = 0,9 при обхвате запястья меньше 15 см
    /// Коэффициент = 1 при обхвате запястья от 15 см до 17 см
    /// Коэффициент = 1,1 при обхвате запястья более 17 см
    /// </summary>
    public class KreffFormulaHandler : IQueryHandler<KreffFormulaQuery, KreffFormulaResponse>
    {
        public async Task<KreffFormulaResponse> Handle(KreffFormulaQuery input)
        {
            await new KreffFormulaQueryValidator().ValidateAndThrowAsync(input);

            return new KreffFormulaResponse(GetResult(input));
        }

        /// <summary>
        /// Расчет формулы Креффа.
        /// </summary>
        /// <param name="input">KreffFormulaQuery</param>
        /// <returns>Результат в кг.</returns>
        private double GetResult(KreffFormulaQuery input)
        {
            return Math.Round((input.Height - 100 + (input.Age / 10)) * 0.9 * GetCoefficient(input.LenСarpus), 2);
        }

        private double GetCoefficient(int lenCarpus)
        {
            if (lenCarpus >= 3 && lenCarpus <= 15) return 0.9;
            if (lenCarpus >= 15 && lenCarpus <= 17) return 1;
            if (lenCarpus > 17 && lenCarpus <= 50) return 1.1;

            throw new ArgumentException(KreffFormulaQueryValidator.LenСarpusIncorrectMessage);
        }
    }
}
