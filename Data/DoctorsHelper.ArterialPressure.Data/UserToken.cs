using Microsoft.AspNetCore.Identity;

namespace DoctorsHelper.ArterialPressure.Data
{
    /// <summary>
    /// Токен пользователей. Класс расширяющий <see cref="IdentityUserToken{T}"/> универсальный тип которого <see cref="string"/>
    /// </summary>
    public class UserToken : IdentityUserToken<string>
    {
        /// <summary> Пользователь </summary>
        public virtual User User { get; set; }
    }
}