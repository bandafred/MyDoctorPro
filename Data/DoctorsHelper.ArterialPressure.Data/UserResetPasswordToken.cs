using System;

namespace DoctorsHelper.ArterialPressure.Data
{
    /// <summary> Модель токена для восстановления пароля пользователя </summary>
    public class UserResetPasswordToken
    {
        /// <summary> Идентификатор </summary>
        public string Id { get; set; }
        /// <summary> Идентификатор пользователя </summary>
        public string UserId { get; set; }
        /// <summary> Токен </summary>
        public string Token { get; set; }
        /// <summary> Валиден до </summary>
        public DateTime ValidTo { get; set; }

        /// <summary> Пользователь </summary>
        public virtual User User { get; set; }
    }
}
