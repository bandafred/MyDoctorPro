using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.Medical.PotassiumDeficiency;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.Medical
{
    [TestFixture]
    public class PotassiumDeficiencyTest
    {
        [Test]
        public void PotassiumDeficiencyTest_NotError()
        {
            // arrange
            var norma = new PotassiumDeficiencyQuery
            {
                BodyMass = 55,
                BloodKaliumLevel = 15
            };

            // arrange
            var deficiency = new PotassiumDeficiencyQuery
            {
                BodyMass = 55,
                BloodKaliumLevel = 3
            };

            // act
            var handler = new PotassiumDeficiencyHandler();
            var result = handler.Handle(norma).Result.Result;
            var result2 = handler.Handle(deficiency).Result.Result;

            // assert
            Assert.AreEqual(PotassiumDeficiencyResponse.NotPotassiumDeficiencyString, result);
            Assert.IsTrue(result2.Contains(PotassiumDeficiencyResponse.PotassiumDeficiencyString));
        }

        [Test]
        public void PotassiumDeficiencyTest_LittleError()
        {
            // arrange
            var modelLittle = new PotassiumDeficiencyQuery
            {
                BodyMass = 0,
                BloodKaliumLevel = 0
            };


            // act
            var handler = new PotassiumDeficiencyHandler();
            var errorModel1 = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 2);
            Assert.IsTrue(errorModel1.Errors.Contains(PotassiumDeficiencyQueryValidator.BodyMassIncorrectMessage));
            Assert.IsTrue(errorModel1.Errors.Contains(PotassiumDeficiencyQueryValidator.KaliiIncorrectMessage));
        }

        [Test]
        public void PotassiumDeficiencyTest_MoreError()
        {
            // arrange
            var modelLittle = new PotassiumDeficiencyQuery
            {
                BodyMass = 1000,
                BloodKaliumLevel = 1000
            };


            // act
            var handler = new PotassiumDeficiencyHandler();
            var errorModel1 = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 2);
            Assert.IsTrue(errorModel1.Errors.Contains(PotassiumDeficiencyQueryValidator.BodyMassIncorrectMessage));
            Assert.IsTrue(errorModel1.Errors.Contains(PotassiumDeficiencyQueryValidator.KaliiIncorrectMessage));
        }
    }
}
