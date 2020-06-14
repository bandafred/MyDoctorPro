using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorsHelper.ArterialPressure.Data;
using DoctorsHelper.BL.Core.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace DoctorsHelper.API.Initialization.ConfigureServices
{
    public static class JwtConfiguration
    {
        /// <summary>
        /// Добавление настройки на Jwt
        /// </summary>
        public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            // configure jwt authentication
            var key = Encoding.ASCII.GetBytes(configuration["JwtSecurityTokenSettings:Secret"]);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.Events = new JwtBearerEvents
                    {
                        OnChallenge = context =>
                        {
                            if (string.IsNullOrEmpty(context.Error))
                                return Task.CompletedTask;
                            if (context.Error == "invalid_token")
                                throw new AuthorizationException("Некорректный токен");
                            throw new AuthorizationException(context.Error);
                        },
                        OnForbidden = context => throw new AuthorizationException("Нет доступа"),
                        OnTokenValidated = context =>
                        {
                            var userService =
                                context.HttpContext.RequestServices.GetRequiredService<UserManager<User>>();
                            var userId = context.Principal.Identity.Name;
                            var user = userService.Users.Include(u => u.UserJwtTokens)
                                .FirstOrDefaultAsync(u => u.Id == userId).Result;
                            if (user == null)
                                throw new AuthorizationException("Нет такого пользователя");

                            var jwtSecurityStamp =
                                context.Principal.Claims.FirstOrDefault(claim =>
                                    claim.Type == nameof(User.SecurityStamp));
                            if (jwtSecurityStamp == null)
                                throw new AuthorizationException("Некорректный токен");

                            var securityStamp = user.SecurityStamp;
                            if (jwtSecurityStamp.Value != securityStamp)
                                throw new AuthorizationException("Необходимо обновить токен");

                            if (!(context.SecurityToken is JwtSecurityToken token))
                                throw new AuthorizationException("Токен пустой");

                            var userJwtToken = user.UserJwtTokens.FirstOrDefault(t => t.Token == token.RawData);
                            if (userJwtToken == null)
                                throw new AuthorizationException("Токен не зарегистрирован");

                            if (userJwtToken.ExpirationDateTime < DateTime.Now)
                                throw new AuthorizationException("Токен истек");

                            context.Success();
                            return Task.CompletedTask;
                        }
                    };
                    x.RequireHttpsMetadata = false;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                    };
                });

            return services;
        }
    }
}