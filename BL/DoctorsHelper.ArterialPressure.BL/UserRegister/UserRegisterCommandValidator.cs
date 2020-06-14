using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace DoctorsHelper.ArterialPressure.BL.UserRegister
{
    /// <summary>
    /// Валидатор для <see cref="UserRegisterCommand"/>
    /// </summary>
    public class UserRegisterCommandValidator : AbstractValidator<UserRegisterCommand>
    {
        public const string PasswordEmptyMessage = "Пароль обязателен";
        public const string BirthDateEmptyMessage = "Дата рождения обязательна";
        public const string IsMenEmptyMessage = "Пол обязателен";
        public const string EmailEmptyMessage = "Email обязателен";
        public const string EmailIncorrectMessage = "Некорректно указан Email";
        public UserRegisterCommandValidator()
        {
            RuleFor(x => x.Password).NotNull()
                .WithMessage(PasswordEmptyMessage);

            RuleFor(x => x.BirthDate).NotNull()
                .WithMessage(BirthDateEmptyMessage);

            RuleFor(x => x.IsMen).NotNull()
                .WithMessage(IsMenEmptyMessage);

            RuleFor(x => x.Email).NotNull().NotEmpty()
                .WithMessage(EmailEmptyMessage);

            RuleFor(x => x.Email).Must(x => new EmailAddressAttribute().IsValid(x))
                .WithMessage(EmailIncorrectMessage);
        }
    }
}