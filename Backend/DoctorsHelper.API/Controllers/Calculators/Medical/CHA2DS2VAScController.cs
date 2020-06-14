using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.Medical.CHA2DS2VASc;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.Medical
{
    [Route("api/calculators/[controller]/[action]")]
    public class CHA2DS2VAScController : ControllerBase
    {
        private readonly CHA2DS2VAScHandler _cHA2DS2VAScHandler;

        public CHA2DS2VAScController(CHA2DS2VAScHandler CHA2DS2VAScHandler)
        {
            _cHA2DS2VAScHandler = CHA2DS2VAScHandler;
        }

        [HttpPost]
        public async Task<CHA2DS2VAScResponse> CalculateCHA2DS2VASc(CHA2DS2VAScQuery query)
        {
            return await _cHA2DS2VAScHandler.Handle(query);
        }
    }
}
