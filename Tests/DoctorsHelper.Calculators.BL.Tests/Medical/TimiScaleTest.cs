using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.Medical.TimiScale;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.Medical
{
    [TestFixture]
    public class TimiScaleTest
    {
        [Test]
        public void TimiScaleTest_NotError()
        {
            // arrange
            var trueModel = new TimiScaleQuery
            {
                OldAge = true,
                ThreeRisk = true,
                Stenos = true,
                LiftSt = true,
                Stenocardia = true,
                Aspirin = true,
                Necroze = true,
            };
            var falseModel = new TimiScaleQuery
            {
                OldAge = false,
                ThreeRisk = false,
                Stenos = false,
                LiftSt = false,
                Stenocardia = false,
                Aspirin = false,
                Necroze = false,
            };
            var model = new TimiScaleQuery
            {
                OldAge = false,
                ThreeRisk = true,
                Stenos = true,
                LiftSt = false,
                Stenocardia = false,
                Aspirin = true,
                Necroze = false,
            };

            // act
            var handler = new TimiScaleHandler();
            var result = handler.Handle(model).Result;
            var result2 = handler.Handle(trueModel).Result;
            var result3 = handler.Handle(falseModel).Result;

            // assert
            Assert.AreEqual(13.2, result.Index);
            Assert.AreEqual(40.9, result2.Index);
            Assert.AreEqual(4.7, result3.Index);
        }
    }
}
