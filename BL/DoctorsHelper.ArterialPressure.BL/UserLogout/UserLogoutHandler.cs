using System.Threading.Tasks;
using DoctorsHelper.ArterialPressure.Data.EFCore;
using DoctorsHelper.BL.Core.Exceptions;
using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.BL.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DoctorsHelper.ArterialPressure.BL.UserLogout
{
    public class UserLogoutHandler : ICommandHandler<UserLogoutCommand, UserLogoutResponse>
    {
        private readonly ArterialPressureContext _arterialPressureContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserLogoutHandler(ArterialPressureContext arterialPressureContext, IHttpContextAccessor httpContextAccessor)
        {
            _arterialPressureContext = arterialPressureContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserLogoutResponse> Handle(UserLogoutCommand input)
        {
            var tokenString = _httpContextAccessor.HttpContext.GetJwtToken();
            var token = await _arterialPressureContext.UserJwtTokens.FirstOrDefaultAsync(t => t.Token == tokenString);
            if(token == null)
                throw new NotFoundException("Такого токена не существует");

            _arterialPressureContext.UserJwtTokens.Remove(token);
            await _arterialPressureContext.SaveChangesAsync();

            return new UserLogoutResponse();
        }
    }
}