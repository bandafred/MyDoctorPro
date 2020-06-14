using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.Medical.InfusionRate;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.Medical
{
    [Route("api/calculators/[controller]/[action]")]
    public class InfusionRateController : ControllerBase
    {
        private readonly InfusionRateHandler _infusionRateHandler;

        public InfusionRateController(InfusionRateHandler InfusionRateHandler)
        {
            _infusionRateHandler = InfusionRateHandler;
        }

        [HttpPost]
        public async Task<InfusionRateResponse> CalculateInfusionRate(InfusionRateQuery query)
        {
            return await _infusionRateHandler.Handle(query);
        }
    }
}
