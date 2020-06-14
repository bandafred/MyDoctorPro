using Microsoft.AspNetCore.Identity;

namespace DoctorsHelper.ArterialPressure.Data
{
    /// <summary>
    /// Связь пользователя и роли. Класс расширяющий <see cref="IdentityUserRole{T}"/> универсальный тип которого <see cref="string"/>
    /// </summary>
    public class UserRole : IdentityUserRole<string>
    {
        /// <summary> Пользователь </summary>
        public virtual User User { get; set; }

        /// <summary> Роль </summary>
        public virtual Role Role { get; set; }
    }
}