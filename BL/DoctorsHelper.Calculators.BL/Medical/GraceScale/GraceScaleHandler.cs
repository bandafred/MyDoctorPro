using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.Medical.GraceScale
{
    /// <summary>
    /// Хендлер для получения <see cref="GraceScaleResponse"/> из <see cref="GraceScaleQuery"/>
    /// Шкала GRACE (Global Registry of Acute Coronary Events) позволяет оценить риск летальности
    /// и развития инфаркта миокарда на госпитальном этапе и в течение последующих 6 месяцев, а
    /// также определить оптимальный способ лечения конкретного больного. В момент поступления в
    /// стационар у пациента с ОКС при помощи шкалы GRACE оценивается риск развития ближайших
    /// (в процессе госпитального лечения) негативных сердечно-сосудистых исходов (смерть, инфаркт миокарда)
    /// при условии выбора консервативного лечения.
    /// При выборе лечебной стратегии должны быть приняты во внимание такие факторы, как качество жизни,
    /// продолжительность госпитального лечения и потенциальный риск, ассоциирующийся с инвазивной или
    /// консервативной стратегией.Решение о необходимости и экстренности проведения коронарографии у
    /// пациентов с ОКСбпST определяется после проведения стратификации риска по шкале GRACE(IB).
    /// </summary>
    public class GraceScaleHandler : IQueryHandler<GraceScaleQuery, GraceScaleResponse>
    {
        public async Task<GraceScaleResponse> Handle(GraceScaleQuery input)
        {
            await new GraceScaleQueryValidator().ValidateAndThrowAsync(input);

            var index = GetAgeIndex(input.Age)
                        + GetHeartRateIndex(input.HeartRate)
                        + GetSystolicBloodPressureIndex(input.SystolicBloodPressure)
                        + GetCreatininIndex(input.Creatinin)
                        + input.Kilip
                        + GetHeartFailureIndex(input.HeartFailure)
                        + GetStSegmentDeviationIndex(input.StSegmentDeviation)
                        + GetHighLevelOfCardiacEnzymesIndex(input.HighLevelOfCardiacEnzymes);

            return new GraceScaleResponse(index);
        }

        private int GetAgeIndex(int age)
        {
            if (age < 30) return 0;
            if (age >= 30 & age <= 39) return 8;
            if (age >= 40 & age <= 49) return 25;
            if (age >= 50 & age <= 59) return 41;
            if (age >= 60 & age <= 69) return 58;
            if (age >= 70 & age <= 79) return 75;
            if (age >= 80 & age <= 89) return 91;
            return 100;
        }

        private int GetHeartRateIndex(int heartRate)
        {
            if (heartRate < 50) return 0;
            if (heartRate >= 50 & heartRate <= 69) return 3;
            if (heartRate >= 70 & heartRate <= 89) return 9;
            if (heartRate >= 90 & heartRate <= 109) return 15;
            if (heartRate >= 110 & heartRate <= 149) return 24;
            if (heartRate >= 150 & heartRate <= 199) return 38;
            return 46;
        }

        private int GetSystolicBloodPressureIndex(int sad)
        {
            if (sad < 80) return 58;
            if (sad >= 80 & sad <= 99) return 53;
            if (sad >= 100 & sad <= 119) return 43;
            if (sad >= 120 & sad <= 139) return 34;
            if (sad >= 140 & sad <= 159) return 24;
            if (sad >= 160 & sad <= 199) return 10;
            return 0;
        }

        private int GetCreatininIndex(double creatinin)
        {
            if (creatinin < 35.36) return 1;
            if (creatinin >= 35.36 & creatinin <= 70.71) return 4;
            if (creatinin >= 70.72 & creatinin <= 106.07) return 7;
            if (creatinin >= 106.08 & creatinin <= 141.43) return 10;
            if (creatinin >= 141.43 & creatinin <= 176.7) return 13;
            if (creatinin >= 176.8 & creatinin <= 353) return 21;
            return 28;
        }

        private int GetHeartFailureIndex(bool flag) => flag ? 39 : 0;

        private int GetStSegmentDeviationIndex(bool flag) => flag ? 28 : 0;

        private int GetHighLevelOfCardiacEnzymesIndex(bool flag) => flag ? 14 : 0;
    }
}