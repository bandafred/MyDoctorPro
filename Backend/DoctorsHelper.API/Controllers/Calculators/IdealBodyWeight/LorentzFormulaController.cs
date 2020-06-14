using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.LorentzFormula;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.IdealBodyWeight
{
    [Route("api/calculators/[controller]/[action]")]
    public class LorentzFormulaController : ControllerBase
    {
        private readonly LorentzFormulaHandler _lorentzFormulaHandler;

        public LorentzFormulaController(LorentzFormulaHandler lorentzFormulaHandler)
        {
            _lorentzFormulaHandler = lorentzFormulaHandler;
        }

        [HttpPost]
        public async Task<LorentzFormulaResponse> CalculateLorentzFormula(LorentzFormulaQuery query)
        {
            return await _lorentzFormulaHandler.Handle(query);
        }
    }
}
