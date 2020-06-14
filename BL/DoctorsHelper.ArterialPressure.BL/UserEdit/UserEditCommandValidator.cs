using FluentValidation;

namespace DoctorsHelper.ArterialPressure.BL.UserEdit
{
    /// <summary>
    /// Валидатор для <see cref="UserEditCommand"/>
    /// </summary>
    public class UserEditCommandValidator : AbstractValidator<UserEditCommand>
    {
        public const string BirthDateEmptyMessage = "Дата рождения обязательна";
        public const string IsMenEmptyMessage = "Пол обязателен";
        public UserEditCommandValidator()
        {
            RuleFor(x => x.BirthDate).NotNull()
                .WithMessage(BirthDateEmptyMessage);

            RuleFor(x => x.IsMen).NotNull()
                .WithMessage(IsMenEmptyMessage);
        }
    }
}