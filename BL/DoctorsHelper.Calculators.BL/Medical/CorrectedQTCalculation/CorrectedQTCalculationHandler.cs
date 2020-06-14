using System;
using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.Medical.CorrectedQTCalculation
{
    /// <summary>
    /// Хендлер для получения <see cref="CorrectedQTCalculationResponse"/> из <see cref="CorrectedQTCalculationQuery"/>
    /// Расчет корригированного QT.
    /// </summary>
    public class
        CorrectedQTCalculationHandler : IQueryHandler<CorrectedQTCalculationQuery, CorrectedQTCalculationResponse>
    {
        public async Task<CorrectedQTCalculationResponse> Handle(CorrectedQTCalculationQuery input)
        {
            await new CorrectedQTCalculationQueryValidator().ValidateAndThrowAsync(input);

            var intervalRR = 60.0 / input.HeartRate;
            var bazett = input.IntervalQT / Math.Sqrt(intervalRR);
            var fridericia = input.IntervalQT / Math.Pow(intervalRR, 1.0 / 3); ;
            var framingham = input.IntervalQT + 0.154 * (1 - intervalRR) * 1000;
            var hodges = input.IntervalQT + 1.75 * (input.HeartRate - 60);


            var result = new CorrectedQTCalculationResponse(intervalRR, bazett, fridericia, framingham, hodges, input.HeartRate);

            return result;
        }
    }
}