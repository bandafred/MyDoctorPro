using DoctorsHelper.BL.Core.Interfaces;
using DoctorsHelper.Dictionaries.Data;

namespace DoctorsHelper.Dictionaries.BL.Mkb10.Models
{
    /// <summary>
    /// Модель записи для <see cref="Mkb10Response"/>
    /// </summary>
    public class Mkb10ResponseRecord : IMapFrom<Mkb10Record>
    {
        /// <summary> Код заболевания </summary>
        public string Code { get; set; }

        /// <summary> Название заболевания </summary>
        public string Name { get; set; }
    }
}