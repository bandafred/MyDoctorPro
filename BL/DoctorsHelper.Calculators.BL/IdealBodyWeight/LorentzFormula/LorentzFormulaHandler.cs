using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.LorentzFormula
{
    /// <summary>
    /// Хендлер для получения <see cref="LorentzFormulaResponse"/> из <see cref="LorentzFormulaQuery"/>
    /// Формула Лоренца для женщин:
    /// Рост - 100 - ((Рост - 150) / 2)
    /// Формула Лоренца для мужчин:
    /// Рост - 100 - ((Рост - 150) / 4)
    /// </summary>
    public class LorentzFormulaHandler : IQueryHandler<LorentzFormulaQuery, LorentzFormulaResponse>
    {
        public async Task<LorentzFormulaResponse> Handle(LorentzFormulaQuery input)
        {
            await new LorentzFormulaQueryValidator().ValidateAndThrowAsync(input);

            return new LorentzFormulaResponse(GetResult(input));
        }

        /// <summary>
        /// Расчет формулы Лоренца.
        /// </summary>
        /// <param name="input">LorentzFormulaQuery</param>
        /// <returns>Результат в кг.</returns>
        private int GetResult(LorentzFormulaQuery input)
        {
            return input.Height - 100 - ((input.Height - 150) / (input.IsMen ? 4 : 2));
        }
    }
}
