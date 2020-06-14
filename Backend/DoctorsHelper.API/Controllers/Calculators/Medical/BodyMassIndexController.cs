using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.Medical.BodyMassIndex;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.Medical
{
    [Route("api/calculators/[controller]/[action]")]
    public class BodyMassIndexController : ControllerBase
    {
        private readonly BodyMassIndexHandler _bodyMassIndexHandler;

        public BodyMassIndexController(BodyMassIndexHandler bodyMassIndexHandler)
        {
            _bodyMassIndexHandler = bodyMassIndexHandler;
        }

        [HttpPost]
        public async Task<BodyMassIndexResponse> CalculateBodyMassIndex(BodyMassIndexQuery query)
        {
            return await _bodyMassIndexHandler.Handle(query);
        }
    }
}
