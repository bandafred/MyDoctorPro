using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.Medical.GlomerularFiltrationRate;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.Medical
{
    [Route("api/calculators/[controller]/[action]")]
    public class GlomerularFiltrationRateController : ControllerBase
    {
        private readonly GlomerularFiltrationRateHandler _glomerularFiltrationRateHandler;

        public GlomerularFiltrationRateController(GlomerularFiltrationRateHandler GlomerularFiltrationRateHandler)
        {
            _glomerularFiltrationRateHandler = GlomerularFiltrationRateHandler;
        }

        [HttpPost]
        public async Task<GlomerularFiltrationRateResponse> CalculateGlomerularFiltrationRate(GlomerularFiltrationRateQuery query)
        {
            return await _glomerularFiltrationRateHandler.Handle(query);
        }
    }
}
