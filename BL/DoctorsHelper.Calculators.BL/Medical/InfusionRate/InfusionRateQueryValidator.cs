using FluentValidation;

namespace DoctorsHelper.Calculators.BL.Medical.InfusionRate
{
    /// <summary>
    /// Валидация для расчета скорости инфузии.
    /// </summary>
    public class InfusionRateQueryValidator : AbstractValidator<InfusionRateQuery>
    {
        public const string BodyMassIncorrectMessage =
            "Данные массы тела указаны не верно, необходимо задать число не меньше 1 и не больше 999";
        public const string AmountDrugIncorrectMessage =
            "Данные количества препарата указаны не верно, необходимо задать число не меньше 1 и не больше 999";
        public const string DoseIncorrectMessage =
            "Данные дозы препарата указаны не верно, необходимо задать число не меньше 1 и не больше 999";
        public const string VolumeSolutionIncorrectMessage =
            "Данные объема раствора указаны не верно, необходимо задать число не меньше 1 и не больше 999";

        public InfusionRateQueryValidator()
        {
            RuleFor(x => x.BodyMass).Must(x => x >= 1 && x <= 999)
                .WithMessage(BodyMassIncorrectMessage);
            RuleFor(x => x.AmountDrug).Must(x => x >= 1 && x <= 999)
                .WithMessage(AmountDrugIncorrectMessage);
            RuleFor(x => x.Dose).Must(x => x >= 1 && x <= 999)
                .WithMessage(DoseIncorrectMessage);
            RuleFor(x => x.VolumeSolution).Must(x => x >= 1 && x <= 999)
                .WithMessage(VolumeSolutionIncorrectMessage);
        }
    }
}
