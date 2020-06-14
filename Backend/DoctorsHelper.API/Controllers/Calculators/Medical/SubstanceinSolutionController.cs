using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.Medical.SubstanceinSolution;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.Medical
{
    [Route("api/calculators/[controller]/[action]")]
    public class SubstanceinSolutionController : ControllerBase
    {
        private readonly SubstanceinSolutionHandler _substanceinSolutionHandler;

        public SubstanceinSolutionController(SubstanceinSolutionHandler SubstanceinSolutionHandler)
        {
            _substanceinSolutionHandler = SubstanceinSolutionHandler;
        }

        [HttpPost]
        public async Task<SubstanceinSolutionResponse> CalculateSubstanceinSolution(SubstanceinSolutionQuery query)
        {
            return await _substanceinSolutionHandler.Handle(query);
        }
    }
}
