using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.MonnerotFormula;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.IdealBodyWeight
{
    [TestFixture]
    public class MonnerotFormulaTest
    {
        [Test]
        public void MonnerotFormulaTest_NotError()
        {
            // arrange
            var model = new MonnerotFormulaQuery
            {
                WristLength = 17,
                Height = 180
            };

          // act
            var handler = new MonnerotFormulaHandler();
            var result = handler.Handle(model).Result;

            // assert
            Assert.AreEqual( 74, result.CalculationResult);
        }


        [Test]
        public void MonnerotFormulaTest_LessOrMoreWristLengthError()
        {
            // arrange
            var modelLess = new MonnerotFormulaQuery
            {
                WristLength = 2,
                Height = 180
            };

            var modelMore = new MonnerotFormulaQuery
            {
                WristLength = 51,
                Height = 180
            };

            // act
            var handler = new MonnerotFormulaHandler();
            var resultLessException = handler.Handle(modelLess).Exception;
            var errorModel1 = resultLessException.GetErrorListResponseFromException();

            var resultMoreException = handler.Handle(modelMore).Exception;
            var errorModel2 = resultMoreException.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 1);
            Assert.IsTrue(errorModel1.Errors.Contains(MonnerotFormulaQueryValidator.WristLengthIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 1);
            Assert.IsTrue(errorModel2.Errors.Contains(MonnerotFormulaQueryValidator.WristLengthIncorrectMessage));
        }

        [Test]
        public void MonnerotFormulaTest_LessOrMoreHeightError()
        {
            // arrange
            var modelLess = new MonnerotFormulaQuery
            {
                WristLength = 10,
                Height = 139
            };

            var modelMore = new MonnerotFormulaQuery
            {
                WristLength = 10,
                Height = 351
            };

            // act
            var handler = new MonnerotFormulaHandler();
            var resultLessException = handler.Handle(modelLess).Exception;
            var errorModel1 = resultLessException.GetErrorListResponseFromException();

            var resultMoreException = handler.Handle(modelMore).Exception;
            var errorModel2 = resultMoreException.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 1);
            Assert.IsTrue(errorModel1.Errors.Contains(MonnerotFormulaQueryValidator.HeightIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 1);
            Assert.IsTrue(errorModel2.Errors.Contains(MonnerotFormulaQueryValidator.HeightIncorrectMessage));
        }

        [Test]
        public void MonnerotFormulaTest_LessOrMoreHeightAndWristLengthError()
        {
            // arrange
            var modelLess = new MonnerotFormulaQuery
            {
                WristLength = 2,
                Height = 139
            };

            var modelMore = new MonnerotFormulaQuery
            {
                WristLength = 51,
                Height = 351
            };

            // act
            var handler = new MonnerotFormulaHandler();
            var resultLessException = handler.Handle(modelLess).Exception;
            var errorModel1 = resultLessException.GetErrorListResponseFromException();

            var resultMoreException = handler.Handle(modelMore).Exception;
            var errorModel2 = resultMoreException.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 2);
            Assert.IsTrue(errorModel1.Errors.Contains(MonnerotFormulaQueryValidator.HeightIncorrectMessage));
            Assert.IsTrue(errorModel1.Errors.Contains(MonnerotFormulaQueryValidator.WristLengthIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 2);
            Assert.IsTrue(errorModel2.Errors.Contains(MonnerotFormulaQueryValidator.HeightIncorrectMessage));
            Assert.IsTrue(errorModel2.Errors.Contains(MonnerotFormulaQueryValidator.WristLengthIncorrectMessage));
        }
    }
}
