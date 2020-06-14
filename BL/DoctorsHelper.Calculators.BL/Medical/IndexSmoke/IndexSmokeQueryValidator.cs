using FluentValidation;

namespace DoctorsHelper.Calculators.BL.Medical.IndexSmoke
{
    /// <summary>
    /// Валидация для индекса курения.
    /// </summary>
    public class IndexSmokeQueryValidator : AbstractValidator<IndexSmokeQuery>
    {
        public const string AgeSmokeIncorrectMessage =
            "Данные стажа курения указаны не верно, необходимо задать число не меньше 1 и не больше 150";
        public const string CountSigarIncorrectMessage =
            "Данные о количестве сигарет указаны не верно, необходимо задать число не меньше 1 и не больше 999";

        public IndexSmokeQueryValidator()
        {
            RuleFor(x => x.AgeSmoke).Must(x => x >= 1 && x <= 150)
                .WithMessage(AgeSmokeIncorrectMessage);
            RuleFor(x => x.CountSigar).Must(x => x >= 1 && x <= 999)
                .WithMessage(CountSigarIncorrectMessage);
        }
    }
}
