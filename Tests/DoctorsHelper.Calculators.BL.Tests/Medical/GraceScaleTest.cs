using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.Medical.GraceScale;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.Medical
{
    [TestFixture]
    public class GraceScaleTest
    {
        [Test]
        public void GraceScaleTest_NotError()
        {
            // arrange
            var model1 = new GraceScaleQuery
            {
                Age = 40,
                SystolicBloodPressure = 120,
                Creatinin = 40,
                HeartRate = 90,
                Kilip = 20,
                HeartFailure = true,
                HighLevelOfCardiacEnzymes = true,
                StSegmentDeviation = true,
            };
            var model2 = new GraceScaleQuery
            {
                Age = 20,
                SystolicBloodPressure = 90,
                Creatinin = 20,
                HeartRate = 90,
                Kilip = 0,
                HeartFailure = false,
                HighLevelOfCardiacEnzymes = false,
                StSegmentDeviation = false,
            };

            // act
            var handler = new GraceScaleHandler();
            var result1 = handler.Handle(model1).Result;
            var result2 = handler.Handle(model2).Result;

            // assert
            Assert.AreEqual(179, result1.Index);
            Assert.AreEqual(69, result2.Index);
        }

        [Test]
        public void GraceScaleTest_MoreError()
        {
            // arrange
            var modelMore = new GraceScaleQuery
            {
                Age = 151,
                SystolicBloodPressure = 301,
                Creatinin = 151,
                HeartRate = 151,
                Kilip = 20,
                HeartFailure = true,
                HighLevelOfCardiacEnzymes = true,
                StSegmentDeviation = true,
            };

            // act
            var handler = new GraceScaleHandler();
            var errorModel = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel != null);
            Assert.IsTrue(errorModel.Errors.Count == 4);
            Assert.IsTrue(errorModel.Errors.Contains(GraceScaleQueryValidator.AgeIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(GraceScaleQueryValidator.CreatininIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(GraceScaleQueryValidator.HeartRateIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(GraceScaleQueryValidator.SystolicBloodPressureIncorrectMessage));
        }

        [Test]
        public void GraceScaleTest_LittleError()
        {
            // arrange
            var modelLittle = new GraceScaleQuery
            {
                Age = 151,
                SystolicBloodPressure = 301,
                Creatinin = 151,
                HeartRate = 151,
                Kilip = 20,
                HeartFailure = true,
                HighLevelOfCardiacEnzymes = true,
                StSegmentDeviation = true,
            };

            // act
            var handler = new GraceScaleHandler();
            var errorModel = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel != null);
            Assert.IsTrue(errorModel.Errors.Count == 4);
            Assert.IsTrue(errorModel.Errors.Contains(GraceScaleQueryValidator.AgeIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(GraceScaleQueryValidator.CreatininIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(GraceScaleQueryValidator.HeartRateIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(GraceScaleQueryValidator.SystolicBloodPressureIncorrectMessage));
        }
    }
}
