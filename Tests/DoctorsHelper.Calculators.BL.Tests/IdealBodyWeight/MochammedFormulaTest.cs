using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.MochammedFormula;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.IdealBodyWeight
{
    [TestFixture]
    public class MochammedFormulaTest
    {
        [Test]
        public void MochammedFormulaTest_NotError()
        {
            // arrange
            var model = new MochammedFormulaQuery
            {
                Height = 180,
            };

            // act
            var handler = new MochammedFormulaHandler();
            var result = handler.Handle(model).Result;

            // assert
            Assert.AreEqual(72.9, result.CalculationResult);
        }

        [Test]
        public void MochammedFormulaTest_HeightLittleOrMoreError()
        {
            // arrange
            var modelLittle = new MochammedFormulaQuery
            {
                Height = 99,
            };

            var modelMore = new MochammedFormulaQuery
            {
                Height = 351,
            };

            // act
            var handler = new MochammedFormulaHandler();
            var errorModel1 = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();
            var errorModel2 = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 1);
            Assert.IsTrue(errorModel1.Errors.Contains(MochammedFormulaQueryValidator.HeightIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 1);
            Assert.IsTrue(errorModel2.Errors.Contains(MochammedFormulaQueryValidator.HeightIncorrectMessage));
        }
    }
}
