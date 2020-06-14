using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.KreffFormula
{
    /// <summary>
    /// Валидатор для <see cref="KreffFormulaQuery"/>
    /// </summary>
    public class KreffFormulaQueryValidator : AbstractValidator<KreffFormulaQuery>
    {
        public const string HeightIncorrectMessage = "Данные роста указаны не верно, необходимо задать число от 110 до 220";
        public const string AgeIncorrectMessage = "Данные возраста указаны не верно, необходимо задать число от 18 до 300";
        public const string LenСarpusIncorrectMessage = "Данные объема запястья указаны не верно, необходимо задать число от 3 до 50";

        public KreffFormulaQueryValidator()
        {
            RuleFor(x => x.Height).Must(x => x > 110 && x < 220)
                .WithMessage(HeightIncorrectMessage);

            RuleFor(x => x.Age).Must(x => x > 18 && x < 300)
                .WithMessage(AgeIncorrectMessage);
            
            RuleFor(x => x.LenСarpus).Must(x => x > 3 && x < 50)
                .WithMessage(LenСarpusIncorrectMessage);
        }
    }
}