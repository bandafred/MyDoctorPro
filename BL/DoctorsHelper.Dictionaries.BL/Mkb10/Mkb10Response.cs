using System.Collections.Generic;
using DoctorsHelper.Dictionaries.BL.Mkb10.Models;

namespace DoctorsHelper.Dictionaries.BL.Mkb10
{
    /// <summary>
    /// Модель ответа для запроса <see cref="Mkb10Query"/>
    /// </summary>
    public class Mkb10Response
    {
        /// <summary>
        /// Записи
        /// </summary>
        public List<Mkb10ResponseRecord> Records { get; set; }

        /// <summary>
        /// Общее количество записей
        /// </summary>
        public int TotalCount { get; set; }
    }
}