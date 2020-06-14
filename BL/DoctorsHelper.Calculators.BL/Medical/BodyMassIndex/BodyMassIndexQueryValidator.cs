using FluentValidation;

namespace DoctorsHelper.Calculators.BL.Medical.BodyMassIndex
{
    /// <summary>
    /// Валидация для ИМТ.
    /// </summary>
    public class BodyMassIndexQueryValidator : AbstractValidator<BodyMassIndexQuery>
    {
        public const string HeightIncorrectMessage =
            "Данные объема роста указаны не верно, необходимо задать число не меньше 140 и не больше 350";
        public const string WeightIncorrectMessage =
            "Данные объема веса указаны не верно, необходимо задать число не меньше 30 и не больше 500";

        public BodyMassIndexQueryValidator()
        {
            RuleFor(x => x.Height).Must(x => x > 140 && x < 350)
                .WithMessage(HeightIncorrectMessage);
            RuleFor(x => x.Weight).Must(x => x > 30 && x < 500)
                .WithMessage(WeightIncorrectMessage);
        }
    }
}
