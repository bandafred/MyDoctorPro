using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DoctorsHelper.ArterialPressure.Data
{
    /// <summary>
    /// Роль. Класс расширяющий <see cref="IdentityRole"/>
    /// </summary>
    public class Role : IdentityRole
    {
        /// <summary> Связь с пользователями </summary>
        public virtual List<UserRole> UserRoles { get; set; }
        /// <summary> Утверджения ролей </summary>
        public virtual List<RoleClaim> RoleClaims { get; set; }
    }
}