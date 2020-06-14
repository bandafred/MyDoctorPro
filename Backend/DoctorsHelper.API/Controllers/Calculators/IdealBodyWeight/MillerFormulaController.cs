using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.MillerFormula;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.IdealBodyWeight
{
    [Route("api/calculators/IdealBodyWeight/[controller]/[action]")]
    public class MillerFormulaController : ControllerBase
    {
        private readonly MillerFormulaHandler _handler;

        public MillerFormulaController(MillerFormulaHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<MillerFormulaResponse> Calculate(MillerFormulaQuery query)
        {
            return await _handler.Handle(query);
        }
    }
}
