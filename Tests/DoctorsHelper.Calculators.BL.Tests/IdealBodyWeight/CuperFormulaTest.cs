using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.CuperFormula;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.IdealBodyWeight
{
    [TestFixture]
    public class CuperFormulaTest
    {
        [Test]
        public void CuperFormulaTest_NotError()
        {
            // arrange
            var model = new CuperFormulaQuery
            {
                Height = 180,
                IsMen = true
            };

            // act
            var handler = new CuperFormulaHandler();
            var result = handler.Handle(model).Result;


            // assert
            Assert.AreEqual(70.34, result.CalculationResult);
        }

        [Test]
        public void CuperFormulaTest_HeightLittleOrMoreError()
        {
            // arrange
            var modelLittle = new CuperFormulaQuery
            {
                Height = 119,
                IsMen = true
            };

            var modelMore = new CuperFormulaQuery
            {
                Height = 301,
                IsMen = false
            };

            // act
            var handler = new CuperFormulaHandler();
            var result1 = handler.Handle(modelLittle).Exception;
            var result2 = handler.Handle(modelMore).Exception;

            var errorModel1 = result1.GetErrorListResponseFromException();
            var errorModel2 = result2.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 1);
            Assert.IsTrue(errorModel1.Errors.Contains(CuperFormulaQueryValidator.HeightIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 1);
            Assert.IsTrue(errorModel2.Errors.Contains(CuperFormulaQueryValidator.HeightIncorrectMessage));
        }
    }
}
