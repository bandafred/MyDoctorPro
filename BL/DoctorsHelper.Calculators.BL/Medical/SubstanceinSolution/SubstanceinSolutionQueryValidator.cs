using FluentValidation;

namespace DoctorsHelper.Calculators.BL.Medical.SubstanceinSolution
{
    /// <summary>
    /// Валидация для расчета содержания вещества в растворе (пересчет процентов в миллиграммы).
    /// </summary>
    public class SubstanceinSolutionQueryValidator : AbstractValidator<SubstanceinSolutionQuery>
    {
        public const string ProcentIncorrectMessage =
            "Данные процентов указаны не верно, необходимо задать число не меньше 1 и не больше 100";
        public const string VolumeIncorrectMessage =
            "Данные объема ампулы указаны не верно, необходимо задать число не меньше 1 и не больше 999";

        public SubstanceinSolutionQueryValidator()
        {
            RuleFor(x => x.Procent).Must(x => x >= 1 && x <= 100)
                .WithMessage(ProcentIncorrectMessage);
            RuleFor(x => x.Volume).Must(x => x >= 1 && x <= 999)
                .WithMessage(VolumeIncorrectMessage);
        }
    }
}
