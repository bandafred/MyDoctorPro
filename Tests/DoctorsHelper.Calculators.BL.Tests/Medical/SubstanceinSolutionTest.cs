using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.Medical.SubstanceinSolution;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.Medical
{
    [TestFixture]
    public class SubstanceinSolutionTest
    {
        [Test]
        public void SubstanceinSolutionTest_NotError()
        {
            // arrange
            var res = new SubstanceinSolutionQuery
            {
                Procent = 50,
                Volume = 2
            };


            // act
            var handler = new SubstanceinSolutionHandler();
            var result = handler.Handle(res).Result;

            // assert
            Assert.AreEqual(1, result.Recount);
        }

        [Test]
        public void SubstanceinSolutionTest_LessError()
        {
            // arrange
            var modelLittle = new SubstanceinSolutionQuery
            {
                Procent = 0,
                Volume = 0
            };

            // act
            var handler = new SubstanceinSolutionHandler();
            var errorModel = handler.Handle(modelLittle).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel != null);
            Assert.IsTrue(errorModel.Errors.Count == 2);
            Assert.IsTrue(errorModel.Errors.Contains(SubstanceinSolutionQueryValidator.ProcentIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(SubstanceinSolutionQueryValidator.VolumeIncorrectMessage));
        }

        [Test]
        public void SubstanceinSolutionTest_MoreError()
        {
            // arrange
            var modelMore = new SubstanceinSolutionQuery
            {
                Procent = 101,
                Volume = 1000
            };

            // act
            var handler = new SubstanceinSolutionHandler();
            var errorModel = handler.Handle(modelMore).Exception.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel != null);
            Assert.IsTrue(errorModel.Errors.Count == 2);
            Assert.IsTrue(errorModel.Errors.Contains(SubstanceinSolutionQueryValidator.ProcentIncorrectMessage));
            Assert.IsTrue(errorModel.Errors.Contains(SubstanceinSolutionQueryValidator.VolumeIncorrectMessage));
        }
    }
}
