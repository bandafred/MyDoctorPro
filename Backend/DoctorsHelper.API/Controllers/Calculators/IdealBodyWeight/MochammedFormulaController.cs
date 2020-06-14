using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.MochammedFormula;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.IdealBodyWeight
{
    [Route("api/calculators/IdealBodyWeight/[controller]/[action]")]
    public class MochammedFormulaController : ControllerBase
    {
        private readonly MochammedFormulaHandler _handler;

        public MochammedFormulaController(MochammedFormulaHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<MochammedFormulaResponse> Calculate(MochammedFormulaQuery query)
        {
            return await _handler.Handle(query);
        }
    }
}
