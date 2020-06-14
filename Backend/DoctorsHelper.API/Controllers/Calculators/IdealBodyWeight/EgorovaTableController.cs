using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.EgorovaTable;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.IdealBodyWeight
{
    [Route("api/calculators/IdealBodyWeight/[controller]/[action]")]
    public class EgorovaTableController : ControllerBase
    {
        private readonly EgorovaTableHandler _handler;

        public EgorovaTableController(EgorovaTableHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<EgorovaTableResponse> Calculate(EgorovaTableQuery query)
        {
            return await _handler.Handle(query);
        }
    }
}
