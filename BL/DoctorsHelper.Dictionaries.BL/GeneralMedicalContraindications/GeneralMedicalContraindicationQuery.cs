using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Dictionaries.BL.GeneralMedicalContraindications
{
    /// <summary>
    /// Модель запроса для <see cref="GeneralMedicalContraindicationResponse"/>
    /// </summary>
    public class GeneralMedicalContraindicationQuery : ISearchTextQuery<GeneralMedicalContraindicationResponse>
    {
        /// <inheritdoc />
        public string SearchText { get; set; }
    }
}