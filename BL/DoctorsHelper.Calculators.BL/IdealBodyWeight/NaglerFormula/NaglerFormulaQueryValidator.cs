using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.NaglerFormula
{
    /// <summary>
    /// Валидатор для <see cref="NaglerFormulaQuery"/>
    /// </summary>
    public class NaglerFormulaQueryValidator : AbstractValidator<NaglerFormulaQuery>
    {
        public const string HeightIncorrectMessage = "Данные роста указаны не верно, необходимо задать число от 140 до 350";
        public NaglerFormulaQueryValidator()
        {
            RuleFor(x => x.Height).Must(x => x > 140 && x < 350)
                .WithMessage(HeightIncorrectMessage);
        }
    }
}