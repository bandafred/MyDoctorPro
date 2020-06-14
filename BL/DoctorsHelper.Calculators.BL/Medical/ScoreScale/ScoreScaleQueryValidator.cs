using FluentValidation;

namespace DoctorsHelper.Calculators.BL.Medical.ScoreScale
{
    /// <summary>
    /// Валидация для шкалы SCORE.
    /// </summary>
    public class ScoreScaleQueryValidator : AbstractValidator<ScoreScaleQuery>
    {
        public const string AgeIncorrectMessage =
            "Данные возраста указаны не верно, необходимо задать число не меньше 1 и не больше 150";
        public const string UpperBloodPressureIncorrectMessage =
            "Данные уровня верхнего АД указаны не верно, необходимо задать число не меньше 60 и не больше 300";
        public const string PlasmaCholesterolIncorrectMessage =
            "Данные уровня холестерина плазмы указаны не верно, необходимо задать число не меньше 1 и не больше 30";

        public ScoreScaleQueryValidator()
        {
            RuleFor(x => x.Age).Must(x => x > 1 && x < 150)
                .WithMessage(AgeIncorrectMessage);
            RuleFor(x => x.UpperBloodPressure).Must(x => x > 60 && x < 300)
                .WithMessage(UpperBloodPressureIncorrectMessage);
            RuleFor(x => x.PlasmaCholesterol).Must(x => x > 1 && x < 30)
                .WithMessage(PlasmaCholesterolIncorrectMessage);
        }
    }
}
