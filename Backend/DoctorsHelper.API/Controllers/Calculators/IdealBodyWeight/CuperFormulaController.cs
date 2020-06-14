using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.CuperFormula;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.IdealBodyWeight
{
    [Route("api/calculators/IdealBodyWeight/[controller]/[action]")]
    public class CuperFormulaController : ControllerBase
    {
        private readonly CuperFormulaHandler _handler;

        public CuperFormulaController(CuperFormulaHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<CuperFormulaResponse> Calculate(CuperFormulaQuery query)
        {
            return await _handler.Handle(query);
        }
    }
}
