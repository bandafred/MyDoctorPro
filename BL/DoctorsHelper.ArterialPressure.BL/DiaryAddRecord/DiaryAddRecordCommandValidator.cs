using FluentValidation;

namespace DoctorsHelper.ArterialPressure.BL.DiaryAddRecord
{
    /// <summary>
    /// Валидатор для <see cref="DiaryAddRecordCommand"/>
    /// </summary>
    public class DiaryAddRecordCommandValidator : AbstractValidator<DiaryAddRecordCommand>
    {
        public const string SystolicBloodPressureEmptyMessage = "Систолическое артериальное давление обязательно";
        public const string DiastolicBloodPressureEmptyMessage = "Диастолическое артериальное давление обязательно";
        public const string AmbulanceDrugsNumberEmptyMessage =
            "Количество принятых препаратов скорой помощи за последние 12 часов обязательно";
        public const string PulseEmptyMessage = "Пульс обязателен";
        public const string DateEmptyMessage = "Дата записи обязательна";
        public const string IsMorningEmptyMessage =
            "Параметр отражающий являются ли показатели показателями на утро обязателен";

        public DiaryAddRecordCommandValidator()
        {
            RuleFor(x => x.SystolicBloodPressure).NotNull().WithMessage(SystolicBloodPressureEmptyMessage);
            RuleFor(x => x.DiastolicBloodPressure).NotNull().WithMessage(DiastolicBloodPressureEmptyMessage);
            RuleFor(x => x.AmbulanceDrugsNumber).NotNull().WithMessage(AmbulanceDrugsNumberEmptyMessage);
            RuleFor(x => x.Pulse).NotNull().WithMessage(PulseEmptyMessage);
            RuleFor(x => x.Date).NotNull().WithMessage(DateEmptyMessage);
            RuleFor(x => x.IsMorning).NotNull().WithMessage(IsMorningEmptyMessage);
        }
    }
}