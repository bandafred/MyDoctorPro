#nullable enable
using System;
using DoctorsHelper.ArterialPressure.Data;
using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.ArterialPressure.BL.DiaryAddRecord
{
    /// <summary> Команда для добавления записи в Журнал </summary>
    public class DiaryAddRecordCommand : ICommand<DiaryAddRecordResponse>, IMapTo<DiaryRecord>
    {
        /// <summary> Систолическое артериальное давление </summary>
        public int? SystolicBloodPressure { get; set; }

        /// <summary> Диастолическое артериальное давление </summary>
        public int? DiastolicBloodPressure { get; set; }

        /// <summary> Описание </summary>
        public string? Description { get; set; }

        /// <summary> Количество принятых препаратов скорой помощи за последние 12 часов </summary>
        public int? AmbulanceDrugsNumber { get; set; }

        /// <summary> Пульс </summary>
        public int? Pulse { get; set; }

        /// <summary> Уровень глюкозы </summary>
        public int? GlucoseLevel { get; set; }

        /// <summary> Дата записи </summary>
        public DateTime? Date { get; set; }

        /// <summary> Параметр отражающий являются ли показатели показателями на утро </summary>
        public bool? IsMorning { get; set; }
    }
}