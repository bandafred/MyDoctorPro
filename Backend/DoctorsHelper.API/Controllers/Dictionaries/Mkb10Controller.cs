using System.Threading.Tasks;
using DoctorsHelper.Dictionaries.BL.Mkb10;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Dictionaries
{
    [Route("api/dictionaries/[controller]/[action]")]
    public class Mkb10Controller : ControllerBase
    {
        private readonly Mkb10Handler _handler;

        public Mkb10Controller(Mkb10Handler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<Mkb10Response> GetRecords(Mkb10Query query)
        {
            return await _handler.Handle(query);
        }
    }
}
