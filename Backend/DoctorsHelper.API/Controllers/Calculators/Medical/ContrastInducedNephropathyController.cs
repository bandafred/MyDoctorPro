using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.Medical.ContrastInducedNephropathy;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.Medical
{
    [Route("api/calculators/[controller]/[action]")]
    public class ContrastInducedNephropathyController : ControllerBase
    {
        private readonly ContrastInducedNephropathyHandler _contrastInducedNephropathyHandler;

        public ContrastInducedNephropathyController(ContrastInducedNephropathyHandler ContrastInducedNephropathyHandler)
        {
            _contrastInducedNephropathyHandler = ContrastInducedNephropathyHandler;
        }

        [HttpPost]
        public async Task<ContrastInducedNephropathyResponse> CalculateContrastInducedNephropathy(ContrastInducedNephropathyQuery query)
        {
            return await _contrastInducedNephropathyHandler.Handle(query);
        }
    }
}
