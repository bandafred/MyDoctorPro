using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.Medical.AntihypertensiveTherapy
{
    /// <summary>
    /// Хендлер для получения <see cref="AntihypertensiveTherapyResponse"/> из <see cref="AntihypertensiveTherapyQuery"/>
    /// Позволяет подобрать группу гипотензивных препаратов  по ряду критериев
    /// </summary>
    public class AntihypertensiveTherapyHandler : IQueryHandler<AntihypertensiveTherapyQuery,
        AntihypertensiveTherapyResponse>
    {
        public async Task<AntihypertensiveTherapyResponse> Handle(
            AntihypertensiveTherapyQuery input)
        {
            await new AntihypertensiveTherapyQueryValidator().ValidateAndThrowAsync(input);

            if (!(input.Diseases?.Any() ?? false))
            {
                if (input.Pulse >= 90)
                    return new AntihypertensiveTherapyResponse(
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.BetaBlockers
                        });

                return new AntihypertensiveTherapyResponse();
            }

            var recommended = input.Diseases.SelectMany(i =>
                AntihypertensiveTherapyValues.RecommendedGroupOfDrugsListByDesease.TryGetValue(
                    (AntihypertensiveTherapyDiseaseEnum)i, out var res)
                    ? res
                    : new List<AntihypertensiveTherapyGroupOfDrugsEnum>()).ToList();

            var notRecommended = input.Diseases.SelectMany(i =>
                AntihypertensiveTherapyValues.NotRecommendedGroupOfDrugsListByDesease.TryGetValue(
                    (AntihypertensiveTherapyDiseaseEnum)i, out var res)
                    ? res
                    : new List<AntihypertensiveTherapyGroupOfDrugsEnum>()).ToList();

            var contraindicated = input.Diseases.SelectMany(i =>
                AntihypertensiveTherapyValues.ContraindicatedGroupOfDrugsListByDesease.TryGetValue(
                    (AntihypertensiveTherapyDiseaseEnum)i, out var res)
                    ? res
                    : new List<AntihypertensiveTherapyGroupOfDrugsEnum>()).ToList();

            if ((input.IsMen && input.Age >= 60) || (!input.IsMen && input.Age >= 55))
            {
                if (!recommended.Contains(AntihypertensiveTherapyGroupOfDrugsEnum.ThiazideDiuretics))
                    recommended.Add(AntihypertensiveTherapyGroupOfDrugsEnum.ThiazideDiuretics);
                if (!recommended.Contains(AntihypertensiveTherapyGroupOfDrugsEnum.DihydropyridineCalciumAntagonists))
                    recommended.Add(AntihypertensiveTherapyGroupOfDrugsEnum.DihydropyridineCalciumAntagonists);
                if (!recommended.Contains(AntihypertensiveTherapyGroupOfDrugsEnum.CalciumChannelBlockers))
                    recommended.Add(AntihypertensiveTherapyGroupOfDrugsEnum.CalciumChannelBlockers);
            }

            if (input.DiastolicBloodPressure < 90 && input.SystolicBloodPressure > 140)
            {
                if (!recommended.Contains(AntihypertensiveTherapyGroupOfDrugsEnum.ThiazideDiuretics))
                    recommended.Add(AntihypertensiveTherapyGroupOfDrugsEnum.ThiazideDiuretics);
                if (!recommended.Contains(AntihypertensiveTherapyGroupOfDrugsEnum.NonDihydropyridineCalciumAntagonists))
                    recommended.Add(AntihypertensiveTherapyGroupOfDrugsEnum.NonDihydropyridineCalciumAntagonists);
            }

            recommended = recommended.Distinct().Except(notRecommended).Except(contraindicated).ToList();
            notRecommended = notRecommended.Distinct().Except(contraindicated).ToList();
            contraindicated = contraindicated.Distinct().ToList();

            return new AntihypertensiveTherapyResponse(recommended, notRecommended, contraindicated);
        }
    }
}