using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.CuperFormula
{
    /// <summary>
    /// Валидатор для <see cref="CuperFormulaQuery"/>
    /// </summary>
    public class CuperFormulaQueryValidator : AbstractValidator<CuperFormulaQuery>
    {
        public const string HeightIncorrectMessage = "Данные роста указаны не верно, необходимо задать число от 120 до 300";
        public CuperFormulaQueryValidator()
        {
            RuleFor(x => x.Height).Must(x => x > 120 && x < 300)
                .WithMessage(HeightIncorrectMessage);
        }
    }
}