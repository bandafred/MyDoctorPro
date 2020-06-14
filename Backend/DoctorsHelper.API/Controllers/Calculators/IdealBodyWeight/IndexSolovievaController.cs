using System.Threading.Tasks;
using DoctorsHelper.Calculators.BL.IdealBodyWeight.IndexSolovieva;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.IdealBodyWeight
{
    [Route("api/calculators/[controller]/[action]")]
    public class IndexSolovievaController : ControllerBase
    {
        private readonly IndexSolovievaHandler _indexSolovievaHandler;

        public IndexSolovievaController(IndexSolovievaHandler indexSolovievaHandler)
        {
            _indexSolovievaHandler = indexSolovievaHandler;
        }

        [HttpPost]
        public async Task<IndexSolovievaResponse> CalculateIndexSolovieva(IndexSolovievaQuery query)
        {
            return await _indexSolovievaHandler.Handle(query);
        }
    }
}
