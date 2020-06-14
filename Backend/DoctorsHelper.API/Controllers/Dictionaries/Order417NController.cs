using System.Threading.Tasks;
using DoctorsHelper.Dictionaries.BL.Order417N;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Dictionaries
{
    [Route("api/dictionaries/[controller]/[action]")]
    public class Order417NController : ControllerBase
    {
        private readonly Order417NHandler _handler;

        public Order417NController(Order417NHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<Order417NResponse> GetRecords(Order417NQuery query)
        {
            return await _handler.Handle(query);
        }
    }
}