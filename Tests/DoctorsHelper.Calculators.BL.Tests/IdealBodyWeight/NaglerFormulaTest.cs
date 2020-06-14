using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.NaglerFormula;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.IdealBodyWeight
{
    [TestFixture]
    public class NaglerFormulaTest
    {
        [Test]
        public void NaglerFormulaTest_NotError()
        {
            // arrange
            var man = new NaglerFormulaQuery
            {
                Height = 180,
                IsMen = true
            };

            var woman = new NaglerFormulaQuery
            {
                Height = 180,
                IsMen = false
            };

            // act
            var handler = new NaglerFormulaHandler();
            var resultMan = handler.Handle(man).Result;
            var resultWoman = handler.Handle(woman).Result;

            // assert
            Assert.AreEqual(77.34, resultMan.CalculationResult);
            Assert.AreEqual(69.97, resultWoman.CalculationResult);
        }

        [Test]
        public void NaglerFormulaTest_HeightLittleOrMoreError()
        {
            // arrange
            var modelLittle = new NaglerFormulaQuery
            {
                Height = 139,
                IsMen = true
            };

            var modelMore = new NaglerFormulaQuery
            {
                Height = 351,
                IsMen = false
            };

            // act
            var handler = new NaglerFormulaHandler();
            var errorModel1 = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();
            var errorModel2 = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 1);
            Assert.IsTrue(errorModel1.Errors.Contains(NaglerFormulaQueryValidator.HeightIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 1);
            Assert.IsTrue(errorModel2.Errors.Contains(NaglerFormulaQueryValidator.HeightIncorrectMessage));
        }
    }
}
