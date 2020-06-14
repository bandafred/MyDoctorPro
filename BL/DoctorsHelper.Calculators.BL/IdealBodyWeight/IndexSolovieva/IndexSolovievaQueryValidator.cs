using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.IndexSolovieva
{
    /// <summary>
    /// Валидация для Индекса Соловьева.
    /// </summary>
    public class IndexSolovievaQueryValidator : AbstractValidator<IndexSolovievaQuery>
    {
        public const string WristLengthIncorrectMessage = "Данные объема запястья указаны не верно, необходимо задать число не меньше 3 и не больше 500";

        public IndexSolovievaQueryValidator()
        {
            RuleFor(x => x.WristLength).Must(x => x > 3 && x < 500)
                .WithMessage(WristLengthIncorrectMessage);
        }
    }
}
