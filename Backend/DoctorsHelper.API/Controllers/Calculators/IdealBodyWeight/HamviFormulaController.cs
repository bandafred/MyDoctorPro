using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.HamviFormula;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.IdealBodyWeight
{
    [Route("api/calculators/IdealBodyWeight/[controller]/[action]")]
    public class HamviFormulaController : ControllerBase
    {
        private readonly HamviFormulaHandler _handler;

        public HamviFormulaController(HamviFormulaHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<HamviFormulaResponse> Calculate(HamviFormulaQuery query)
        {
            return await _handler.Handle(query);
        }
    }
}
