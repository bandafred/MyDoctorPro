using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.Medical.ScoreScale;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.Medical
{
    [Route("api/calculators/[controller]/[action]")]
    public class ScoreScaleController : ControllerBase
    {
        private readonly ScoreScaleHandler _ScoreScaleHandler;

        public ScoreScaleController(ScoreScaleHandler ScoreScaleHandler)
        {
            _ScoreScaleHandler = ScoreScaleHandler;
        }

        [HttpPost]
        public async Task<ScoreScaleResponse> CalculateScoreScale(ScoreScaleQuery query)
        {
            return await _ScoreScaleHandler.Handle(query);
        }
    }
}
