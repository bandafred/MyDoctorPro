#nullable enable
using System;
using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.ArterialPressure.BL.DiaryGetRecords
{
    /// <summary> Запрос на получение записей Журнал </summary>
    public class DiaryGetRecordsQuery : IQuery<DiaryGetRecordsResponse>
    {
        /// <summary> С какой даты получить записи </summary>
        public DateTime? FromDate { get; set; }
        
        /// <summary> До какой даты получить записи </summary>
        public DateTime? ToDate { get; set; }
    }
}