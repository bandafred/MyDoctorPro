using FluentValidation;

namespace DoctorsHelper.Calculators.BL.Medical.AntihypertensiveTherapy
{
    /// <summary>
    /// Валидация для подбора гипотензивной терапии.
    /// </summary>
    public class AntihypertensiveTherapyQueryValidator : AbstractValidator<AntihypertensiveTherapyQuery>
    {
        public const string AgeIncorrectMessage =
            "Данные возраста указаны не верно, необходимо задать число не меньше 1 и не больше 150";
        public const string DiastolicBloodPressureIncorrectMessage =
            "Данные нижнего АД указаны не верно, необходимо задать число не меньше 1 и не больше 350";
        public const string SystolicBloodPressureIncorrectMessage =
            "Данные верхнего АД указаны не верно, необходимо задать число не меньше 1 и не больше 350";
        public const string PulseIncorrectMessage =
            "Данные пульса указаны не верно, необходимо задать число не меньше 1 и не больше 350";

        public AntihypertensiveTherapyQueryValidator()
        {
            RuleFor(x => x.Age).Must(x => x >= 1 && x < 150)
                .WithMessage(AgeIncorrectMessage);
            RuleFor(x => x.DiastolicBloodPressure).Must(x => x >= 1 && x < 350)
                .WithMessage(DiastolicBloodPressureIncorrectMessage);
            RuleFor(x => x.SystolicBloodPressure).Must(x => x >= 1 && x < 350)
                .WithMessage(SystolicBloodPressureIncorrectMessage);
            RuleFor(x => x.Pulse).Must(x => x >= 1 && x < 350)
                .WithMessage(PulseIncorrectMessage);
        }
    }
}
