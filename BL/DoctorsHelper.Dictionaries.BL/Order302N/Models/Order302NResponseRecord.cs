using DoctorsHelper.BL.Core.Interfaces;
using DoctorsHelper.Dictionaries.Data;

namespace DoctorsHelper.Dictionaries.BL.Order302N.Models
{
    /// <summary>
    /// Модель записи для <see cref="Order302NResponse"/>
    /// </summary>
    public class Order302NResponseRecord : IMapFrom<Order302NRecord>
    {
        /// <summary> Пункт приказа </summary>
        public string Point { get; set; }

        /// <summary> Наименование вредных и(или) опасных производственных факторов </summary>
        public string Name { get; set; }

        /// <summary> Периодичность осмотров и участие врачей-специалистов </summary>
        public string InspectionFrequency { get; set; }

        /// <summary> Дополнительные медицинские противопоказания </summary>
        public string AdditionalMedicalContraindications { get; set; }

        /// <summary> Номер приложения </summary>
        public int ApplicationItemNumber { get; set; }
    }
}