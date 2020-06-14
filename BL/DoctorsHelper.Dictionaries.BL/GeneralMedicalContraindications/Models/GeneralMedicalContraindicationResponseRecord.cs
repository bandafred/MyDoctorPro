using DoctorsHelper.BL.Core.Interfaces;
using DoctorsHelper.Dictionaries.Data;

namespace DoctorsHelper.Dictionaries.BL.GeneralMedicalContraindications.Models
{
    /// <summary>
    /// Модель записи для <see cref="GeneralMedicalContraindicationResponse"/>
    /// </summary>
    public class GeneralMedicalContraindicationResponseRecord : IMapFrom<GeneralMedicalContraindication>
    {
        /// <summary> Идентификатор </summary>
        public int Id { get; set; }

        /// <summary> Заболевание </summary>
        public string Pathology { get; set; }
    }
}