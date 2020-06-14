using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.IndexBrokaBruksha;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.IdealBodyWeight
{
    [TestFixture]
    public class IndexBrokaBrukshaTest
    {
        [Test]
        public void IndexBrokaBrukshaTest_NotError()
        {
            // arrange
            var model = new IndexBrokaBrukshaQuery
            {
                Height = 180
            };

            // act
            var handler = new IndexBrokaBrukshaHandler();
            var result = handler.Handle(model).Result;

            // assert
            Assert.AreEqual(70, result.CalculationResult);
        }

        [Test]
        public void IndexBrokaBrukshaTest_HeightLittleOrMoreError()
        {
            // arrange
            var modelLittle = new IndexBrokaBrukshaQuery
            {
                Height = 119
            };

            var modelMore = new IndexBrokaBrukshaQuery
            {
                Height = 351,
            };

            // act
            var handler = new IndexBrokaBrukshaHandler();
            var result1 = handler.Handle(modelLittle).Exception;
            var result2 = handler.Handle(modelMore).Exception;

            var errorModel1 = result1.GetErrorListResponseFromException();
            var errorModel2 = result2.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 1);
            Assert.IsTrue(errorModel1.Errors.Contains(IndexBrokaBrukshaQueryValidator.HeightIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 1);
            Assert.IsTrue(errorModel2.Errors.Contains(IndexBrokaBrukshaQueryValidator.HeightIncorrectMessage));
        }
    }
}
