using System.Threading.Tasks;
using DoctorsHelper.ArterialPressure.Data;
using DoctorsHelper.BL.Core.Exceptions;
using DoctorsHelper.BL.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DoctorsHelper.ArterialPressure.BL.UserConfirmEmail
{
    public class UserConfirmEmailHandler : ICommandHandler<UserConfirmEmailCommand, UserConfirmEmailResponse>
    {
        private readonly UserManager<User> _userManager;

        public UserConfirmEmailHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserConfirmEmailResponse> Handle(UserConfirmEmailCommand input)
        {
            var user = await _userManager.FindByIdAsync(input.UserId);

            if (user == null)
                throw new NotFoundException("Такого пользователя не существует");

            var identityResult = await _userManager.ConfirmEmailAsync(user,input.ConfirmationToken);

            if(!identityResult.Succeeded)
                throw new IdentityResultException(identityResult);

            return new UserConfirmEmailResponse();
        }
    }
}
