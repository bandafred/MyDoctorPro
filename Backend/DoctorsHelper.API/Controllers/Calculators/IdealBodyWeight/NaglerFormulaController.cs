using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.NaglerFormula;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.IdealBodyWeight
{
    [Route("api/calculators/IdealBodyWeight/[controller]/[action]")]
    public class NaglerFormulaController : ControllerBase
    {
        private readonly NaglerFormulaHandler _handler;

        public NaglerFormulaController(NaglerFormulaHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<NaglerFormulaResponse> Calculate(NaglerFormulaQuery query)
        {
            return await _handler.Handle(query);
        }
    }
}
