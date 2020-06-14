using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.Medical.Glasgo;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.Medical
{
    [TestFixture]
    public class GlasgoTest
    {
        [Test]
        public void GlasgoTest_ClearMindNotError()
        {
            // arrange
            var model = new GlasgoQuery
            {
                MotorResponse = 6,
                VerbalResponse = 5,
                EyeResponse = 4
            };

            // act
            var handler = new GlasgoHandler();
            var result = handler.Handle(model).Result;

            // assert
            Assert.AreEqual(15, result.Index);
            Assert.AreEqual(GlasgoResponse.ClearMind, result.GetResult);
        }

        [Test]
        public void GlasgoTest_LightStunningNotError()
        {
            // arrange
            var model = new GlasgoQuery
            {
                MotorResponse = 5,
                VerbalResponse = 5,
                EyeResponse = 4
            };

            // act
            var handler = new GlasgoHandler();
            var result = handler.Handle(model).Result;

            // assert
            Assert.AreEqual(14, result.Index);
            Assert.AreEqual(GlasgoResponse.LightStunning, result.GetResult);
        }

        [Test]
        public void GlasgoTest_ModerateStunNotError()
        {
            // arrange
            var model = new GlasgoQuery
            {
                MotorResponse = 5,
                VerbalResponse = 5,
                EyeResponse = 3
            };

            // act
            var handler = new GlasgoHandler();
            var result = handler.Handle(model).Result;

            // assert
            Assert.AreEqual(13, result.Index);
            Assert.AreEqual(GlasgoResponse.ModerateStun, result.GetResult);
        }

        [Test]
        public void GlasgoTest_DeepStunningNotError()
        {
            // arrange
            var model = new GlasgoQuery
            {
                MotorResponse = 5,
                VerbalResponse = 4,
                EyeResponse = 3
            };

            // act
            var handler = new GlasgoHandler();
            var result = handler.Handle(model).Result;

            // assert
            Assert.AreEqual(12, result.Index);
            Assert.AreEqual(GlasgoResponse.DeepStunning, result.GetResult);
        }

        [Test]
        public void GlasgoTest_SoporNotError()
        {
            // arrange
            var model = new GlasgoQuery
            {
                MotorResponse = 4,
                VerbalResponse = 4,
                EyeResponse = 3
            };

            // act
            var handler = new GlasgoHandler();
            var result = handler.Handle(model).Result;

            // assert
            Assert.AreEqual(11, result.Index);
            Assert.AreEqual(GlasgoResponse.Sopor, result.GetResult);
        }

        [Test]
        public void GlasgoTest_ModerateComaNotError()
        {
            // arrange
            var model = new GlasgoQuery
            {
                MotorResponse = 1,
                VerbalResponse = 3,
                EyeResponse = 3
            };

            // act
            var handler = new GlasgoHandler();
            var result = handler.Handle(model).Result;

            // assert
            Assert.AreEqual(7, result.Index);
            Assert.AreEqual(GlasgoResponse.ModerateComa, result.GetResult);
        }

        [Test]
        public void GlasgoTest_DeepComaNotError()
        {
            // arrange
            var model = new GlasgoQuery
            {
                MotorResponse = 1,
                VerbalResponse = 2,
                EyeResponse = 2
            };

            // act
            var handler = new GlasgoHandler();
            var result = handler.Handle(model).Result;

            // assert
            Assert.AreEqual(5, result.Index);
            Assert.AreEqual(GlasgoResponse.DeepComa, result.GetResult);
        }

        [Test]
        public void GlasgoTest_BeyondComaNotError()
        {
            // arrange
            var model = new GlasgoQuery
            {
                MotorResponse = 1,
                VerbalResponse = 1,
                EyeResponse = 1
            };

            // act
            var handler = new GlasgoHandler();
            var result = handler.Handle(model).Result;

            // assert
            Assert.AreEqual(3, result.Index);
            Assert.AreEqual(GlasgoResponse.BeyondComa, result.GetResult);
        }
    }
}
