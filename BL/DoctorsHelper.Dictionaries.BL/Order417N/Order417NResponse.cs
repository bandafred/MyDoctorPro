using System.Collections.Generic;
using DoctorsHelper.Dictionaries.BL.Order417N.Models;

namespace DoctorsHelper.Dictionaries.BL.Order417N
{
    /// <summary>
    /// Модель ответа для запроса <see cref="Order417NQuery"/>
    /// </summary>
    public class Order417NResponse
    {
        /// <summary>
        /// Записи
        /// </summary>
        public List<Order417NResponseRecord> Records { get; set; }
    }
}