using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.ArterialPressure.BL.UserResetPassword
{
    /// <summary> Команда для сброса пароля </summary>
    public class UserResetPasswordCommand : ICommand<UserResetPasswordResponse>
    {
        /// <summary> Токен </summary>
        public string ResetPasswordToken { get; set; }

        /// <summary> Новый пароль </summary>
        public string NewPassword { get; set; }
    }
}