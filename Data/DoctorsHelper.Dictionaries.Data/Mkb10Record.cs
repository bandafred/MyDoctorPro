namespace DoctorsHelper.Dictionaries.Data
{
    /// <summary>
    /// Запись из Международной классификации заболеваний (МКБ-10)
    /// </summary>
    public class Mkb10Record
    {
        /// <summary> Идентификатор </summary>
        public int Id { get; set; }

        /// <summary> Код заболевания </summary>
        public string Code { get; set; }

        /// <summary> Название заболевания </summary>
        public string Name { get; set; }
    }
}
