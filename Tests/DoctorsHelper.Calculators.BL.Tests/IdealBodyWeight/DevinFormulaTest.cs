using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.DevinFormula;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.IdealBodyWeight
{
    [TestFixture]
    public class DevinFormulaTest
    {
        [Test]
        public void DevinFormulaTest_NotError()
        {
            // arrange
            var model = new DevinFormulaQuery
            {
                Height = 180,
                IsMen = true
            };

            // act
            var handler = new DevinFormulaHandler();
            var result = handler.Handle(model).Result;

            // assert
            Assert.AreEqual(74.99, result.CalculationResult);
        }

        [Test]
        public void DevinFormulaTest_HeightLittleOrMoreError()
        {
            // arrange
            var modelLittle = new DevinFormulaQuery
            {
                Height = 139,
                IsMen = true
            };

            var modelMore = new DevinFormulaQuery
            {
                Height = 351,
                IsMen = false
            };

            // act
            var handler = new DevinFormulaHandler();
            var errorModel1 = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();
            var errorModel2 = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 1);
            Assert.IsTrue(errorModel1.Errors.Contains(DevinFormulaQueryValidator.HeightIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 1);
            Assert.IsTrue(errorModel2.Errors.Contains(DevinFormulaQueryValidator.HeightIncorrectMessage));
        }
    }
}
