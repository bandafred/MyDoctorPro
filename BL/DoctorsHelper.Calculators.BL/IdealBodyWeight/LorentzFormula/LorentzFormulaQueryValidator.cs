using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.LorentzFormula
{
    /// <summary>
    /// Валидатор для <see cref="LorentzFormulaQuery"/>
    /// </summary>
    public class LorentzFormulaQueryValidator : AbstractValidator<LorentzFormulaQuery>
    {
        public const string HeightIncorrectMessage = "Данные роста указаны не верно, необходимо задать число от 140 до 220";
        public LorentzFormulaQueryValidator()
        {
            RuleFor(x => x.Height).Must(x => x > 140 && x < 220)
                .WithMessage(HeightIncorrectMessage);
        }
    }
}