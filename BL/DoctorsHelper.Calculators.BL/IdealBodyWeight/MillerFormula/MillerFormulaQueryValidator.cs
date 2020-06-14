using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.MillerFormula
{
    /// <summary>
    /// Валидатор для <see cref="MillerFormulaQuery"/>
    /// </summary>
    public class MillerFormulaQueryValidator : AbstractValidator<MillerFormulaQuery>
    {
        public const string HeightIncorrectMessage = "Данные роста указаны не верно, необходимо задать число от 100 до 350";
        public MillerFormulaQueryValidator()
        {
            RuleFor(x => x.Height).Must(x => x > 100 && x < 350)
                .WithMessage(HeightIncorrectMessage);
        }
    }
}