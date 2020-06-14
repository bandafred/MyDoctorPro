using System;
using System.Collections.Generic;
using System.Text;
using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.EgorovaTable;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.IdealBodyWeight
{
    [TestFixture]
    public class EgorovaTableTest
    {
        [Test]
        public void EgorovaTableTest_NotError()
        {
            // arrange
            var man = new EgorovaTableQuery
            {
                Height = 180,
                IsMen = true,
                Age = 25
            };

            var woman = new EgorovaTableQuery
            {
                Height = 180,
                IsMen = false,
                Age = 25
            };

            // act
            var handler = new EgorovaTableHandler();
            var resultMan = handler.Handle(man).Result;
            var resultWoman = handler.Handle(woman).Result;

            // assert
            Assert.AreEqual(85.1, resultMan.CalculationResult);
            Assert.AreEqual(80.9, resultWoman.CalculationResult);
        }

        [Test]
        public void EgorovaTableTest_HeightLittleOrMoreError()
        {
            // arrange
            var modelLittle = new EgorovaTableQuery
            {
                Height = 139,
                IsMen = true,
                Age = 25
            };

            var modelMore = new EgorovaTableQuery
            {
                Height = 351,
                IsMen = false,
                Age = 25
            };

            // act
            var handler = new EgorovaTableHandler();
            var errorModel1 = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();
            var errorModel2 = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 1);
            Assert.IsTrue(errorModel1.Errors.Contains(EgorovaTableQueryValidator.HeightIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 1);
            Assert.IsTrue(errorModel2.Errors.Contains(EgorovaTableQueryValidator.HeightIncorrectMessage));
        }

        [Test]
        public void EgorovaTableTest_AgeLittleOrMoreError()
        {
            // arrange
            var modelLittle = new EgorovaTableQuery
            {
                Height = 180,
                IsMen = true,
                Age = 19
            };

            var modelMore = new EgorovaTableQuery
            {
                Height = 180,
                IsMen = false,
                Age = 70
            };

            // act
            var handler = new EgorovaTableHandler();
            var errorModel1 = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();
            var errorModel2 = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 1);
            Assert.IsTrue(errorModel1.Errors.Contains(EgorovaTableQueryValidator.AgeIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 1);
            Assert.IsTrue(errorModel2.Errors.Contains(EgorovaTableQueryValidator.AgeIncorrectMessage));
        }
    }
}
