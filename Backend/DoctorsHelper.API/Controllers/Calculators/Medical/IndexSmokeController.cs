using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.Medical.IndexSmoke;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.Medical
{
    [Route("api/calculators/[controller]/[action]")]
    public class IndexSmokeController : ControllerBase
    {
        private readonly IndexSmokeHandler _indexSmokeHandler;

        public IndexSmokeController(IndexSmokeHandler IndexSmokeHandler)
        {
            _indexSmokeHandler = IndexSmokeHandler;
        }

        [HttpPost]
        public async Task<IndexSmokeResponse> CalculateIndexSmoke(IndexSmokeQuery query)
        {
            return await _indexSmokeHandler.Handle(query);
        }
    }
}
