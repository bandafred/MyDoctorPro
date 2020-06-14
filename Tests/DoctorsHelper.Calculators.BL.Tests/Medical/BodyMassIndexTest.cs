using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.Medical.BodyMassIndex;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.Medical
{
    [TestFixture]
    public class BodyMassIndexTest
    {
        [Test]
        public void BodyMassIndexTest_NotError()
        {
            // arrange
            var model = new BodyMassIndexQuery
            {
                Height = 180,
                Weight = 100
            };

            // act
            var handler = new BodyMassIndexHandler();
            var result = handler.Handle(model).Result;

            // assert
            Assert.AreEqual(30.9, result.Index);
        }

        [Test]
        public void BodyMassIndexTest_HeightLittleOrMoreError()
        {
            // arrange
            var modelLittle = new BodyMassIndexQuery
            {
                Height = 139,
                Weight = 100
            };

            var modelMore = new BodyMassIndexQuery
            {
                Height = 351,
                Weight = 100
            };

            // act
            var handler = new BodyMassIndexHandler();
            var errorModel1 = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();
            var errorModel2 = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 1);
            Assert.IsTrue(errorModel1.Errors.Contains(BodyMassIndexQueryValidator.HeightIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 1);
            Assert.IsTrue(errorModel2.Errors.Contains(BodyMassIndexQueryValidator.HeightIncorrectMessage));
        }

        [Test]
        public void BodyMassIndexTest_WeightLittleOrMoreError()
        {
            // arrange
            var modelLittle = new BodyMassIndexQuery
            {
                Height = 180,
                Weight = 29
            };

            var modelMore = new BodyMassIndexQuery
            {
                Height = 180,
                Weight = 501
            };

            // act
            var handler = new BodyMassIndexHandler();
            var errorModel1 = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();
            var errorModel2 = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 1);
            Assert.IsTrue(errorModel1.Errors.Contains(BodyMassIndexQueryValidator.WeightIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 1);
            Assert.IsTrue(errorModel2.Errors.Contains(BodyMassIndexQueryValidator.WeightIncorrectMessage));
        }

        [Test]
        public void BodyMassIndexTest_HeightAndWeightLittleOrMoreError()
        {
            // arrange
            var modelLittle = new BodyMassIndexQuery
            {
                Height = 139,
                Weight = 29
            };

            var modelMore = new BodyMassIndexQuery
            {
                Height = 351,
                Weight = 501
            };

            // act
            var handler = new BodyMassIndexHandler();
            var errorModel1 = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();
            var errorModel2 = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 2);
            Assert.IsTrue(errorModel1.Errors.Contains(BodyMassIndexQueryValidator.HeightIncorrectMessage));
            Assert.IsTrue(errorModel1.Errors.Contains(BodyMassIndexQueryValidator.WeightIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 2);
            Assert.IsTrue(errorModel2.Errors.Contains(BodyMassIndexQueryValidator.HeightIncorrectMessage));
            Assert.IsTrue(errorModel2.Errors.Contains(BodyMassIndexQueryValidator.WeightIncorrectMessage));
        }
    }
}
