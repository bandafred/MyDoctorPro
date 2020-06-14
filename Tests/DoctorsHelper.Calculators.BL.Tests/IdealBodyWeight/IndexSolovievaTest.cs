using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.IndexSolovieva;
using NUnit.Framework;

namespace DoctorsHelper.Calculators.BL.Tests.IdealBodyWeight
{
    [TestFixture]
    public class IndexSolovievaTest
    {
        [Test]
        public void IndexSolovievaTest_NotError()
        {
            // arrange

            //Астенический: менее 18 см у мужчин, менее 15 см у женщин.
            var modelAsteniсMan = new IndexSolovievaQuery
            {
                IsMen = true,
                WristLength = 17
            };

            var modelAsteniсWoman = new IndexSolovievaQuery
            {
                IsMen = false,
                WristLength = 14
            };

            //Нормостенический: 18 - 20 см у мужчин, 15 - 17 у женщин.
            var modelNormaMen = new IndexSolovievaQuery
            {
                IsMen = true,
                WristLength = 19
            };
            var modelNormaWomen = new IndexSolovievaQuery
            {
                IsMen = false,
                WristLength = 16
            };

            //Гиперстенический: более 20 см у мужчин, более 17 см у женщин.
            var modelHyperMen = new IndexSolovievaQuery
            {
                IsMen = true,
                WristLength = 22
            };
            var modelHyperWomen = new IndexSolovievaQuery
            {
                IsMen = false,
                WristLength = 22
            };


            // act
            var handler = new IndexSolovievaHandler();

            //Астенический: менее 18 см у мужчин, менее 15 см у женщин.
            var resultAsteniсMan = handler.Handle(modelAsteniсMan).Result;
            var resultAsteniсWoman = handler.Handle(modelAsteniсWoman).Result;
            
            //Нормостенический: 18 - 20 см у мужчин, 15 - 17 у женщин.
            var resultNormaMan = handler.Handle(modelNormaMen).Result;
            var resultNormaWoman = handler.Handle(modelNormaWomen).Result;

            //Гиперстенический: более 20 см у мужчин, более 17 см у женщин.
            var resultHyperMan = handler.Handle(modelHyperMen).Result;
            var resultHyperWoman = handler.Handle(modelHyperWomen).Result;


            // assert
            //Астенический: менее 18 см у мужчин, менее 15 см у женщин.
            Assert.AreEqual(IndexSolovievaResultsEnum.Asthenic, resultAsteniсMan.IndexSolovieva);
            Assert.AreEqual(IndexSolovievaResultsEnum.Asthenic, resultAsteniсWoman.IndexSolovieva);

            //Нормостенический: 18 - 20 см у мужчин, 15 - 17 у женщин.
            Assert.AreEqual(IndexSolovievaResultsEnum.Norma, resultNormaMan.IndexSolovieva);
            Assert.AreEqual(IndexSolovievaResultsEnum.Norma, resultNormaWoman.IndexSolovieva);

            //Гиперстенический: более 20 см у мужчин, более 17 см у женщин.
            Assert.AreEqual(IndexSolovievaResultsEnum.Hyper, resultHyperMan.IndexSolovieva);
            Assert.AreEqual(IndexSolovievaResultsEnum.Hyper, resultHyperWoman.IndexSolovieva);
        }


        [Test]
        public void IndexSolovievaTest_LessOrMoreError()
        {
            // arrange
            var modelLess = new IndexSolovievaQuery
            {
                IsMen = true,
                WristLength = 3
            };

            var modelMore = new IndexSolovievaQuery
            {
                IsMen = false,
                WristLength = 501
            };

            // act
            var handler = new IndexSolovievaHandler();

            var resultLessException = handler.Handle(modelLess).Exception;
            var errorModel1 = resultLessException.GetErrorListResponseFromException();

            var resultMoreException = handler.Handle(modelMore).Exception;
            var errorModel2 = resultMoreException.GetErrorListResponseFromException();

            // assert
            Assert.IsTrue(errorModel1 != null);
            Assert.IsTrue(errorModel1.Errors.Count == 1);
            Assert.IsTrue(errorModel1.Errors.Contains(IndexSolovievaQueryValidator.WristLengthIncorrectMessage));

            Assert.IsTrue(errorModel2 != null);
            Assert.IsTrue(errorModel2.Errors.Count == 1);
            Assert.IsTrue(errorModel2.Errors.Contains(IndexSolovievaQueryValidator.WristLengthIncorrectMessage));
        }
    }
}
