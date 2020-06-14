using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.Borngardt;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.IdealBodyWeight
{
    [Route("api/calculators/[controller]/[action]")]
    public class IdealBodyWeightController : ControllerBase
    {
        private readonly BorngardtHandler _borngardtHandler;

        public IdealBodyWeightController(BorngardtHandler borngardtHandler)
        {
            _borngardtHandler = borngardtHandler;
        }

        [HttpPost]
        public async Task<BorngardtResponse> CalculateBorngardt(BorngardtQuery query)
        {
            return await _borngardtHandler.Handle(query);
        }
    }
}
