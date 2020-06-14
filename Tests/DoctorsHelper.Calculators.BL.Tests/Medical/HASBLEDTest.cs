using DoctorsHelper.Calculators.BL.Medical.HASBLED;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.Medical
{
    [TestFixture]
    public class HASBLEDTest
    {
        [Test]
        public void HASBLEDTest_NotError()
        {
            // arrange
            var model1 = new HASBLEDQuery
            {
                OldAge = true,
                AntiplateletAgents = true,
                Alcohol = true,
                Bleeding = true,
                CreatinineIncreased = true,
                Transaminase = true,
                Hypertension = true,
                Insult = true,
                Mno = true
            };
            var model2 = new HASBLEDQuery
            {
                OldAge = false,
                AntiplateletAgents = false,
                Alcohol = false,
                Bleeding = false,
                CreatinineIncreased = false,
                Transaminase = false,
                Hypertension = false,
                Insult = false,
                Mno = false
            };
            var model3 = new HASBLEDQuery
            {
                OldAge = true,
                AntiplateletAgents = false,
                Alcohol = true,
                Bleeding = false,
                CreatinineIncreased = true,
                Transaminase = true,
                Hypertension = false,
                Insult = false,
                Mno = true
            };

            // act
            var handler = new HASBLEDHandler();
            var result = handler.Handle(model1).Result;
            var result2 = handler.Handle(model2).Result;
            var result3 = handler.Handle(model3).Result;

            // assert
            Assert.AreEqual(9, result.Index);
            Assert.AreEqual(0, result2.Index);
            Assert.AreEqual(5, result3.Index);
        }
    }
}
