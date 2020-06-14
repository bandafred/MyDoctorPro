using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.MonnerotFormula
{
    /// <summary>
    /// Валидатор для <see cref="MonnerotFormulaQuery"/>
    /// </summary>
    public class MonnerotFormulaQueryValidator : AbstractValidator<MonnerotFormulaQuery>
    {
        public const string HeightIncorrectMessage = "Данные роста указаны не верно, необходимо задать число от 100 до 350";
        public const string WristLengthIncorrectMessage = "Данные объема запястья указаны не верно, необходимо задать число не меньше 3 и не больше 50";

        public MonnerotFormulaQueryValidator()
        {
            RuleFor(x => x.Height).Must(x => x > 140 && x < 350)
                .WithMessage(HeightIncorrectMessage);
            RuleFor(x => x.WristLength).Must(x => x > 3 && x < 50)
                .WithMessage(WristLengthIncorrectMessage);
        }
    }
}