using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.Medical.InfusionRate
{
    /// <summary>
    /// Расчет скорости инфузии.
    /// </summary>
    public class InfusionRateHandler : IQueryHandler<InfusionRateQuery, InfusionRateResponse>
    {
        public async Task<InfusionRateResponse> Handle(InfusionRateQuery input)
        {
            await new InfusionRateQueryValidator().ValidateAndThrowAsync(input);

            var calculate = GetResult(input.BodyMass, input.AmountDrug, input.Dose, input.VolumeSolution);

            var result = new InfusionRateResponse(calculate.speedInfusion, calculate.drops);

            return result;
        }

        /// <summary>
        /// Расчет скорости инфузии.
        /// </summary>
        /// <param name="bodyMass">Масса тела, кг.</param>
        /// <param name="amountDrug">Количество препарата, мг.</param>
        /// <param name="dose">Объем раствора, мл.</param>
        /// <param name="volumeSolution">Доза препарата мкг*кг/мин.</param>
        /// <returns>Кортеж (double speedInfusion, double drops).</returns>
        private (double speedInfusion, double drops) GetResult(int bodyMass, double amountDrug, double dose, double volumeSolution)
        {
            var speedInfusion = (bodyMass * dose) /((amountDrug) * (1000 / volumeSolution)) * 60;
            var drops = speedInfusion * 20 / 60;

            return (speedInfusion, drops);
        }
    }
}