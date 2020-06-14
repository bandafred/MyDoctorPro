using System;

namespace DoctorsHelper.ArterialPressure.Data
{
    /// <summary>
    /// Запись дневника
    /// </summary>
    public class DiaryRecord
    {
        /// <summary> Идентификатор записи </summary>
        public int Id { get; set; }
        /// <summary> Идентификатор пользователя </summary>
        public string UserId { get; set; }

        /// <summary> Систолическое артериальное давление </summary>
        public int SystolicBloodPressure { get; set; }

        /// <summary> Диастолическое артериальное давление </summary>
        public int DiastolicBloodPressure { get; set; }

        /// <summary> Описание </summary>
        public string Description { get; set; }

        /// <summary> Количество принятых препаратов скорой помощи за последние 12 часов </summary>
        public int AmbulanceDrugsNumber { get; set; }

        /// <summary> Пульс </summary>
        public int Pulse { get; set; }

        /// <summary> Уровень глюкозы </summary>
        public double? GlucoseLevel { get; set; }

        /// <summary> Дата записи </summary>
        public DateTime Date { get; set; }

        /// <summary> Параметр отражающий являются ли показатели показателями на утро </summary>
        public bool IsMorning { get; set; }


        /// <summary> Пользователь </summary>
        public virtual User User { get; set; }
    }
}