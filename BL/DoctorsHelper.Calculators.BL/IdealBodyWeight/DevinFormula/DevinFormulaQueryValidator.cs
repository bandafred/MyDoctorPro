using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.DevinFormula
{
    /// <summary>
    /// Валидатор для <see cref="DevinFormulaQuery"/>
    /// </summary>
    public class DevinFormulaQueryValidator : AbstractValidator<DevinFormulaQuery>
    {
        public const string HeightIncorrectMessage = "Данные роста указаны не верно, необходимо задать число от 140 до 350";
        public DevinFormulaQueryValidator()
        {
            RuleFor(x => x.Height).Must(x => x > 140 && x < 350)
                .WithMessage(HeightIncorrectMessage);
        }
    }
}