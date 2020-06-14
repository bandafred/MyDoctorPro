using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.Medical.Glasgo;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.Medical
{
    [Route("api/calculators/[controller]/[action]")]
    public class GlasgoController : ControllerBase
    {
        private readonly GlasgoHandler _glasgoHandler;

        public GlasgoController(GlasgoHandler GlasgoHandler)
        {
            _glasgoHandler = GlasgoHandler;
        }

        [HttpPost]
        public async Task<GlasgoResponse> CalculateGlasgo(GlasgoQuery query)
        {
            return await _glasgoHandler.Handle(query);
        }
    }
}
