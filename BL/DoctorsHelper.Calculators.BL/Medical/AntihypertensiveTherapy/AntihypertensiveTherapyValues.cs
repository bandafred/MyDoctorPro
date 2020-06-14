using System.Collections.Generic;

namespace DoctorsHelper.Calculators.BL.Medical.AntihypertensiveTherapy
{
    public static class AntihypertensiveTherapyValues
    {
        /// <summary> Рекомендованные препараты </summary>
        public static readonly Dictionary<AntihypertensiveTherapyDiseaseEnum,
                List<AntihypertensiveTherapyGroupOfDrugsEnum>>
            RecommendedGroupOfDrugsListByDesease =
                new Dictionary<AntihypertensiveTherapyDiseaseEnum,
                    List<AntihypertensiveTherapyGroupOfDrugsEnum>>()
                {
                    {
                        AntihypertensiveTherapyDiseaseEnum.CoronaryHeartDisease,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.NonDihydropyridineCalciumAntagonists,
                            AntihypertensiveTherapyGroupOfDrugsEnum.DihydropyridineCalciumAntagonists,
                            AntihypertensiveTherapyGroupOfDrugsEnum.BetaBlockers,
                            AntihypertensiveTherapyGroupOfDrugsEnum.CalciumChannelBlockers,
                            AntihypertensiveTherapyGroupOfDrugsEnum.InhibitorsOfAdenosineConvertingEnzyme
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.LeftVentricularHypertrophy,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.DihydropyridineCalciumAntagonists,
                            AntihypertensiveTherapyGroupOfDrugsEnum.CalciumChannelBlockers,
                            AntihypertensiveTherapyGroupOfDrugsEnum.InhibitorsOfAdenosineConvertingEnzyme
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.AtrialFibrillation,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.CalciumChannelBlockers,
                            AntihypertensiveTherapyGroupOfDrugsEnum.InhibitorsOfAdenosineConvertingEnzyme
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.Diabetes,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.CalciumChannelBlockers,
                            AntihypertensiveTherapyGroupOfDrugsEnum.InhibitorsOfAdenosineConvertingEnzyme
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.MyocardialInfarction,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.AldosteroneAntagonists,
                            AntihypertensiveTherapyGroupOfDrugsEnum.BetaBlockers
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.KidneyDamage,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.CalciumChannelBlockers,
                            AntihypertensiveTherapyGroupOfDrugsEnum.InhibitorsOfAdenosineConvertingEnzyme
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.ChronicHeartFailure,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.LoopDiuretics,
                            AntihypertensiveTherapyGroupOfDrugsEnum.AldosteroneAntagonists,
                            AntihypertensiveTherapyGroupOfDrugsEnum.ThiazideDiuretics,
                            AntihypertensiveTherapyGroupOfDrugsEnum.BetaBlockers,
                            AntihypertensiveTherapyGroupOfDrugsEnum.CalciumChannelBlockers,
                            AntihypertensiveTherapyGroupOfDrugsEnum.InhibitorsOfAdenosineConvertingEnzyme
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.ProteinInTheUrine,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.CalciumChannelBlockers,
                            AntihypertensiveTherapyGroupOfDrugsEnum.InhibitorsOfAdenosineConvertingEnzyme
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.AtherosclerosisOfTheCarotidAndCoronaryArteries,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.NonDihydropyridineCalciumAntagonists,
                            AntihypertensiveTherapyGroupOfDrugsEnum.DihydropyridineCalciumAntagonists,
                            AntihypertensiveTherapyGroupOfDrugsEnum.InhibitorsOfAdenosineConvertingEnzyme
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.Glaucoma,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.BetaBlockers
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.Pregnancy,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.DihydropyridineCalciumAntagonists,
                            AntihypertensiveTherapyGroupOfDrugsEnum.BetaBlockers
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.Tachyarrhythmia,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.NonDihydropyridineCalciumAntagonists,
                            AntihypertensiveTherapyGroupOfDrugsEnum.BetaBlockers
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.ChronicObstructivePulmonaryDisease,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.BronchialAsthma,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.ChronicRenalFailure,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.LoopDiuretics
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.MetabolicSyndrome,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.CalciumChannelBlockers,
                            AntihypertensiveTherapyGroupOfDrugsEnum.InhibitorsOfAdenosineConvertingEnzyme
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.BilateralRenalArteryStenosis,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum
                            .CoughFromTakingAngiotensinConvertingEnzymeInhibitors,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.CalciumChannelBlockers
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.Gout,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.AtrioventricularBlockOfTheSecondOrThirdDegree,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.Hyperkalemia,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.AngioneuroticEdema,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                };

        /// <summary> Противопоказанные препараты </summary>
        public static readonly Dictionary<AntihypertensiveTherapyDiseaseEnum,
                List<AntihypertensiveTherapyGroupOfDrugsEnum>>
            ContraindicatedGroupOfDrugsListByDesease =
                new Dictionary<AntihypertensiveTherapyDiseaseEnum,
                    List<AntihypertensiveTherapyGroupOfDrugsEnum>>()
                {
                    {
                        AntihypertensiveTherapyDiseaseEnum.CoronaryHeartDisease,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.LeftVentricularHypertrophy,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.AtrialFibrillation,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.Diabetes,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.MyocardialInfarction,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.KidneyDamage,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.ChronicHeartFailure,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.NonDihydropyridineCalciumAntagonists
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.ProteinInTheUrine,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.AtherosclerosisOfTheCarotidAndCoronaryArteries,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.Glaucoma,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.Pregnancy,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.CalciumChannelBlockers,
                            AntihypertensiveTherapyGroupOfDrugsEnum.InhibitorsOfAdenosineConvertingEnzyme
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.Tachyarrhythmia,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.ChronicObstructivePulmonaryDisease,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.BronchialAsthma,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.ChronicRenalFailure,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.AldosteroneAntagonists
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.MetabolicSyndrome,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.BilateralRenalArteryStenosis,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.CalciumChannelBlockers,
                            AntihypertensiveTherapyGroupOfDrugsEnum.InhibitorsOfAdenosineConvertingEnzyme
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum
                            .CoughFromTakingAngiotensinConvertingEnzymeInhibitors,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.Gout,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.ThiazideDiuretics
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.AtrioventricularBlockOfTheSecondOrThirdDegree,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.BetaBlockers,
                            AntihypertensiveTherapyGroupOfDrugsEnum.NonDihydropyridineCalciumAntagonists
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.Hyperkalemia,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.AldosteroneAntagonists,
                            AntihypertensiveTherapyGroupOfDrugsEnum.CalciumChannelBlockers,
                            AntihypertensiveTherapyGroupOfDrugsEnum.InhibitorsOfAdenosineConvertingEnzyme
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.AngioneuroticEdema,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.InhibitorsOfAdenosineConvertingEnzyme
                        }
                    },
                };

        /// <summary> Нерекомендованные препараты </summary>
        public static readonly Dictionary<AntihypertensiveTherapyDiseaseEnum,
                List<AntihypertensiveTherapyGroupOfDrugsEnum>>
            NotRecommendedGroupOfDrugsListByDesease =
                new Dictionary<AntihypertensiveTherapyDiseaseEnum,
                    List<AntihypertensiveTherapyGroupOfDrugsEnum>>()
                {
                    {
                        AntihypertensiveTherapyDiseaseEnum.CoronaryHeartDisease,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.LeftVentricularHypertrophy,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.AtrialFibrillation,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.Diabetes,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.MyocardialInfarction,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.KidneyDamage,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.ChronicHeartFailure,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.DihydropyridineCalciumAntagonists
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.ProteinInTheUrine,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.AtherosclerosisOfTheCarotidAndCoronaryArteries,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.Glaucoma,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.Pregnancy,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.ThiazideDiuretics
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.Tachyarrhythmia,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.DihydropyridineCalciumAntagonists
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.ChronicObstructivePulmonaryDisease,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.BetaBlockers
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.BronchialAsthma,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.ChronicRenalFailure,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.MetabolicSyndrome,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.ThiazideDiuretics,
                            AntihypertensiveTherapyGroupOfDrugsEnum.BetaBlockers
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.BilateralRenalArteryStenosis,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum
                            .CoughFromTakingAngiotensinConvertingEnzymeInhibitors,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {
                            AntihypertensiveTherapyGroupOfDrugsEnum.InhibitorsOfAdenosineConvertingEnzyme
                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.Gout,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.AtrioventricularBlockOfTheSecondOrThirdDegree,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.Hyperkalemia,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                    {
                        AntihypertensiveTherapyDiseaseEnum.AngioneuroticEdema,
                        new List<AntihypertensiveTherapyGroupOfDrugsEnum>()
                        {

                        }
                    },
                };
    }
}

