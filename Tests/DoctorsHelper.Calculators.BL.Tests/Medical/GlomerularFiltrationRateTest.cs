using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.Medical.GlomerularFiltrationRate;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.Medical
{
    [TestFixture]
    public class GlomerularFiltrationRateTest
    {
        [Test]
        public void GlomerularFiltrationRateTest_NotError()
        {
            // arrange
            var res = new GlomerularFiltrationRateQuery
            {
              Height = 150,
              IsMen = true,
              Age = 50,
              Weight = 50,
              Creatinin = 50
            };


            // act
            var handler = new GlomerularFiltrationRateHandler();
            var result = handler.Handle(res).Result;

            // assert
            Assert.AreEqual(1.4325003551708728d, result.BodyArea);
            Assert.AreEqual(120.13792772763173d, result.CKDEPI);
            Assert.AreEqual(112.5d, result.CokcroftGault);
            Assert.AreEqual(136, result.CokcroftGaultTwo);
            Assert.AreEqual(162.52361466226301d, result.MDRD);
            Assert.AreEqual(GlomerularFiltrationRateResponse.FirstStage, result.Rewsume);
        }

        [Test]
        public void GlomerularFiltrationRateTest_LessError()
        {
            // arrange
            var modelLittle = new GlomerularFiltrationRateQuery
            {
                Height = 0,
                IsMen = true,
                Age = 0,
                Weight = 0,
                Creatinin = 0
            };

            // act
            var handler = new GlomerularFiltrationRateHandler();
            var errorModel = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel != null);
            Assert.IsTrue(errorModel.Errors.Count == 4);
            Assert.IsTrue(errorModel.Errors.Contains(GlomerularFiltrationRateQueryValidator.HeightIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(GlomerularFiltrationRateQueryValidator.AgeIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(GlomerularFiltrationRateQueryValidator.CreatininIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(GlomerularFiltrationRateQueryValidator.WeightIncorrectMessage));
        }

        [Test]
        public void GlomerularFiltrationRateTest_MoreError()
        {
            // arrange
            var modelMore = new GlomerularFiltrationRateQuery
            {

                Height = 1000,
                IsMen = true,
                Age = 151,
                Weight = 501,
                Creatinin = 1000
            };

            // act
            var handler = new GlomerularFiltrationRateHandler();
            var errorModel = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel != null);
            Assert.IsTrue(errorModel.Errors.Count == 4);
            Assert.IsTrue(errorModel.Errors.Contains(GlomerularFiltrationRateQueryValidator.HeightIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(GlomerularFiltrationRateQueryValidator.AgeIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(GlomerularFiltrationRateQueryValidator.CreatininIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(GlomerularFiltrationRateQueryValidator.WeightIncorrectMessage));
        }
    }
}
