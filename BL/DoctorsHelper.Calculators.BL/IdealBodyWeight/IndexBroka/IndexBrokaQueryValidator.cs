using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.IndexBroka
{
    /// <summary>
    /// Валидатор для <see cref="IndexBrokaQuery"/>
    /// </summary>
    public class IndexBrokaQueryValidator : AbstractValidator<IndexBrokaQuery>
    {
        public const string HeightIncorrectMessage = "Данные роста указаны не верно, необходимо задать число от 155 до 185";
        public IndexBrokaQueryValidator()
        {
            RuleFor(x => x.Height).Must(x => x > 155 && x < 185)
                .WithMessage(HeightIncorrectMessage);
        }
    }
}