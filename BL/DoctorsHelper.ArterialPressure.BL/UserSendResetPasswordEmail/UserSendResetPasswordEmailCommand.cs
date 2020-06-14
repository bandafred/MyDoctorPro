#nullable enable
using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.ArterialPressure.BL.UserSendResetPasswordEmail
{
    /// <summary> Команда отправки письма о восстановлении пароля </summary>
    public class UserSendResetPasswordEmailCommand : ICommand<UserSendResetPasswordEmailResponse>
    {
        /// <summary> Почта </summary>
        public string? Email { get; set; }

        /// <summary> Callback ссылка к которой добавится токен восстновления пароля </summary>
        public string? ChangePasswordUrl { get; set; }
    }
}