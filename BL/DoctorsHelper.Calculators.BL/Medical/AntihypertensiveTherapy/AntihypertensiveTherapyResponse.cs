using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DoctorsHelper.Extensions;

namespace DoctorsHelper.Calculators.BL.Medical.AntihypertensiveTherapy
{
    /// <summary>
    /// Результат подбора гипотензивной терапии.
    /// </summary>
    public class AntihypertensiveTherapyResponse
    {
        public AntihypertensiveTherapyResponse(
            List<AntihypertensiveTherapyGroupOfDrugsEnum> recommended,
            List<AntihypertensiveTherapyGroupOfDrugsEnum> notRecommended,
            List<AntihypertensiveTherapyGroupOfDrugsEnum> contraindicated)
        {
            RecommendedGroupOfDrugs = recommended;
            NotRecommendedGroupOfDrugs = notRecommended;
            ContraindicatedGroupOfDrugs = contraindicated;
        }

        public AntihypertensiveTherapyResponse(List<AntihypertensiveTherapyGroupOfDrugsEnum> recommended)
        {
            RecommendedGroupOfDrugs = recommended;
        }

        /// <summary> Нет абсолютных противопоказаний для приема любой группы препаратов. </summary>
        public AntihypertensiveTherapyResponse()
        {
        }

        public const string GroupOfDrugsPreResponseString = "Группа препаратов - ";
        public const string RecommendedPostResponseString = " может быть рекомендована.";
        public const string NotRecommendedPostResponseString = " не рекомендована!";
        public const string ContraindicatedPostResponseString = " противопоказана!";

        public List<AntihypertensiveTherapyGroupOfDrugsEnum> RecommendedGroupOfDrugs { get; }
        public List<AntihypertensiveTherapyGroupOfDrugsEnum> NotRecommendedGroupOfDrugs { get; }
        public List<AntihypertensiveTherapyGroupOfDrugsEnum> ContraindicatedGroupOfDrugs { get; }

        public List<string> Recommended =>
            !(RecommendedGroupOfDrugs?.Any() ?? false) &&
            !(NotRecommendedGroupOfDrugs?.Any() ?? false) &&
            !(ContraindicatedGroupOfDrugs?.Any() ?? false)
                ? new List<string> { "Нет абсолютных противопоказаний для приема любой группы препаратов." }
                : RecommendedGroupOfDrugs?.Select(e =>
                        $"{GroupOfDrugsPreResponseString}{e.GetAttribute<DisplayAttribute>().Name}{RecommendedPostResponseString}")
                    .ToList();

        public List<string> NotRecommended =>
            NotRecommendedGroupOfDrugs?.Select(e =>
                    $"{GroupOfDrugsPreResponseString}{e.GetAttribute<DisplayAttribute>().Name}{NotRecommendedPostResponseString}")
                .ToList();

        public List<string> Contraindicated =>
            ContraindicatedGroupOfDrugs?.Select(e =>
                    $"{GroupOfDrugsPreResponseString}{e.GetAttribute<DisplayAttribute>().Name}{ContraindicatedPostResponseString}")
                .ToList();
    }
}
