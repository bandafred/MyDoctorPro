using FluentValidation;

namespace DoctorsHelper.Calculators.BL.Medical.GlomerularFiltrationRate
{
    /// <summary>
    /// Валидация для расчета скорости клубочковой фильтрации.
    /// </summary>
    public class GlomerularFiltrationRateQueryValidator : AbstractValidator<GlomerularFiltrationRateQuery>
    {
        public const string HeightIncorrectMessage =
            "Данные роста указаны не верно, необходимо задать число не меньше 100 и не больше 999";
        public const string AgeIncorrectMessage =
            "Данные возраста указаны не верно, необходимо задать число не меньше 1 и не больше 150";
        public const string CreatininIncorrectMessage =
            "Данные креатинина указаны не верно, необходимо задать число не меньше 1 и не больше 999";
        public const string WeightIncorrectMessage =
            "Данные веса указаны не верно, необходимо задать число не меньше 1 и не больше 500";

        public GlomerularFiltrationRateQueryValidator()
        {
            RuleFor(x => x.Height).Must(x => x >= 100 && x < 999)
                .WithMessage(HeightIncorrectMessage);
            RuleFor(x => x.Age).Must(x => x >= 1 && x < 150)
                .WithMessage(AgeIncorrectMessage);
            RuleFor(x => x.Creatinin).Must(x => x > 1 && x < 999)
                .WithMessage(CreatininIncorrectMessage);
            RuleFor(x => x.Weight).Must(x => x >= 1 && x < 500)
                .WithMessage(WeightIncorrectMessage);
        }
    }
}
