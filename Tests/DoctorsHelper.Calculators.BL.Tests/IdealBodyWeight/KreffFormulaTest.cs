using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.KreffFormula;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.IdealBodyWeight
{
    [TestFixture]
    public class KreffFormulaTest
    {
        [Test]
        public void KreffFormulaTest_NotError()
        {
            // arrange
            var res = new KreffFormulaQuery
            {
                Height = 180,
                LenСarpus = 5,
                Age = 25
            };


            // act
            var handler = new KreffFormulaHandler();
            var result = handler.Handle(res).Result;

            // assert
            Assert.AreEqual(66.42, result.CalculationResult);
        }

        [Test]
        public void KreffFormulaTest_LessError()
        {
            // arrange
            var modelLittle = new KreffFormulaQuery
            {
                Height = 99,
                LenСarpus = 1,
                Age = 3
            };

            // act
            var handler = new KreffFormulaHandler();
            var errorModel = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel != null);
            Assert.IsTrue(errorModel.Errors.Count == 3);
            Assert.IsTrue(errorModel.Errors.Contains(KreffFormulaQueryValidator.HeightIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(KreffFormulaQueryValidator.AgeIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(KreffFormulaQueryValidator.LenСarpusIncorrectMessage));
        }

        [Test]
        public void KreffFormulaTest_MoreError()
        {
            // arrange
            var modelMore = new KreffFormulaQuery
            {
                Height = 351,
                LenСarpus = 55,
                Age = 301
            };

            // act
            var handler = new KreffFormulaHandler();
            var errorModel = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel != null);
            Assert.IsTrue(errorModel.Errors.Count == 3);
            Assert.IsTrue(errorModel.Errors.Contains(KreffFormulaQueryValidator.HeightIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(KreffFormulaQueryValidator.AgeIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(KreffFormulaQueryValidator.LenСarpusIncorrectMessage));
        }
    }
}