using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.RobinsonFormula;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.IdealBodyWeight
{
    [Route("api/calculators/IdealBodyWeight/[controller]/[action]")]
    public class RobinsonFormulaController : ControllerBase
    {
        private readonly RobinsonFormulaHandler _handler;

        public RobinsonFormulaController(RobinsonFormulaHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<RobinsonFormulaResponse> Calculate(RobinsonFormulaQuery query)
        {
            return await _handler.Handle(query);
        }
    }
}
