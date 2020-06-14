using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.Medical.ScoreScale;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.Medical
{
    [TestFixture]
    public class ScoreScaleTest
    {
        [Test]
        public void ScoreScaleTest_NotError()
        {
            // arrange
            var model = new ScoreScaleQuery
            {
                IsMen = true,
                IsSmoke = true,
                Age = 46,
                UpperBloodPressure = 180,
                PlasmaCholesterol = 15,
            };
            var model2 = new ScoreScaleQuery
            {
                IsMen = false,
                IsSmoke = false,
                Age = 70,
                UpperBloodPressure = 240,
                PlasmaCholesterol = 7,
            };

            // act
            var handler = new ScoreScaleHandler();
            var result = handler.Handle(model).Result;
            var result2 = handler.Handle(model2).Result;

            // assert
            Assert.AreEqual(4, result.Index);
            Assert.AreEqual(10, result2.Index);
        }

        [Test]
        public void ScoreScaleTest_AgeLittleOrMoreError()
        {
            // arrange
            var modelLittle = new ScoreScaleQuery
            {
                IsMen = true,
                IsSmoke = true,
                Age = 0,
                UpperBloodPressure = 180,
                PlasmaCholesterol = 15,
            };

            var modelMore = new ScoreScaleQuery
            {
                IsMen = true,
                IsSmoke = true,
                Age = 151,
                UpperBloodPressure = 180,
                PlasmaCholesterol = 15,
            };

            // act
            var handler = new ScoreScaleHandler();
            var errorModel1 = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();
            var errorModel2 = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 1);
            Assert.IsTrue(errorModel1.Errors.Contains(ScoreScaleQueryValidator.AgeIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 1);
            Assert.IsTrue(errorModel2.Errors.Contains(ScoreScaleQueryValidator.AgeIncorrectMessage));
        }

        [Test]
        public void ScoreScaleTest_UpperBloodPressureLittleOrMoreError()
        {
            // arrange
            var modelLittle = new ScoreScaleQuery
            {
                IsMen = true,
                IsSmoke = true,
                Age = 46,
                UpperBloodPressure = 59,
                PlasmaCholesterol = 15,
            };

            var modelMore = new ScoreScaleQuery
            {
                IsMen = true,
                IsSmoke = true,
                Age = 46,
                UpperBloodPressure = 301,
                PlasmaCholesterol = 15,
            };

            // act
            var handler = new ScoreScaleHandler();
            var errorModel1 = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();
            var errorModel2 = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 1);
            Assert.IsTrue(errorModel1.Errors.Contains(ScoreScaleQueryValidator.UpperBloodPressureIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 1);
            Assert.IsTrue(errorModel2.Errors.Contains(ScoreScaleQueryValidator.UpperBloodPressureIncorrectMessage));
        }
        [Test]
        public void ScoreScaleTest_PlasmaCholesterolLittleOrMoreError()
        {
            // arrange
            var modelLittle = new ScoreScaleQuery
            {
                IsMen = true,
                IsSmoke = true,
                Age = 46,
                UpperBloodPressure = 180,
                PlasmaCholesterol = 0,
            };

            var modelMore = new ScoreScaleQuery
            {
                IsMen = true,
                IsSmoke = true,
                Age = 46,
                UpperBloodPressure = 180,
                PlasmaCholesterol = 31,
            };

            // act
            var handler = new ScoreScaleHandler();
            var errorModel1 = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();
            var errorModel2 = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 1);
            Assert.IsTrue(errorModel1.Errors.Contains(ScoreScaleQueryValidator.PlasmaCholesterolIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 1);
            Assert.IsTrue(errorModel2.Errors.Contains(ScoreScaleQueryValidator.PlasmaCholesterolIncorrectMessage));
        }

        [Test]
        public void ScoreScaleTest_AllLittleOrMoreError()
        {
            // arrange
            var modelLittle = new ScoreScaleQuery
            {
                IsMen = true,
                IsSmoke = true,
                Age = 0,
                UpperBloodPressure = 58,
                PlasmaCholesterol = 0,
            };

            var modelMore = new ScoreScaleQuery
            {
                IsMen = true,
                IsSmoke = true,
                Age = 151,
                UpperBloodPressure = 301,
                PlasmaCholesterol = 31,
            };

            // act
            var handler = new ScoreScaleHandler();
            var errorModel1 = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();
            var errorModel2 = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 3);
            Assert.IsTrue(errorModel1.Errors.Contains(ScoreScaleQueryValidator.AgeIncorrectMessage));
            Assert.IsTrue(errorModel1.Errors.Contains(ScoreScaleQueryValidator.UpperBloodPressureIncorrectMessage));
            Assert.IsTrue(errorModel1.Errors.Contains(ScoreScaleQueryValidator.PlasmaCholesterolIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 3);
            Assert.IsTrue(errorModel1.Errors.Contains(ScoreScaleQueryValidator.AgeIncorrectMessage));
            Assert.IsTrue(errorModel1.Errors.Contains(ScoreScaleQueryValidator.UpperBloodPressureIncorrectMessage));
            Assert.IsTrue(errorModel1.Errors.Contains(ScoreScaleQueryValidator.PlasmaCholesterolIncorrectMessage));
        }
    }
}
