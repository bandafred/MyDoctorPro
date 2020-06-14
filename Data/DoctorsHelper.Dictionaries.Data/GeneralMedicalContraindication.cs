namespace DoctorsHelper.Dictionaries.Data
{
    /// <summary>
    /// Запись из Перечня общих медицинских противопоказаний
    /// </summary>
    public class GeneralMedicalContraindication
    {
        /// <summary> Идентификатор </summary>
        public int Id { get; set; }

        /// <summary> Заболевание </summary>
        public string Pathology { get; set; }
    }
}