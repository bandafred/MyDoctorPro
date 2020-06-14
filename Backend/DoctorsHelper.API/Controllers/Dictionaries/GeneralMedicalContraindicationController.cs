using System.Threading.Tasks;
using DoctorsHelper.Dictionaries.BL.GeneralMedicalContraindications;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Dictionaries
{
    [Route("api/dictionaries/[controller]/[action]")]
    public class GeneralMedicalContraindicationController : ControllerBase
    {
        private readonly GeneralMedicalContraindicationHandler _handler;

        public GeneralMedicalContraindicationController(GeneralMedicalContraindicationHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<GeneralMedicalContraindicationResponse> GetRecords(GeneralMedicalContraindicationQuery query)
        {
            return await _handler.Handle(query);
        }
    }
}