using System.Collections.Generic;
using DoctorsHelper.Dictionaries.BL.Order302N.Models;

namespace DoctorsHelper.Dictionaries.BL.Order302N
{
    /// <summary>
    /// Модель ответа для запроса <see cref="Order302NQuery"/>
    /// </summary>
    public class Order302NResponse
    {
        /// <summary>
        /// Записи
        /// </summary>
        public List<Order302NResponseRecord> Records { get; set; }
    }
}