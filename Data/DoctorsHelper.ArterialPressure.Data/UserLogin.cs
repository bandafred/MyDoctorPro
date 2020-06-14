using Microsoft.AspNetCore.Identity;

namespace DoctorsHelper.ArterialPressure.Data
{
    /// <summary>
    /// Запись о входе с помощью сторонних провайдеров. Класс расширяющий <see cref="IdentityUserLogin{T}"/> универсальный тип которого <see cref="string"/>
    /// </summary>
    public class UserLogin : IdentityUserLogin<string>
    {
        /// <summary> Пользователь </summary>
        public virtual User User { get; set; }
    }
}