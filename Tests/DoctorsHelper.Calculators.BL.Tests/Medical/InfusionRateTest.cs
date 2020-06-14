using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.Medical.InfusionRate;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.Medical
{
    [TestFixture]
    public class InfusionRateTest
    {
        [Test]
        public void InfusionRateTest_NotError()
        {
            // arrange
            var res = new InfusionRateQuery
            {
                VolumeSolution = 5,
                Dose = 5,
                BodyMass = 55,
                AmountDrug = 5
            };
            
            // act
            var handler = new InfusionRateHandler();
            var result = handler.Handle(res).Result;

            // assert
            Assert.AreEqual(16.5, result.SpeedInfusion);
            Assert.AreEqual(5.5, result.Drops);
        }

        [Test]
        public void InfusionRateTest_LessError()
        {
            // arrange
            var modelLittle = new InfusionRateQuery
            {
                AmountDrug = 0 ,
                VolumeSolution = 0,
                Dose = 0,
                BodyMass = 0
            };

            // act
            var handler = new InfusionRateHandler();
            var errorModel = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel != null);
            Assert.IsTrue(errorModel.Errors.Count == 4);
            Assert.IsTrue(errorModel.Errors.Contains(InfusionRateQueryValidator.AmountDrugIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(InfusionRateQueryValidator.BodyMassIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(InfusionRateQueryValidator.DoseIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(InfusionRateQueryValidator.VolumeSolutionIncorrectMessage));
        }

        [Test]
        public void InfusionRateTest_MoreError()
        {
            // arrange
            var modelLittle = new InfusionRateQuery
            {
                AmountDrug = 1000,
                VolumeSolution = 1000,
                Dose = 1000,
                BodyMass = 1000
            };

            // act
            var handler = new InfusionRateHandler();
            var errorModel = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel != null);
            Assert.IsTrue(errorModel.Errors.Count == 4);
            Assert.IsTrue(errorModel.Errors.Contains(InfusionRateQueryValidator.AmountDrugIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(InfusionRateQueryValidator.BodyMassIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(InfusionRateQueryValidator.DoseIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(InfusionRateQueryValidator.VolumeSolutionIncorrectMessage));
        }
    }
}
