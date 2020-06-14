using FluentValidation;

namespace DoctorsHelper.Calculators.BL.Medical.CorrectedQTCalculation
{
    /// <summary>
    /// Валидация для расчета корригированного QT.
    /// </summary>
    public class CorrectedQTCalculationQueryValidator : AbstractValidator<CorrectedQTCalculationQuery>
    {
        public const string HeartRateIncorrectMessage =
            "Данные частоты сердечных сокращений указаны не верно, необходимо задать число не меньше 1 и не больше 999";
        public const string IntervalQTIncorrectMessage =
            "Данные интервала QT указаны не верно, необходимо задать число не меньше 1 и не больше 999";

        public CorrectedQTCalculationQueryValidator()
        {
            RuleFor(x => x.HeartRate).Must(x => x > 1 && x < 999)
                .WithMessage(HeartRateIncorrectMessage);
            RuleFor(x => x.IntervalQT).Must(x => x > 1 && x < 999)
                .WithMessage(IntervalQTIncorrectMessage);
        }
    }
}
