namespace DoctorsHelper.Dictionaries.Data
{
    /// <summary>
    /// Запись из Приказа Минздравсоцразвития России от 27.04.2012 N 417н
    /// "Об утверждении перечня профессиональных заболеваний" (Зарегистрировано в Минюсте России 15.05.2012 N 24168)
    /// </summary>
    public class Order417NRecord
    {
        /// <summary> Идентификатор </summary>
        public int Id { get; set; }

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