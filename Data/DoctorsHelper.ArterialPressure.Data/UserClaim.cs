using Microsoft.AspNetCore.Identity;

namespace DoctorsHelper.ArterialPressure.Data
{
    /// <summary>
    /// Утверджение пользователя. Класс расширяющий <see cref="IdentityUserClaim{T}"/> универсальный тип которого <see cref="string"/>
    /// </summary>
    public class UserClaim : IdentityUserClaim<string>
    {
        /// <summary> Пользователь </summary>
        public virtual User User { get; set; }
    }
}