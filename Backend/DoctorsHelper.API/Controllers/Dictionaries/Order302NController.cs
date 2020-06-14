using System.Threading.Tasks;
using DoctorsHelper.Dictionaries.BL.Order302N;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Dictionaries
{
    [Route("api/dictionaries/[controller]/[action]")]
    public class Order302NController : ControllerBase
    {
        private readonly Order302NHandler _handler;

        public Order302NController(Order302NHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<Order302NResponse> GetRecords(Order302NQuery query)
        {
            return await _handler.Handle(query);
        }
    }
}