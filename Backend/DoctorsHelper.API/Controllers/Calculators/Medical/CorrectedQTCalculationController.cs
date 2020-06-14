using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.Medical.CorrectedQTCalculation;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.Medical
{
    [Route("api/calculators/[controller]/[action]")]
    public class CorrectedQTCalculationController : ControllerBase
    {
        private readonly CorrectedQTCalculationHandler _сorrectedQTCalculationHandler;

        public CorrectedQTCalculationController(CorrectedQTCalculationHandler CorrectedQTCalculationHandler)
        {
            _сorrectedQTCalculationHandler = CorrectedQTCalculationHandler;
        }

        [HttpPost]
        public async Task<CorrectedQTCalculationResponse> CalculateCorrectedQTCalculation(CorrectedQTCalculationQuery query)
        {
            return await _сorrectedQTCalculationHandler.Handle(query);
        }
    }
}
