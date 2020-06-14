using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.EgorovaTable
{
    /// <summary>
    /// Валидатор для <see cref="EgorovaTableQuery"/>
    /// </summary>
    public class EgorovaTableQueryValidator : AbstractValidator<EgorovaTableQuery>
    {
        public const string HeightIncorrectMessage = "Данные роста указаны не верно, необходимо задать число от 148 до 190";
        public const string AgeIncorrectMessage = "Данные возраста указаны не верно, необходимо задать число от 20 до 69";
        public EgorovaTableQueryValidator()
        {
            RuleFor(x => x.Height).Must(x => x >= 148 && x <= 190)
                .WithMessage(HeightIncorrectMessage); 
            RuleFor(x => x.Age).Must(x => x >= 20 && x <= 69)
                .WithMessage(AgeIncorrectMessage);
        }
    }
}