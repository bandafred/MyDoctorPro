using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DoctorsHelper.ArterialPressure.Data;
using DoctorsHelper.BL.Core.Exceptions;
using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DoctorsHelper.ArterialPressure.BL.UserEdit
{
    public class UserEditHandler : ICommandHandler<UserEditCommand, UserEditResponse>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserEditHandler(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserEditResponse> Handle(UserEditCommand input)
        {
            await new UserEditCommandValidator().ValidateAndThrowAsync(input);

            var tokenString = _httpContextAccessor.HttpContext.GetJwtToken();
            var user = await _userManager.Users.FirstOrDefaultAsync(u =>
                u.UserJwtTokens.Any(jwtToken => jwtToken.Token == tokenString));
            if(user == null)
                throw new NotFoundException("Пользователь не найден");

            user = _mapper.Map(input,user);

            await _userManager.UpdateAsync(user);

            return new UserEditResponse();
        }
    }
}