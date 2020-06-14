using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.Medical.TimiScale
{
    /// <summary>
    /// Хендлер для получения <see cref="TimiScaleResponse"/> из <see cref="TimiScaleQuery"/>
    /// Шкала TIMI основана на исследованиях TIMI IIВ и ESSENCE.
    /// Она учитывает возраст, клиническую картину, изменения ЭКГ
    /// и повышение уровня маркеров некроза миокарда. Она учитывает
    /// возраст, клиническую картину, изменения ЭКГ и повышение уровня
    /// маркеров некроза миокарда. Рассчитать индекс TIMI проще,
    /// так как учитываются только 6 показателей, однако по точности он уступает индексу GRACE.
    /// Примечание: факторы риска атеросклероза – семейный анамнез,
    /// АГ, СД, гиперхолестеринемия, курение. К больным высокого риска
    /// следует отнести тех, у кого сумма баллов по системе TIMI превышает 4.
    /// Высокий балл по шкале TIMI говорит о высоком риске смерти, инфаркта
    /// миокарда и повторной ишемии, требующей реваскуляризации.Шкала оценки
    /// риска TIMI менее точна в предсказании событий, чем шкала GRACE.
    /// </summary>
    public class TimiScaleHandler : IQueryHandler<TimiScaleQuery, TimiScaleResponse>
    {
        public async Task<TimiScaleResponse> Handle(TimiScaleQuery input)
        {
            var count = 0;

            if (input.OldAge) count++;
            if (input.ThreeRisk) count++;
            if (input.Stenos) count++;
            if (input.LiftSt) count++;
            if (input.Stenocardia) count++;
            if (input.Aspirin) count++;
            if (input.Necroze) count++;

            var result = new TimiScaleResponse(GetResult(count));

            return result;
        }

        /// <summary>
        /// Рассчитывает индекс по шкале TIMI
        /// </summary>
        /// <returns>Индекс по шкале TIMI</returns>
        private static double GetResult(int count) =>
            count switch
            {
                0 => 4.7,
                1 => 4.7,
                2 => 8.3,
                3 => 13.2,
                4 => 19.9,
                5 => 26.2,
                6 => 40.9,
                7 => 40.9,
                _ => 0,
            };
    }
}