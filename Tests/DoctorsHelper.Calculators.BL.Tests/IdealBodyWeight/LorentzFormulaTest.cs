using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.LorentzFormula;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.IdealBodyWeight
{
    [TestFixture]
    public class LorentzFormulaTest
    {
        [Test]
        public void LorentzFormulaTest_NotError()
        {
            // arrange
            var model = new LorentzFormulaQuery
            {
                Height = 180,
                IsMen = true
            };

            // act
            var handler = new LorentzFormulaHandler();
            var result = handler.Handle(model).Result;


            // assert
            Assert.AreEqual(73, result.CalculationResult);
        }

        [Test]
        public void LorentzFormulaTest_HeightLittleOrMoreError()
        {
            // arrange
            var modelLittle = new LorentzFormulaQuery
            {
                Height = 139,
                IsMen = true
            };

            var modelMore = new LorentzFormulaQuery
            {
                Height = 230,
                IsMen = false
            };

            // act
            var handler = new LorentzFormulaHandler();
            var result1 = handler.Handle(modelLittle).Exception;
            var result2 = handler.Handle(modelMore).Exception;

            var errorModel1 = result1.GetErrorListResponseFromException();
            var errorModel2 = result2.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 1);
            Assert.IsTrue(errorModel1.Errors.Contains(LorentzFormulaQueryValidator.HeightIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 1);
            Assert.IsTrue(errorModel2.Errors.Contains(LorentzFormulaQueryValidator.HeightIncorrectMessage));
        }
    }
}