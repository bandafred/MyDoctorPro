using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.HamviFormula;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.IdealBodyWeight
{
    [TestFixture()]
    public class HamviFormulaTest
    {
        [Test]
        public void HamviFormulaTest_NotError()
        {
            // arrange
            var man = new HamviFormulaQuery
            {
                Height = 180,
                IsMen = true
            };

            var woman = new HamviFormulaQuery
            {
                Height = 180,
                IsMen = false
            };

            // act
            var handler = new HamviFormulaHandler();
            var resultMan = handler.Handle(man).Result;
            var resultWoman = handler.Handle(woman).Result;


            // assert
            Assert.AreEqual(77.34, resultMan.CalculationResult);
            Assert.AreEqual(69.41, resultWoman.CalculationResult);
        }

        [Test]
        public void HamviFormulaTest_HeightLittleOrMoreError()
        {
            // arrange
            var modelLittle = new HamviFormulaQuery
            {
                Height = 139,
                IsMen = true
            };

            var modelMore = new HamviFormulaQuery
            {
                Height = 351,
                IsMen = false
            };

            // act
            var handler = new HamviFormulaHandler();
            var errorModel1 = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();
            var errorModel2 = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 1);
            Assert.IsTrue(errorModel1.Errors.Contains(HamviFormulaQueryValidator.HeightIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 1);
            Assert.IsTrue(errorModel2.Errors.Contains(HamviFormulaQueryValidator.HeightIncorrectMessage));
        }
    }
}
