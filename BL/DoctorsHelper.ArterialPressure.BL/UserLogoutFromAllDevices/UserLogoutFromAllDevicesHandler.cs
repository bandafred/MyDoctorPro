using System.Linq;
using System.Threading.Tasks;
using DoctorsHelper.ArterialPressure.Data.EFCore;
using DoctorsHelper.BL.Core.Exceptions;
using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.BL.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DoctorsHelper.ArterialPressure.BL.UserLogoutFromAllDevices
{
    public class UserLogoutFromAllDevicesHandler : ICommandHandler<UserLogoutFromAllDevicesCommand, UserLogoutFromAllDevicesResponse>
    {
        private readonly ArterialPressureContext _arterialPressureContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserLogoutFromAllDevicesHandler(ArterialPressureContext arterialPressureContext, IHttpContextAccessor httpContextAccessor)
        {
            _arterialPressureContext = arterialPressureContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserLogoutFromAllDevicesResponse> Handle(UserLogoutFromAllDevicesCommand input)
        {
            var tokenString = _httpContextAccessor.HttpContext.GetJwtToken();
            var token = await _arterialPressureContext.UserJwtTokens.FirstOrDefaultAsync(t => t.Token == tokenString);
            if(token == null)
                throw new NotFoundException("Такого токена не существует");

            var tokens = await _arterialPressureContext.UserJwtTokens.Where(t => t.UserId == token.UserId)
                .ToListAsync();

            _arterialPressureContext.UserJwtTokens.RemoveRange(tokens);
            await _arterialPressureContext.SaveChangesAsync();

            return new UserLogoutFromAllDevicesResponse();
        }
    }
}