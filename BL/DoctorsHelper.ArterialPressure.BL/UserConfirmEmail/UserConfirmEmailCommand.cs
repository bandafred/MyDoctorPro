using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.ArterialPressure.BL.UserConfirmEmail
{
    /// <summary> Команда для подтверждения Email пользователя </summary>
    public class UserConfirmEmailCommand : ICommand<UserConfirmEmailResponse>
    {
        /// <summary> Идентификатор пользователя </summary>
        public string UserId { get; set; }

        /// <summary> Токен подтверждения </summary>
        public string ConfirmationToken { get; set; }
    }
}