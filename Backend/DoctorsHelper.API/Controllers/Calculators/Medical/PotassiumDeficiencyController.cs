using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.Medical.PotassiumDeficiency;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.Medical
{
    [Route("api/calculators/[controller]/[action]")]
    public class PotassiumDeficiencyController : ControllerBase
    {
        private readonly PotassiumDeficiencyHandler _PotassiumDeficiencyHandler;

        public PotassiumDeficiencyController(PotassiumDeficiencyHandler PotassiumDeficiencyHandler)
        {
            _PotassiumDeficiencyHandler = PotassiumDeficiencyHandler;
        }

        [HttpPost]
        public async Task<PotassiumDeficiencyResponse> CalculatePotassiumDeficiency(PotassiumDeficiencyQuery query)
        {
            return await _PotassiumDeficiencyHandler.Handle(query);
        }
    }
}
