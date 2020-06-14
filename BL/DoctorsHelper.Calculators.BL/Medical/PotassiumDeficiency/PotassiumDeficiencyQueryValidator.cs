using FluentValidation;

namespace DoctorsHelper.Calculators.BL.Medical.PotassiumDeficiency
{
    /// <summary>
    /// Валидация для расчета дефицита калия в плазме крови.
    /// </summary>
    public class PotassiumDeficiencyQueryValidator : AbstractValidator<PotassiumDeficiencyQuery>
    {
        public const string KaliiIncorrectMessage =
            "Данные объема калия указаны не верно, необходимо задать число не меньше 1 и не больше 999";
        public const string BodyMassIncorrectMessage =
            "Данные массы тела указаны не верно, необходимо задать число не меньше 1 и не больше 999";

        public PotassiumDeficiencyQueryValidator()
        {
            RuleFor(x => x.BloodKaliumLevel).Must(x => x > 1 && x < 999)
                .WithMessage(KaliiIncorrectMessage);
            RuleFor(x => x.BodyMass).Must(x => x > 1 && x < 999)
                .WithMessage(BodyMassIncorrectMessage);
        }
    }
}
