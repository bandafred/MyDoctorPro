namespace DoctorsHelper.Dictionaries.Data
{
    /// <summary>
    /// Запись из Приказа Минздравсоцразвития России от 12.04.2011 N 302н (ред. от 13.12.2019)
    /// "Об утверждении перечней вредных и (или) опасных производственных факторов и работ,
    /// при выполнении которых проводятся обязательные предварительные и периодические медицинские
    /// осмотры (обследования), и Порядка проведения обязательных предварительных и периодических
    /// медицинских осмотров (обследований) работников, занятых на тяжелых работах и на работах с
    /// вредными и (или) опасными условиями труда" (Зарегистрировано в Минюсте России 21.10.2011 N 22111)
    /// </summary>
    public class Order302NRecord
    {
        /// <summary> Идентификатор </summary>
        public int Id { get; set; }

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