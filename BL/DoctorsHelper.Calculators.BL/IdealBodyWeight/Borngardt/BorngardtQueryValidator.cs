using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.Borngardt
{
    /// <summary>
    /// Валидатор для <see cref="BorngardtQuery"/>
    /// </summary>
    public class BorngardtQueryValidator : AbstractValidator<BorngardtQuery>
    {
        public const string HeightIncorrectMessage = "Данные роста указаны не верно, необходимо задать число от 120 до 300";
        public const string ChestСircumferenceIncorrectMessage = "Данные обхвата груди указаны не верно, необходимо задать число от 30 до 400";
        public BorngardtQueryValidator()
        {
            RuleFor(x => x.Height).Must(x => x > 120 && x < 300)
                .WithMessage(HeightIncorrectMessage);
           
            RuleFor(x => x.ChestСircumference).Must(x => x > 30 && x < 400)
                .WithMessage(ChestСircumferenceIncorrectMessage);
        }
    }
}