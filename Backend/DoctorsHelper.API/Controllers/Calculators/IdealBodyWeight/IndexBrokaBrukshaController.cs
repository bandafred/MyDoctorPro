using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.IndexBrokaBruksha;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.IdealBodyWeight
{
    [Route("api/calculators/IdealBodyWeight/[controller]/[action]")]
    public class IndexBrokaBrukshaController : ControllerBase
    {
        private readonly IndexBrokaBrukshaHandler _handler;

        public IndexBrokaBrukshaController(IndexBrokaBrukshaHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IndexBrokaBrukshaResponse> Calculate(IndexBrokaBrukshaQuery query)
        {
            return await _handler.Handle(query);
        }
    }
}
