using DoctorsHelper.Calculators.BL.Medical.CHA2DS2VASc;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.Medical
{
    [TestFixture]
    public class CHA2DS2VAScTest
    {
        [Test]
        public void CHA2DS2VAScTest_NotError()
        {
            // arrange
            var trueModel = new CHA2DS2VAScQuery
            {
                IsHeartFailure = true,
                IsArterialHypertension = true,
                IsMyocardialInfarction = true,
                IsDiabetes = true,
                IsInsult = true,
                IsOld65 = true,
                IsOld75 = true,
                IsWomen = true
            };
            var falseModel = new CHA2DS2VAScQuery
            {
                IsHeartFailure = false,
                IsArterialHypertension = false,
                IsMyocardialInfarction = false,
                IsDiabetes = false,
                IsInsult = false,
                IsOld65 = false,
                IsOld75 = false,
                IsWomen = false
            };
            var model = new CHA2DS2VAScQuery
            {
                IsHeartFailure = true,
                IsArterialHypertension = true,
                IsMyocardialInfarction = false,
                IsDiabetes = true,
                IsInsult = true,
                IsOld65 = false,
                IsOld75 = true,
                IsWomen = false
            };

            // act
            var handler = new CHA2DS2VAScHandler();
            var result = handler.Handle(model).Result;
            var result2 = handler.Handle(trueModel).Result;
            var result3 = handler.Handle(falseModel).Result;

            // assert
            Assert.AreEqual(7, result.Index);
            Assert.AreEqual(8, result2.Index);
            Assert.AreEqual(0, result3.Index);            
            Assert.AreEqual(9.6, result.Resultate);
            Assert.AreEqual(6.7, result2.Resultate);
            Assert.AreEqual(0, result3.Resultate);
        }
    }
}
