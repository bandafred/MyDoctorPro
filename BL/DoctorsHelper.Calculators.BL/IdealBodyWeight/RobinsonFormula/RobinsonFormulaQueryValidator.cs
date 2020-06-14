using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.RobinsonFormula
{
    /// <summary>
    /// Валидатор для <see cref="RobinsonFormulaQuery"/>
    /// </summary>
    public class RobinsonFormulaQueryValidator : AbstractValidator<RobinsonFormulaQuery>
    {
        public const string HeightIncorrectMessage = "Данные роста указаны не верно, необходимо задать число от 140 до 220";
        public RobinsonFormulaQueryValidator()
        {
            RuleFor(x => x.Height).Must(x => x > 140 && x < 220)
                .WithMessage(HeightIncorrectMessage);
        }
    }
}