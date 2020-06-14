using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.Medical.CorrectedQTCalculation;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.Medical
{
    [TestFixture]
    public class CorrectedQTCalculationTest
    {
        [Test]
        public void CorrectedQTCalculationTest_NotError()
        {
            // arrange
            var res = new CorrectedQTCalculationQuery
            {
              HeartRate = 50,
              IntervalQT = 30
            };


            // act
            var handler = new CorrectedQTCalculationHandler();
            var result = handler.Handle(res).Result;

            // assert
            Assert.AreEqual(-0.79999999999999361, result.Framingham);
            Assert.AreEqual(27.386127875258307, result.Bazett);
            Assert.AreEqual(28.231080866430851, result.Fridericia);
            Assert.AreEqual(1.2, result.IntervalRR);
            Assert.AreEqual(12.5, result.Hodges);
        }

        [Test]
        public void CorrectedQTCalculationTest_LessError()
        {
            // arrange
            var modelLittle = new CorrectedQTCalculationQuery
            {
                HeartRate = 0,
                IntervalQT = 0
            };

            // act
            var handler = new CorrectedQTCalculationHandler();
            var errorModel = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel != null);
            Assert.IsTrue(errorModel.Errors.Count == 2);
            Assert.IsTrue(errorModel.Errors.Contains(CorrectedQTCalculationQueryValidator.HeartRateIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(CorrectedQTCalculationQueryValidator.IntervalQTIncorrectMessage));
        }

        [Test]
        public void CorrectedQTCalculationTest_MoreError()
        {
            // arrange
            var modelMore = new CorrectedQTCalculationQuery
            {

                HeartRate = 1000,
                IntervalQT = 1000
            };

            // act
            var handler = new CorrectedQTCalculationHandler();
            var errorModel = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel != null);
            Assert.IsTrue(errorModel.Errors.Count == 2);
            Assert.IsTrue(errorModel.Errors.Contains(CorrectedQTCalculationQueryValidator.HeartRateIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(CorrectedQTCalculationQueryValidator.IntervalQTIncorrectMessage));
        }
    }
}
