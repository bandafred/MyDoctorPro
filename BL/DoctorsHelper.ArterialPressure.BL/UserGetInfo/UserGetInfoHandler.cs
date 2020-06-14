using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DoctorsHelper.ArterialPressure.Data;
using DoctorsHelper.BL.Core.Exceptions;
using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.BL.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DoctorsHelper.ArterialPressure.BL.UserGetInfo
{
    public class UserGetInfoHandler : ICommandHandler<UserGetInfoCommand, UserGetInfoResponse>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserGetInfoHandler(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserGetInfoResponse> Handle(UserGetInfoCommand input)
        {
            var tokenString = _httpContextAccessor.HttpContext.GetJwtToken();

            var user = await _userManager.Users.FirstOrDefaultAsync(u =>
                u.UserJwtTokens.Any(jwtToken => jwtToken.Token == tokenString));
            if(user == null)
                throw new NotFoundException("Пользователь не найден");

            var response = _mapper.Map<UserGetInfoResponse>(user);

            return response;
        }
    }
}