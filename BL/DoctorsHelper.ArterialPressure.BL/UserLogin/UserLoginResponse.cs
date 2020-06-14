namespace DoctorsHelper.ArterialPressure.BL.UserLogin
{
    /// <summary> Ответ на логин пользователя </summary>
    public class UserLoginResponse
    {
        /// <summary> Токен </summary>
        public string Token { get; set; }

        /// <summary> Подтвержден ли Email </summary>
        public bool EmailConfirmed { get; set; }
    }
}