using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DoctorsHelper.ArterialPressure.Data
{
    /// <summary>
    /// Утверджение ролей. Класс расширяющий <see cref="IdentityRoleClaim{T}"/> универсальный тип которого <see cref="string"/>
    /// </summary>
    public class RoleClaim : IdentityRoleClaim<string>
    {
        /// <summary> Роль </summary>
        public virtual Role Role { get; set; }
    }
}