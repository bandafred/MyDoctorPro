using DoctorsHelper.BL.Core.Interfaces;
using DoctorsHelper.Dictionaries.Data;

namespace DoctorsHelper.Dictionaries.BL.Order417N.Models
{
    /// <summary>
    /// Модель записи для <see cref="Order417NResponse"/>
    /// </summary>
    public class Order417NResponseRecord : IMapFrom<Order417NRecord>
    {
        /// <summary> Пункт приказа </summary>
        public string Point { get; set; }

        /// <summary> Перечень заболеваний, связанных с воздействием вредных и (или) опасных производственных факторов </summary>
        public string Nosology { get; set; }

        /// <summary> Код заболевания по МКБ-10 </summary>
        public string CodeNosology { get; set; }

        /// <summary> Наименование вредного и (или) опасного производственного фактора </summary>
        public string DangerFactor { get; set; }

        /// <summary> Код внешней причины по МКБ-10 </summary>
        public string CodeExternal { get; set; }
    }
}