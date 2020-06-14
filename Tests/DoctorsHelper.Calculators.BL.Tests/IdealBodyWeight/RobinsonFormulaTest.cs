using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.RobinsonFormula;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.IdealBodyWeight
{
    [TestFixture]
    public class RobinsonFormulaTest
    {
        [Test]
        public void RobinsonFormulaTest_NotError()
        {
            // arrange
            var man = new RobinsonFormulaQuery
            {
                Height = 180,
                IsMen = true
            };

            var woman = new RobinsonFormulaQuery
            {
                Height = 180,
                IsMen = false
            };

            // act
            var handler = new RobinsonFormulaHandler();
            var resultMan = handler.Handle(man).Result;
            var resultWoman = handler.Handle(woman).Result;

            // assert
            Assert.AreEqual(72.65, resultMan.CalculationResult);
            Assert.AreEqual(67.47, resultWoman.CalculationResult);
        }

        [Test]
        public void RobinsonFormulaTest_HeightLittleOrMoreError()
        {
            // arrange
            var modelLittle = new RobinsonFormulaQuery
            {
                Height = 139,
                IsMen = true
            };

            var modelMore = new RobinsonFormulaQuery
            {
                Height = 221,
                IsMen = false
            };

            // act
            var handler = new RobinsonFormulaHandler();
            var errorModel1 = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();
            var errorModel2 = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 1);
            Assert.IsTrue(errorModel1.Errors.Contains(RobinsonFormulaQueryValidator.HeightIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 1);
            Assert.IsTrue(errorModel2.Errors.Contains(RobinsonFormulaQueryValidator.HeightIncorrectMessage));
        }
    }
}
