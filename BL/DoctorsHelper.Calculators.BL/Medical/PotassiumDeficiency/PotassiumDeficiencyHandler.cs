using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.Medical.PotassiumDeficiency
{
    /// <summary>
    /// Хендлер для получения <see cref="PotassiumDeficiencyResponse"/> из <see cref="PotassiumDeficiencyQuery"/>
    /// Расчет дефицита калия в плазме крови.
    /// </summary>
    public class PotassiumDeficiencyHandler : IQueryHandler<PotassiumDeficiencyQuery, PotassiumDeficiencyResponse>
    {
        public async Task<PotassiumDeficiencyResponse> Handle(PotassiumDeficiencyQuery input)
        {
            await new PotassiumDeficiencyQueryValidator().ValidateAndThrowAsync(input);

            var result = new PotassiumDeficiencyResponse(GetResult(input.BloodKaliumLevel, input.BodyMass));

            return result;
        }


        /// <summary>
        /// Расчет дефицита калия в плазме крови.
        /// </summary>
        /// <param name="kalii">Калий крови.</param>
        /// <param name="bodyMass">Масса тела.</param>
        /// <returns>Расчет индекса.</returns>
        private double GetResult(double bloodKaliumLevel, double bodyMass)
        {
            return (5 - bloodKaliumLevel) * 0.2 * bodyMass;
        }
    }
}