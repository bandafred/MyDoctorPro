using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.DevinFormula;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.IdealBodyWeight
{
    [Route("api/calculators/IdealBodyWeight/[controller]/[action]")]
    public class DevinFormulaController : ControllerBase
    {
        private readonly DevinFormulaHandler _handler;

        public DevinFormulaController(DevinFormulaHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<DevinFormulaResponse> Calculate(DevinFormulaQuery query)
        {
            return await _handler.Handle(query);
        }
    }
}
