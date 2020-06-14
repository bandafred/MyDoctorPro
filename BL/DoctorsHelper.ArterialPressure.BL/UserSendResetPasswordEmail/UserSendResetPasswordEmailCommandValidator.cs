using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace DoctorsHelper.ArterialPressure.BL.UserSendResetPasswordEmail
{
    /// <summary>
    /// Валидатор для <see cref="UserSendResetPasswordEmailCommand"/>
    /// </summary>
    public class UserSendResetPasswordEmailCommandValidator : AbstractValidator<UserSendResetPasswordEmailCommand>
    {
        public const string EmailEmptyMessage = "Email обязателен";
        public const string EmailIncorrectMessage = "Некорректно указан Email";
        public UserSendResetPasswordEmailCommandValidator()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty()
                .WithMessage(EmailEmptyMessage);

            RuleFor(x => x.Email).Must(x => new EmailAddressAttribute().IsValid(x))
                .WithMessage(EmailIncorrectMessage);
        }
    }
}