using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.IndexBroka;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.IdealBodyWeight
{
    [Route("api/calculators/IdealBodyWeight/[controller]/[action]")]
    public class IndexBrokaController : ControllerBase
    {
        private readonly IndexBrokaHandler _handler;

        public IndexBrokaController(IndexBrokaHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IndexBrokaResponse> Calculate(IndexBrokaQuery query)
        {
            return await _handler.Handle(query);
        }
    }
}
