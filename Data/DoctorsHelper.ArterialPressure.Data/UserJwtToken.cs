using System;

namespace DoctorsHelper.ArterialPressure.Data
{
    /// <summary> JWT токен пользователя </summary>
    public class UserJwtToken
    {
        /// <summary> Идентификатор </summary>
        public int Id { get; set; }

        /// <summary> Id Пользователя </summary>
        public string UserId { get; set; }

        /// <summary> Токен </summary>
        public string Token { get; set; }

        /// <summary> Дата и время истечения токена </summary>
        public DateTime? ExpirationDateTime { get; set; }

        /// <summary> Пользователь </summary>
        public virtual User User { get; set; }
    }
}
