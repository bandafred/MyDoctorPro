using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.HamviFormula
{
    /// <summary>
    /// Валидатор для <see cref="HamviFormulaQuery"/>
    /// </summary>
    public class HamviFormulaQueryValidator : AbstractValidator<HamviFormulaQuery>
    {
        public const string HeightIncorrectMessage = "Данные роста указаны не верно, необходимо задать число от 140 до 350";
        public HamviFormulaQueryValidator()
        {
            RuleFor(x => x.Height).Must(x => x > 140 && x < 350)
                .WithMessage(HeightIncorrectMessage);
        }
    }
}