using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DoctorsHelper.ArterialPressure.BL.Jwt;
using DoctorsHelper.ArterialPressure.BL.UserConfirmEmail;
using DoctorsHelper.ArterialPressure.Data;
using DoctorsHelper.BL.Core.Exceptions;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.ArterialPressure.BL.UserRegister
{
    public class UserRegisterHandler : ICommandHandler<UserRegisterCommand, UserRegisterResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly IUrlHelper _urlHelper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly JwtGetTokenStringForUserHandler _jwtGetTokenStringForUserHandler;


        public UserRegisterHandler(
            UserManager<User> userManager,
            IMapper mapper,
            IEmailSender emailSender,
            IUrlHelper urlHelper,
            IHttpContextAccessor httpContextAccessor,
            JwtGetTokenStringForUserHandler jwtGetTokenStringForUserHandler)
        {
            _userManager = userManager;
            _mapper = mapper;
            _emailSender = emailSender;
            _urlHelper = urlHelper;
            _httpContextAccessor = httpContextAccessor;
            _jwtGetTokenStringForUserHandler = jwtGetTokenStringForUserHandler;
        }

        public async Task<UserRegisterResponse> Handle(UserRegisterCommand input)
        {
            await new UserRegisterCommandValidator().ValidateAndThrowAsync(input);

            var user = _mapper.Map<User>(input);

            if (string.IsNullOrEmpty(user.UserName))
                user.UserName = new string(user.Email.TakeWhile(c => c != '@').ToArray());

            var identityResult = await _userManager.CreateAsync(user,input.Password);

            if (!identityResult.Succeeded)
                throw new IdentityResultException(identityResult);

            var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var callbackUrl = _urlHelper.Action(
                "ConfirmEmail",
                "User",
                new UserConfirmEmailCommand { UserId = user.Id, ConfirmationToken = confirmationToken },
                protocol: _httpContextAccessor.HttpContext.Request.Scheme);

            //TODO: Подумать. Возможно не стоит дожидаться отправки письма
            await _emailSender.SendEmailAsync(input.Email, "Подтвердите регистрацию",
                $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>link</a>");

            var tokenString = await _jwtGetTokenStringForUserHandler.Handle(user);

            user.UserJwtTokens = new List<UserJwtToken>
            {
                new UserJwtToken {Token = tokenString, ExpirationDateTime = DateTime.UtcNow.AddDays(1)}
            };
            await _userManager.UpdateAsync(user);

            return new UserRegisterResponse { Token = tokenString };
        }
    }
}
