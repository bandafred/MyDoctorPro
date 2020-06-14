using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.Medical.IndexSmoke;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.Medical
{
    [TestFixture]
    public class IndexSmokeTest
    {
        [Test]
        public void IndexSmokeTest_NotError()
        {
            // arrange
            var res = new IndexSmokeQuery
            {
               CountSigar = 10,
               AgeSmoke = 10
            };


            // act
            var handler = new IndexSmokeHandler();
            var result = handler.Handle(res).Result;

            // assert
            Assert.AreEqual(5, result.Index);
        }

        [Test]
        public void IndexSmokeTest_LessError()
        {
            // arrange
            var modelLittle = new IndexSmokeQuery
            {
                CountSigar = 0,
                AgeSmoke = 0
            };

            // act
            var handler = new IndexSmokeHandler();
            var errorModel = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel != null);
            Assert.IsTrue(errorModel.Errors.Count == 2);
            Assert.IsTrue(errorModel.Errors.Contains(IndexSmokeQueryValidator.AgeSmokeIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(IndexSmokeQueryValidator.CountSigarIncorrectMessage));
        }

        [Test]
        public void IndexSmokeTest_MoreError()
        {
            // arrange
            var modelMore = new IndexSmokeQuery
            {
                CountSigar = 1000,
                AgeSmoke = 151
            };

            // act
            var handler = new IndexSmokeHandler();
            var errorModel = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel != null);
            Assert.IsTrue(errorModel.Errors.Count == 2);
            Assert.IsTrue(errorModel.Errors.Contains(IndexSmokeQueryValidator.AgeSmokeIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(IndexSmokeQueryValidator.CountSigarIncorrectMessage));
        }
    }
}
