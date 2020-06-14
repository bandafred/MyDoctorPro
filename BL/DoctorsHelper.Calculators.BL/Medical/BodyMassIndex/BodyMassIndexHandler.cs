using System;
using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.Medical.BodyMassIndex
{
    /// <summary>
    /// Хендлер для получения <see cref="BodyMassIndexResponse"/> из <see cref="BodyMassIndexQuery"/>
    /// Индекс массы тела (англ. body mass index (BMI), ИМТ) —
    /// величина, позволяющая оценить степень соответствия массы человека
    /// и его роста и тем самым косвенно оценить, является ли масса недостаточной,
    /// нормальной или избыточной. Важен при определении показаний для необходимости
    /// лечения. Индекс массы тела рассчитывается по формуле:
    /// ИМТ = m / h^2,
    /// </summary>
    public class BodyMassIndexHandler : IQueryHandler<BodyMassIndexQuery, BodyMassIndexResponse>
    {
        public async Task<BodyMassIndexResponse> Handle(BodyMassIndexQuery input)
        {
            await new BodyMassIndexQueryValidator().ValidateAndThrowAsync(input);

            var result = new BodyMassIndexResponse(GetResult(input.Height,input.Weight));

            return result;
        }


        /// <summary>Возвращает ИМТ.</summary>
        /// <param name="height">Рост.</param>
        /// <param name="weight">Вес.</param>
        /// <returns>ИМТ.</returns>
        private double GetResult(double height, double weight)
        {
            //формула ИМТ
            return Math.Round(weight / ((height * height) / 10000), 1);
        }
    }
}