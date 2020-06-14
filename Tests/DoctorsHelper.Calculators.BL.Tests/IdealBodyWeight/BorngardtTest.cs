using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.Borngardt;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.IdealBodyWeight
{
    [TestFixture]
    public class BorngardtTest
    {
        [Test]
        public void BorngardtTest_NotError()
        {
            // arrange
            var model = new BorngardtQuery
            {
                Height = 180,
                ChestСircumference = 89
            };

            // act
            var handler = new BorngardtHandler();
            var result = handler.Handle(model).Result;
            

            // assert
            Assert.AreEqual(66,result.CalculationResult);
        }

        [Test]
        public void BorngardtTest_HeightError()
        {
            // arrange
            var model = new BorngardtQuery
            {
                Height = 450,
                ChestСircumference = 89
            };

            // act
            var handler = new BorngardtHandler();
            var e = handler.Handle(model).Exception;
            var errorModel = e.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel != null);
            Assert.IsTrue(errorModel.Errors.Count == 1);
            Assert.IsTrue(errorModel.Errors.Contains(BorngardtQueryValidator.HeightIncorrectMessage));
        }

        [Test]
        public void BorngardtTest_ChestСircumferenceError()
        {
            // arrange
            var model = new BorngardtQuery
            {
                Height = 186,
                ChestСircumference = 15
            };

            // act
            var handler = new BorngardtHandler();
            var e = handler.Handle(model).Exception;
            var errorModel = e.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel != null);
            Assert.IsTrue(errorModel.Errors.Count == 1);
            Assert.IsTrue(errorModel.Errors.Contains(BorngardtQueryValidator.ChestСircumferenceIncorrectMessage));
        }


        [Test]
        public void BorngardtTest_ChestСircumferenceAndHeightError()
        {
            // arrange
            var model = new BorngardtQuery
            {
                Height = 450,
                ChestСircumference = 15
            };

            // act
            var handler = new BorngardtHandler();
            var e = handler.Handle(model).Exception;
            var errorModel = e.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel != null);
            Assert.IsTrue(errorModel.Errors.Count == 2);
            Assert.IsTrue(errorModel.Errors.Contains(BorngardtQueryValidator.HeightIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(BorngardtQueryValidator.ChestСircumferenceIncorrectMessage));
        }
    }

}