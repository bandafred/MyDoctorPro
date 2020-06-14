using System.Collections.Generic;
using System.Linq;
using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.Medical.AntihypertensiveTherapy;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.Medical
{
    [TestFixture]
    public class AntihypertensiveTherapyTest
    {
        [Test]
        public void AntihypertensiveTherapyTest_InhibitorsOfAdenosineConvertingEnzyme()
        {
            // arrange
            var recommendedModel = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 90,
                DiastolicBloodPressure = 90,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.CoronaryHeartDisease // 0
                }
            };

            

            var contraindicatedModel = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 90,
                DiastolicBloodPressure = 90,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.Pregnancy // 10
                }
            };

            var notRecommendedModel = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 90,
                DiastolicBloodPressure = 90,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.CoughFromTakingAngiotensinConvertingEnzymeInhibitors // 17
                }
            };

            // act
            var handler = new AntihypertensiveTherapyHandler();
            var recommendedResult = handler.Handle(recommendedModel).Result.RecommendedGroupOfDrugs;
            var contraindicatedResult = handler.Handle(contraindicatedModel).Result.ContraindicatedGroupOfDrugs;
            var notRecommendedResult = handler.Handle(notRecommendedModel).Result.NotRecommendedGroupOfDrugs;

            // assert
            Assert.IsTrue(recommendedResult.Contains(AntihypertensiveTherapyGroupOfDrugsEnum
                .InhibitorsOfAdenosineConvertingEnzyme));
            Assert.IsTrue(contraindicatedResult.Contains(AntihypertensiveTherapyGroupOfDrugsEnum
                .InhibitorsOfAdenosineConvertingEnzyme));
            Assert.IsTrue(notRecommendedResult.Contains(AntihypertensiveTherapyGroupOfDrugsEnum
                .InhibitorsOfAdenosineConvertingEnzyme));
        }

        [Test]
        public void AntihypertensiveTherapyTest_CalciumChannelBlockers()
        {
            // arrange
            var recommendedModel = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 90,
                DiastolicBloodPressure = 90,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.CoronaryHeartDisease // 0
                }
            };

            var contraindicatedModel = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 90,
                DiastolicBloodPressure = 90,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.Pregnancy // 10
                }
            };

            // act
            var handler = new AntihypertensiveTherapyHandler();
            var recommendedResult = handler.Handle(recommendedModel).Result.RecommendedGroupOfDrugs;
            var contraindicatedResult = handler.Handle(contraindicatedModel).Result.ContraindicatedGroupOfDrugs;

            // assert
            Assert.IsTrue(recommendedResult.Contains(AntihypertensiveTherapyGroupOfDrugsEnum.CalciumChannelBlockers));
            Assert.IsTrue(contraindicatedResult.Contains(AntihypertensiveTherapyGroupOfDrugsEnum.CalciumChannelBlockers));
        }

        [Test]
        public void AntihypertensiveTherapyTest_BetaBlockers()
        {
            // arrange
            var recommendedModel = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 90,
                DiastolicBloodPressure = 90,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.CoronaryHeartDisease // 0
                }
            };

            var contraindicatedModel = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 90,
                DiastolicBloodPressure = 90,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.AtrioventricularBlockOfTheSecondOrThirdDegree // 19
                }
            };

            var notRecommendedModel = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 90,
                DiastolicBloodPressure = 90,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.ChronicObstructivePulmonaryDisease // 12
                }
            };

            var pilseBig = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 100,
                DiastolicBloodPressure = 90,
            };

            // act
            var handler = new AntihypertensiveTherapyHandler();
            var recommendedResult = handler.Handle(recommendedModel).Result.RecommendedGroupOfDrugs;
            var contraindicatedResult = handler.Handle(contraindicatedModel).Result.ContraindicatedGroupOfDrugs;
            var notRecommendedResult = handler.Handle(notRecommendedModel).Result.NotRecommendedGroupOfDrugs;
            var resultPilseBig = handler.Handle(pilseBig).Result.RecommendedGroupOfDrugs;

            // assert
            Assert.IsTrue(recommendedResult.Contains(AntihypertensiveTherapyGroupOfDrugsEnum.BetaBlockers));
            Assert.IsTrue(contraindicatedResult.Contains(AntihypertensiveTherapyGroupOfDrugsEnum.BetaBlockers));
            Assert.IsTrue(notRecommendedResult.Contains(AntihypertensiveTherapyGroupOfDrugsEnum.BetaBlockers));
            Assert.IsTrue(resultPilseBig.Contains(AntihypertensiveTherapyGroupOfDrugsEnum.BetaBlockers));
        }

        [Test]
        public void AntihypertensiveTherapyTest_DihydropyridineCalciumAntagonists()
        {
            // arrange
            var recommendedModel = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 90,
                DiastolicBloodPressure = 90,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.CoronaryHeartDisease // 0
                }
            };

            var notRecommendedModel = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 90,
                DiastolicBloodPressure = 90,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.ChronicHeartFailure // 6
                }
            };

            // act
            var handler = new AntihypertensiveTherapyHandler();
            var recommendedResult = handler.Handle(recommendedModel).Result.RecommendedGroupOfDrugs;
            var notRecommendedResult = handler.Handle(notRecommendedModel).Result.NotRecommendedGroupOfDrugs;

            // assert
            Assert.IsTrue(recommendedResult.Contains(AntihypertensiveTherapyGroupOfDrugsEnum.DihydropyridineCalciumAntagonists));
            Assert.IsTrue(notRecommendedResult.Contains(AntihypertensiveTherapyGroupOfDrugsEnum.DihydropyridineCalciumAntagonists));
        }

        [Test]
        public void AntihypertensiveTherapyTest_NonDihydropyridineCalciumAntagonists()
        {
            // arrange
            var recommendedModel = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 90,
                DiastolicBloodPressure = 90,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.CoronaryHeartDisease // 0
                }
            };

            var contraindicatedModel = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 90,
                DiastolicBloodPressure = 90,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.ChronicHeartFailure // 6
                }
            };

            // act
            var handler = new AntihypertensiveTherapyHandler();
            var recommendedResult = handler.Handle(recommendedModel).Result.RecommendedGroupOfDrugs;
            var contraindicatedResult = handler.Handle(contraindicatedModel).Result.ContraindicatedGroupOfDrugs;

            // assert
            Assert.IsTrue(recommendedResult.Contains(AntihypertensiveTherapyGroupOfDrugsEnum.NonDihydropyridineCalciumAntagonists));
            Assert.IsTrue(contraindicatedResult.Contains(AntihypertensiveTherapyGroupOfDrugsEnum.NonDihydropyridineCalciumAntagonists));
        }

        [Test]
        public void AntihypertensiveTherapyTest_ThiazideDiuretics()
        {
            // arrange
            var recommendedModel = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 90,
                DiastolicBloodPressure = 90,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.ChronicHeartFailure // 6
                }
            };

            var contraindicatedModel = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 90,
                DiastolicBloodPressure = 90,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.Gout // 18
                }
            };

            var notRecommendedModel = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 90,
                DiastolicBloodPressure = 90,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.MetabolicSyndrome // 15
                }
            };

            // act
            var handler = new AntihypertensiveTherapyHandler();
            var recommendedResult = handler.Handle(recommendedModel).Result.RecommendedGroupOfDrugs;
            var contraindicatedResult = handler.Handle(contraindicatedModel).Result.ContraindicatedGroupOfDrugs;
            var notRecommendedResult = handler.Handle(notRecommendedModel).Result.NotRecommendedGroupOfDrugs;

            // assert
            Assert.IsTrue(recommendedResult.Contains(AntihypertensiveTherapyGroupOfDrugsEnum.ThiazideDiuretics));
            Assert.IsTrue(contraindicatedResult.Contains(AntihypertensiveTherapyGroupOfDrugsEnum.ThiazideDiuretics));
            Assert.IsTrue(notRecommendedResult.Contains(AntihypertensiveTherapyGroupOfDrugsEnum.ThiazideDiuretics));
        }

        [Test]
        public void AntihypertensiveTherapyTest_AldosteroneAntagonists()
        {
            // arrange
            var recommendedModel = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 90,
                DiastolicBloodPressure = 90,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.ChronicHeartFailure // 6
                }
            };

            var contraindicatedModel = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 90,
                DiastolicBloodPressure = 90,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.ChronicRenalFailure // 14
                }
            };


            // act
            var handler = new AntihypertensiveTherapyHandler();
            var recommendedResult = handler.Handle(recommendedModel).Result.RecommendedGroupOfDrugs;
            var contraindicatedResult = handler.Handle(contraindicatedModel).Result.ContraindicatedGroupOfDrugs;

            // assert
            Assert.IsTrue(recommendedResult.Contains(AntihypertensiveTherapyGroupOfDrugsEnum.AldosteroneAntagonists));
            Assert.IsTrue(contraindicatedResult.Contains(AntihypertensiveTherapyGroupOfDrugsEnum.AldosteroneAntagonists));
        }

        [Test]
        public void AntihypertensiveTherapyTest_LoopDiuretics()
        {
            // arrange
            var recommendedModel = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 90,
                DiastolicBloodPressure = 90,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.ChronicHeartFailure // 6
                }
            };

            // act
            var handler = new AntihypertensiveTherapyHandler();
            var recommendedResult = handler.Handle(recommendedModel).Result.RecommendedGroupOfDrugs;

            // assert
            Assert.IsTrue(recommendedResult.Contains(AntihypertensiveTherapyGroupOfDrugsEnum.LoopDiuretics));
        }

        [Test]
        public void AntihypertensiveTherapyTest_AgeMoreOrLittleError()
        {
            // arrange
            var modelLittle = new AntihypertensiveTherapyQuery
            {
                Age = 0,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 90,
                DiastolicBloodPressure = 90,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.ProteinInTheUrine // 7
                }
            };

            var modelMore = new AntihypertensiveTherapyQuery
            {
                Age = 151,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 90,
                DiastolicBloodPressure = 90,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.ProteinInTheUrine // 7
                }
            };

            // act
            var handler = new AntihypertensiveTherapyHandler();
            var errorModel1 = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();
            var errorModel2 = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 1);
            Assert.IsTrue(errorModel1.Errors.Contains(AntihypertensiveTherapyQueryValidator.AgeIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 1);
            Assert.IsTrue(errorModel2.Errors.Contains(AntihypertensiveTherapyQueryValidator.AgeIncorrectMessage));
        }

        [Test]
        public void AntihypertensiveTherapyTest_DiastolicBloodPressureMoreOrLittleError()
        {
            // arrange
            var modelLittle = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 90,
                DiastolicBloodPressure = 0,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.ProteinInTheUrine // 7
                }
            };

            var modelMore = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 90,
                DiastolicBloodPressure = 351,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.ProteinInTheUrine // 7
                }
            };

            // act
            var handler = new AntihypertensiveTherapyHandler();
            var errorModel1 = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();
            var errorModel2 = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 1);
            Assert.IsTrue(errorModel1.Errors.Contains(AntihypertensiveTherapyQueryValidator.DiastolicBloodPressureIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 1);
            Assert.IsTrue(errorModel2.Errors.Contains(AntihypertensiveTherapyQueryValidator.DiastolicBloodPressureIncorrectMessage));
        }

        [Test]
        public void AntihypertensiveTherapyTest_SystolicBloodPressureMoreOrLittleError()
        {
            // arrange
            var modelLittle = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 0,
                Pulse = 90,
                DiastolicBloodPressure = 90,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.ProteinInTheUrine // 7
                }
            };

            var modelMore = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 351,
                Pulse = 90,
                DiastolicBloodPressure = 90,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.ProteinInTheUrine // 7
                }
            };

            // act
            var handler = new AntihypertensiveTherapyHandler();
            var errorModel1 = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();
            var errorModel2 = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 1);
            Assert.IsTrue(errorModel1.Errors.Contains(AntihypertensiveTherapyQueryValidator.SystolicBloodPressureIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 1);
            Assert.IsTrue(errorModel2.Errors.Contains(AntihypertensiveTherapyQueryValidator.SystolicBloodPressureIncorrectMessage));
        }

        [Test]
        public void AntihypertensiveTherapyTest_PulseMoreOrLittleError()
        {
            // arrange
            var modelLittle = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 0,
                DiastolicBloodPressure = 90,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.ProteinInTheUrine // 7
                }
            };

            var modelMore = new AntihypertensiveTherapyQuery
            {
                Age = 12,
                IsMen = false,
                SystolicBloodPressure = 180,
                Pulse = 351,
                DiastolicBloodPressure = 90,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.ProteinInTheUrine // 7
                }
            };

            // act
            var handler = new AntihypertensiveTherapyHandler();
            var errorModel1 = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();
            var errorModel2 = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 1);
            Assert.IsTrue(errorModel1.Errors.Contains(AntihypertensiveTherapyQueryValidator.PulseIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 1);
            Assert.IsTrue(errorModel2.Errors.Contains(AntihypertensiveTherapyQueryValidator.PulseIncorrectMessage));
        }

        [Test]
        public void AntihypertensiveTherapyTest_AllMoreOrLittleError()
        {
            // arrange
            var modelLittle = new AntihypertensiveTherapyQuery
            {
                Age = 0,
                IsMen = false,
                SystolicBloodPressure = 0,
                Pulse = 0,
                DiastolicBloodPressure = 0,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.ProteinInTheUrine // 7
                }
            };

            var modelMore = new AntihypertensiveTherapyQuery
            {
                Age = 151,
                IsMen = false,
                SystolicBloodPressure = 351,
                Pulse = 351,
                DiastolicBloodPressure = 351,
                Diseases = new List<int>
                {
                    (int) AntihypertensiveTherapyDiseaseEnum.ProteinInTheUrine // 7
                }
            };

            // act
            var handler = new AntihypertensiveTherapyHandler();
            var errorModel1 = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();
            var errorModel2 = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 4);
            Assert.IsTrue(errorModel1.Errors.Contains(AntihypertensiveTherapyQueryValidator.AgeIncorrectMessage));
            Assert.IsTrue(errorModel1.Errors.Contains(AntihypertensiveTherapyQueryValidator.DiastolicBloodPressureIncorrectMessage));
            Assert.IsTrue(errorModel1.Errors.Contains(AntihypertensiveTherapyQueryValidator.SystolicBloodPressureIncorrectMessage));
            Assert.IsTrue(errorModel1.Errors.Contains(AntihypertensiveTherapyQueryValidator.PulseIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 4);
            Assert.IsTrue(errorModel1.Errors.Contains(AntihypertensiveTherapyQueryValidator.AgeIncorrectMessage));
            Assert.IsTrue(errorModel1.Errors.Contains(AntihypertensiveTherapyQueryValidator.DiastolicBloodPressureIncorrectMessage));
            Assert.IsTrue(errorModel1.Errors.Contains(AntihypertensiveTherapyQueryValidator.SystolicBloodPressureIncorrectMessage));
            Assert.IsTrue(errorModel1.Errors.Contains(AntihypertensiveTherapyQueryValidator.PulseIncorrectMessage));
        }
    }
}
