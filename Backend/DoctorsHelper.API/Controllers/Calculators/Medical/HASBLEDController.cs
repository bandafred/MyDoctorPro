using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.Medical.HASBLED;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.Medical
{
    [Route("api/calculators/[controller]/[action]")]
    public class HASBLEDController : ControllerBase
    {
        private readonly HASBLEDHandler _hASBLEDHandler;

        public HASBLEDController(HASBLEDHandler HASBLEDHandler)
        {
            _hASBLEDHandler = HASBLEDHandler;
        }

        [HttpPost]
        public async Task<HASBLEDResponse> CalculateHASBLED(HASBLEDQuery query)
        {
            return await _hASBLEDHandler.Handle(query);
        }
    }
}
