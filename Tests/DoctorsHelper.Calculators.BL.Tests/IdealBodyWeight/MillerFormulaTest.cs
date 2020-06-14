using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.MillerFormula;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.IdealBodyWeight
{
    [TestFixture]
    public class MillerFormulaTest
    {
        [Test]
        public void MillerFormulaTest_NotError()
        {
            // arrange
            var man = new MillerFormulaQuery
            {
                Height = 180,
                IsMen = true
            };

            var woman = new MillerFormulaQuery
            {
                Height = 180,
                IsMen = false
            };

            // act
            var handler = new MillerFormulaHandler();
            var resultMan = handler.Handle(man).Result;
            var resultWoman = handler.Handle(woman).Result;

            // assert
            Assert.AreEqual(71.52, resultMan.CalculationResult);
            Assert.AreEqual(67.88, resultWoman.CalculationResult);
        }

        [Test]
        public void MillerFormulaTest_HeightLittleOrMoreError()
        {
            // arrange
            var modelLittle = new MillerFormulaQuery
            {
                Height = 99,
                IsMen = true
            };

            var modelMore = new MillerFormulaQuery
            {
                Height = 351,
                IsMen = false
            };

            // act
            var handler = new MillerFormulaHandler();
            var errorModel1 = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();
            var errorModel2 = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 1);
            Assert.IsTrue(errorModel1.Errors.Contains(MillerFormulaQueryValidator.HeightIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 1);
            Assert.IsTrue(errorModel2.Errors.Contains(MillerFormulaQueryValidator.HeightIncorrectMessage));
        }
    }
}
