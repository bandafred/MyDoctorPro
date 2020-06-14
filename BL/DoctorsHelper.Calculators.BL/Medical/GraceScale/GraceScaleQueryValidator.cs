using FluentValidation;

namespace DoctorsHelper.Calculators.BL.Medical.GraceScale
{
    /// <summary>
    /// Валидация для шкалы GRACE.
    /// </summary>
    public class GraceScaleQueryValidator : AbstractValidator<GraceScaleQuery>
    {
        public const string AgeIncorrectMessage =
            "Данные возраста указаны не верно, необходимо задать число не меньше 1 и не больше 150";
        public const string HeartRateIncorrectMessage =
            "Данные ЧСС указаны не верно, необходимо задать число не меньше 1 и не больше 150";
        public const string SystolicBloodPressureIncorrectMessage =
            "Данные систолического(верхнего) артериального давления указаны не верно, необходимо задать число не меньше 1 и не больше 300";
        public const string CreatininIncorrectMessage =
            "Данные объема креатинина указаны не верно, необходимо задать число не меньше 1 и не больше 150";

        public GraceScaleQueryValidator()
        {
            RuleFor(x => x.Age).Must(x => x >= 1 && x <= 150).WithMessage(AgeIncorrectMessage);
            RuleFor(x => x.HeartRate).Must(x => x >= 1 && x <= 150).WithMessage(HeartRateIncorrectMessage);
            RuleFor(x => x.SystolicBloodPressure).Must(x => x >= 1 && x <= 300).WithMessage(SystolicBloodPressureIncorrectMessage);
            RuleFor(x => x.Creatinin).Must(x => x >= 1 && x <= 150).WithMessage(CreatininIncorrectMessage);
        }
    }
}