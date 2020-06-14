using System;
using System.Threading.Tasks;
using DoctorsHelper.ArterialPressure.Data;
using DoctorsHelper.ArterialPressure.Data.EFCore;
using DoctorsHelper.BL.Core.Exceptions;
using DoctorsHelper.BL.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DoctorsHelper.ArterialPressure.BL.UserResetPassword
{
    public class UserResetPasswordHandler : ICommandHandler<UserResetPasswordCommand, UserResetPasswordResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly ArterialPressureContext _arterialPressureContext;

        public UserResetPasswordHandler(ArterialPressureContext arterialPressureContext, UserManager<User> userManager)
        {
            _arterialPressureContext = arterialPressureContext;
            _userManager = userManager;
        }

        public async Task<UserResetPasswordResponse> Handle(UserResetPasswordCommand input)
        {
            var token = await _arterialPressureContext.UserResetPasswordTokens.FirstOrDefaultAsync(token =>
                token.Id == input.ResetPasswordToken);

            if (token == null)
                throw new NotFoundException("Такого токена не существует");
            if (token.ValidTo < DateTime.Now)
                throw new NotFoundException("Токен истек");

            var user = await _userManager.FindByIdAsync(token.UserId);

            if (user == null)
                throw new NotFoundException("Такого пользователя не существует");

            var identityResult = await _userManager.ResetPasswordAsync(user, token.Token, input.NewPassword);

            if(!identityResult.Succeeded)
                throw new IdentityResultException(identityResult);

            return new UserResetPasswordResponse();
        }
    }
}