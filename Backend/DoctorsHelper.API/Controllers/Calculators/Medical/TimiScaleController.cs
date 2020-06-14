using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.Medical.TimiScale;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.Medical
{
    [Route("api/calculators/[controller]/[action]")]
    public class TimiScaleController : ControllerBase
    {
        private readonly TimiScaleHandler _timiScaleHandler;

        public TimiScaleController(TimiScaleHandler timiScaleHandler)
        {
            _timiScaleHandler = timiScaleHandler;
        }

        [HttpPost]
        public async Task<TimiScaleResponse> CalculateTimiScale(TimiScaleQuery query)
        {
            return await _timiScaleHandler.Handle(query);
        }
    }
}
