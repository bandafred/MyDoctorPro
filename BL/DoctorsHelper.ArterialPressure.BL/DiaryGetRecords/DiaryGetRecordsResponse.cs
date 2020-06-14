using System.Collections.Generic;
using DoctorsHelper.ArterialPressure.BL.DiaryGetRecords.Models;

namespace DoctorsHelper.ArterialPressure.BL.DiaryGetRecords
{
    /// <summary> Ответ на Запрос на получение записей Журнал </summary>
    public class DiaryGetRecordsResponse
    {
        /// <summary> Записи </summary>
        public List<DiaryGetRecordsResponseRecord> Records { get; set; } 
    }
}