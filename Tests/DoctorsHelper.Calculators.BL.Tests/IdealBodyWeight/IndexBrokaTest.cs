using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.IndexBroka;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.IdealBodyWeight
{
    [TestFixture]
    public class IndexBrokaTest
    {
        [Test]
        public void IndexBrokaTest_NotError()
        {
            // arrange
            var model = new IndexBrokaQuery
            {
                Height = 180,
                IsMen = true
            };

            // act
            var handler = new IndexBrokaHandler();
            var result = handler.Handle(model).Result;


            // assert
            Assert.AreEqual(90, result.CalculationResult);
        }

        [Test]
        public void IndexBrokaTest_HeightLittleOrMoreError()
        {
            // arrange
            var modelLittle = new IndexBrokaQuery
            {
                Height = 150,
                IsMen = true
            };

            var modelMore = new IndexBrokaQuery
            {
                Height = 190,
                IsMen = false
            };

            // act
            var handler = new IndexBrokaHandler();
            var result1 = handler.Handle(modelLittle).Exception;
            var result2 = handler.Handle(modelMore).Exception;

            var errorModel1 = result1.GetErrorListResponseFromException();
            var errorModel2 = result2.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 1);
            Assert.IsTrue(errorModel1.Errors.Contains(IndexBrokaQueryValidator.HeightIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 1);
            Assert.IsTrue(errorModel2.Errors.Contains(IndexBrokaQueryValidator.HeightIncorrectMessage));
        }
    }
}
