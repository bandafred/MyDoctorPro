using System.Collections.Generic;
using DoctorsHelper.Dictionaries.BL.GeneralMedicalContraindications.Models;

namespace DoctorsHelper.Dictionaries.BL.GeneralMedicalContraindications
{
    /// <summary>
    /// Модель ответа для запроса <see cref="GeneralMedicalContraindicationQuery"/>
    /// </summary>
    public class GeneralMedicalContraindicationResponse
    {
        /// <summary>
        /// Записи
        /// </summary>
        public List<GeneralMedicalContraindicationResponseRecord> Records { get; set; }
    }
}