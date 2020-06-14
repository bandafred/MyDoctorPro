using System;
using System.Security.Authentication;
using System.Threading.Tasks;
using DoctorsHelper.ArterialPressure.BL.Jwt;
using DoctorsHelper.ArterialPressure.Data;
using DoctorsHelper.ArterialPressure.Data.EFCore;
using DoctorsHelper.BL.Core.Exceptions;
using DoctorsHelper.BL.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DoctorsHelper.ArterialPressure.BL.UserLogin
{
    public class UserLoginHandler : ICommandHandler<UserLoginCommand, UserLoginResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtGetTokenStringForUserHandler _jwtGetTokenStringForUserHandler;
        private readonly ArterialPressureContext _arterialPressureContext;

        public UserLoginHandler(UserManager<User> userManager,
            JwtGetTokenStringForUserHandler jwtGetTokenStringForUserHandler,
            ArterialPressureContext arterialPressureContext)
        {
            _userManager = userManager;
            _jwtGetTokenStringForUserHandler = jwtGetTokenStringForUserHandler;
            _arterialPressureContext = arterialPressureContext;
        }

        public async Task<UserLoginResponse> Handle(UserLoginCommand input)
        {
            var user = await _userManager.FindByEmailAsync(input.Email);

            //Возвращаем одинаковые ошибки, избегаем подбора
            if (user == null)
                throw new AuthenticationException("Неверный email или пароль");

            var isPasswordOk = await _userManager.CheckPasswordAsync(user, input.Password);

            if (!isPasswordOk)
            {
                var identityResult = await _userManager.AccessFailedAsync(user);
                throw !identityResult.Succeeded
                    ? (Exception)new IdentityResultException(identityResult)
                    : new AuthenticationException("Неверный email или пароль");
            }

            var tokenString = await _jwtGetTokenStringForUserHandler.Handle(user);

            await _arterialPressureContext.UserJwtTokens.AddAsync(new UserJwtToken
            {
                UserId = user.Id,
                Token = tokenString,
                ExpirationDateTime = input.RememberMe ? (DateTime?) null : DateTime.Now.AddDays(1)
            });
            await _arterialPressureContext.SaveChangesAsync();

            return new UserLoginResponse { Token = tokenString, EmailConfirmed = user.EmailConfirmed};
        }
    }
}