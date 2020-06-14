using System;
using System.Threading.Tasks;
using System.Web;
using DoctorsHelper.ArterialPressure.Data;
using DoctorsHelper.ArterialPressure.Data.EFCore;
using DoctorsHelper.BL.Core.Exceptions;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace DoctorsHelper.ArterialPressure.BL.UserSendResetPasswordEmail
{
    public class
        UserSendResetPasswordEmailHandler : ICommandHandler<UserSendResetPasswordEmailCommand,
            UserSendResetPasswordEmailResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailSender _emailSender;
        private ArterialPressureContext _arterialPressureContext;


        public UserSendResetPasswordEmailHandler(UserManager<User> userManager, IEmailSender emailSender,
            ArterialPressureContext arterialPressureContext)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _arterialPressureContext = arterialPressureContext;
        }

        public async Task<UserSendResetPasswordEmailResponse> Handle(UserSendResetPasswordEmailCommand input)
        {
            await new UserSendResetPasswordEmailCommandValidator().ValidateAndThrowAsync(input);

            var user = await _userManager.FindByEmailAsync(input.Email);

            if (user == null)
                throw new NotFoundException("Пользователь с таким Email не найден");

            var passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            var token = new UserResetPasswordToken
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.Id,
                Token = passwordResetToken,
                ValidTo = DateTime.Now + TimeSpan.FromDays(1)
            };
            
            await _arterialPressureContext.UserResetPasswordTokens.AddAsync(token);
            await _arterialPressureContext.SaveChangesAsync();

            //TODO: Подумать. Возможно не стоит дожидаться отправки письма
            var url = HttpUtility.HtmlEncode($"{input.ChangePasswordUrl}{token.Id}");
            await _emailSender.SendEmailAsync(input.Email, "Смена пароля",
                $"Чтобы сменить пароль перейдите по ссылке: <a href='{url}'>link</a>");

            return new UserSendResetPasswordEmailResponse();
        }
    }
}