using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.MochammedFormula
{
    /// <summary>
    /// Валидатор для <see cref="MochammedFormulaQuery"/>
    /// </summary>
    public class MochammedFormulaQueryValidator : AbstractValidator<MochammedFormulaQuery>
    {
        public const string HeightIncorrectMessage = "Данные роста указаны не верно, необходимо задать число от 100 до 350";
        public MochammedFormulaQueryValidator()
        {
            RuleFor(x => x.Height).Must(x => x > 100 && x < 350)
                .WithMessage(HeightIncorrectMessage);
        }
    }
}