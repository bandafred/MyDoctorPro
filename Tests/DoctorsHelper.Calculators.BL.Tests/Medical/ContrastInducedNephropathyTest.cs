using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.Medical.ContrastInducedNephropathy;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.Medical
{
    [TestFixture]
    public class ContrastInducedNephropathyTest
    {
        [Test]
        public void ContrastInducedNephropathyTest_TrueNotError()
        {
            // arrange
            var trueModel = new ContrastInducedNephropathyQuery
            {
                IsNYHA = true,
                VolumeContrast = 4,
                IsDiabetes = true,
                IsAnemya = true,
                IsBigCreatinin = true,
                IsHypotonia = true,
                IsOldAge = true,
                IsVABK = true,
                SpeedKF = 4
            };

            // act
            var handler = new ContrastInducedNephropathyHandler();
            var result = handler.Handle(trueModel).Result;

            // assert
            Assert.AreEqual(37, result.Index);
            Assert.AreEqual(12.6, result.DialysisChanceProcent);
            Assert.AreEqual(57.3, result.Risk);
            Assert.AreEqual(ContrastInducedNephropathyResponse.VeryHighRisk, result.RiskString);
        }

        [Test]
        public void ContrastInducedNephropathyTest_FalseNotError()
        {
            // arrange
            var falseModel = new ContrastInducedNephropathyQuery
            {
                IsNYHA = false,
                VolumeContrast = 1,
                IsDiabetes = false,
                IsAnemya = false,
                IsBigCreatinin = false,
                IsHypotonia = false,
                IsOldAge = false,
                IsVABK = false,
                SpeedKF = 2
            };

            // act
            var handler = new ContrastInducedNephropathyHandler();
            var result = handler.Handle(falseModel).Result;

            // assert
            Assert.AreEqual(3, result.Index);
            Assert.AreEqual(0.04, result.DialysisChanceProcent);
            Assert.AreEqual(7.5, result.Risk);
            Assert.AreEqual(ContrastInducedNephropathyResponse.LowRisk, result.RiskString);
        }

        [Test]
        public void ContrastInducedNephropathyTest_NotError()
        {
            // arrange
            var model = new ContrastInducedNephropathyQuery
            {
                IsNYHA = true,
                VolumeContrast = 1,
                IsDiabetes = false,
                IsAnemya = false,
                IsBigCreatinin = false,
                IsHypotonia = false,
                IsOldAge = false,
                IsVABK = false,
                SpeedKF = 2
            };

            // act
            var handler = new ContrastInducedNephropathyHandler();
            var result = handler.Handle(model).Result;

            // assert
            Assert.AreEqual(8, result.Index);
            Assert.AreEqual(0.12, result.DialysisChanceProcent);
            Assert.AreEqual(14, result.Risk);
            Assert.AreEqual(ContrastInducedNephropathyResponse.MediumRisk, result.RiskString);
        }
    }
}
