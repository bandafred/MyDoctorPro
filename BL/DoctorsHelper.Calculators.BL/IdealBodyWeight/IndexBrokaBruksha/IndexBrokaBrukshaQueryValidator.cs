using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.IndexBrokaBruksha
{
    /// <summary>
    /// Валидатор для <see cref="IndexBrokaBrukshaQuery"/>
    /// </summary>
    public class IndexBrokaBrukshaQueryValidator : AbstractValidator<IndexBrokaBrukshaQuery>
    {
        public const string HeightIncorrectMessage = "Данные роста указаны не верно, необходимо задать число от 120 до 350";
        public IndexBrokaBrukshaQueryValidator()
        {
            RuleFor(x => x.Height).Must(x => x > 120 && x < 350)
                .WithMessage(HeightIncorrectMessage);
        }
    }
}