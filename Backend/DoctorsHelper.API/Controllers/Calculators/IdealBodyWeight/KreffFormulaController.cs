using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.KreffFormula;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.IdealBodyWeight
{
    [Route("api/calculators/IdealBodyWeight/[controller]/[action]")]
    public class KreffFormulaController : ControllerBase
    {
        private readonly KreffFormulaHandler _handler;

        public KreffFormulaController(KreffFormulaHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<KreffFormulaResponse> Calculate(KreffFormulaQuery query)
        {
            return await _handler.Handle(query);
        }
    }
}
