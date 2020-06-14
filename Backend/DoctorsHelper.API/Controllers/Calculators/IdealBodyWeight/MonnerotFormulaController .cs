using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.MonnerotFormula;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.IdealBodyWeight
{
    [Route("api/calculators/IdealBodyWeight/[controller]/[action]")]
    public class MonnerotFormulaController : ControllerBase
    {
        private readonly MonnerotFormulaHandler _handler;

        public MonnerotFormulaController(MonnerotFormulaHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<MonnerotFormulaResponse> Calculate(MonnerotFormulaQuery query)
        {
            return await _handler.Handle(query);
        }
    }
}
