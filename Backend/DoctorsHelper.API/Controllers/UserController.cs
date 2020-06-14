using System.Threading.Tasks;
using DoctorsHelper.ArterialPressure.BL.UserConfirmEmail;
using DoctorsHelper.ArterialPressure.BL.UserEdit;
using DoctorsHelper.ArterialPressure.BL.UserGetInfo;
using DoctorsHelper.ArterialPressure.BL.UserLogin;
using DoctorsHelper.ArterialPressure.BL.UserLogout;
using DoctorsHelper.ArterialPressure.BL.UserLogoutFromAllDevices;
using DoctorsHelper.ArterialPressure.BL.UserRegister;
using DoctorsHelper.ArterialPressure.BL.UserResetPassword;
using DoctorsHelper.ArterialPressure.BL.UserSendResetPasswordEmail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly UserRegisterHandler _userRegisterHandler;
        private readonly UserConfirmEmailHandler _userConfirmEmailHandler;
        private readonly UserLoginHandler _userLoginHandler;
        private readonly UserLogoutHandler _userLogoutHandler;
        private readonly UserLogoutFromAllDevicesHandler _userLogoutFromAllDevicesHandler;
        private readonly UserSendResetPasswordEmailHandler _userSendResetPasswordEmailHandler;
        private readonly UserResetPasswordHandler _userResetPasswordHandler;
        private readonly UserGetInfoHandler _userGetInfoHandler;
        private readonly UserEditHandler _userEditHandler;

        public UserController(
            UserRegisterHandler userRegisterHandler,
            UserConfirmEmailHandler userConfirmEmailHandler,
            UserLoginHandler userLoginHandler,
            UserLogoutHandler userLogoutHandler,
            UserLogoutFromAllDevicesHandler userLogoutFromAllDevicesHandler,
            UserSendResetPasswordEmailHandler sendResetPasswordEmailHandler,
            UserResetPasswordHandler userResetPasswordHandler,
            UserGetInfoHandler userGetInfoHandler,
            UserEditHandler userEditHandler)
        {
            _userRegisterHandler = userRegisterHandler;
            _userConfirmEmailHandler = userConfirmEmailHandler;
            _userLoginHandler = userLoginHandler;
            _userLogoutHandler = userLogoutHandler;
            _userLogoutFromAllDevicesHandler = userLogoutFromAllDevicesHandler;
            _userSendResetPasswordEmailHandler = sendResetPasswordEmailHandler;
            _userResetPasswordHandler = userResetPasswordHandler;
            _userGetInfoHandler = userGetInfoHandler;
            _userEditHandler = userEditHandler;
        }

        [HttpPost]
        public async Task<UserLoginResponse> Login(UserLoginCommand command)
        {
            return await _userLoginHandler.Handle(command);
        }

        [Authorize]
        [HttpPost]
        public async Task<UserLogoutResponse> Logout()
        {
            return await _userLogoutHandler.Handle(new UserLogoutCommand());
        }

        [Authorize]
        [HttpPost]
        public async Task<UserLogoutFromAllDevicesResponse> LogoutFromAllDevices()
        {
            return await _userLogoutFromAllDevicesHandler.Handle(new UserLogoutFromAllDevicesCommand());
        }

        [HttpPost]
        public async Task<UserRegisterResponse> Register(UserRegisterCommand command)
        {
            return await _userRegisterHandler.Handle(command);
        }

        [HttpGet]
        public async Task<UserConfirmEmailResponse> ConfirmEmail(UserConfirmEmailCommand command)
        {
            return await _userConfirmEmailHandler.Handle(command);
        }

        [HttpPost]
        public async Task<UserSendResetPasswordEmailResponse> SendResetPasswordEmail(UserSendResetPasswordEmailCommand command)
        {
            return await _userSendResetPasswordEmailHandler.Handle(command);
        }

        [HttpPost]
        public async Task<UserResetPasswordResponse> ResetPassword(UserResetPasswordCommand command)
        {
            return await _userResetPasswordHandler.Handle(command);
        }

        [Authorize]
        [HttpGet]
        public async Task<UserGetInfoResponse> GetInfo()
        {
            return await _userGetInfoHandler.Handle(new UserGetInfoCommand());
        }

        [Authorize]
        [HttpPost]
        public async Task<UserEditResponse> Edit(UserEditCommand command)
        {
            return await _userEditHandler.Handle(command);
        }
    }
}