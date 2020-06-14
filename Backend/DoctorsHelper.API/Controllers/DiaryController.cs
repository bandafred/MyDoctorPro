using System.Threading.Tasks;
using DoctorsHelper.ArterialPressure.BL.DiaryAddRecord;
using DoctorsHelper.ArterialPressure.BL.DiaryGetRecords;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class DiaryController : Controller
    {
        private readonly DiaryAddRecordHandler _diaryAddRecordHandler;
        private readonly DiaryGetRecordsHandler _diaryGetRecordsHandler;

        public DiaryController(DiaryAddRecordHandler diaryAddRecordHandler,
            DiaryGetRecordsHandler diaryGetRecordsHandler)
        {
            _diaryAddRecordHandler = diaryAddRecordHandler;
            _diaryGetRecordsHandler = diaryGetRecordsHandler;
        }

        [HttpPost]
        public async Task<DiaryAddRecordResponse> AddRecord(DiaryAddRecordCommand command)
        {
            return await _diaryAddRecordHandler.Handle(command);
        }

        [HttpGet]
        public async Task<DiaryGetRecordsResponse> GetRecords(DiaryGetRecordsQuery query)
        {
            return await _diaryGetRecordsHandler.Handle(query);
        }
    }
}