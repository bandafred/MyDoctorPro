using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DoctorsHelper.ArterialPressure.Data
{
    /// <summary>
    /// Пользователь. Класс расширяющий <see cref="IdentityUser"/>
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary> Дата рождения пользователя </summary>
        public DateTime BirthDate { get; set; }

        /// <summary> Параметр отражающий мужчина ли пользователь </summary>
        public bool IsMen { get; set; }


        /// <summary> JWT Токены пользователя </summary>
        public virtual List<UserJwtToken> UserJwtTokens { get; set; }

        /// <summary> Токены восстановления пароля пользователя </summary>
        public virtual List<UserResetPasswordToken> UserPasswordResetTokens { get; set; }

        /// <summary> Записи в журнале пользователя </summary>
        public virtual List<DiaryRecord> DiaryRecords { get; set; }

        /// <summary> Связь с ролями пользователя </summary>
        public virtual List<UserRole> UserRoles { get; set; }

        /// <summary> Утверджения пользователя </summary>
        public virtual List<UserClaim> UserClaims { get; set; }

        /// <summary> Токены пользователя. External providers </summary>
        public virtual List<UserToken> UserTokens { get; set; }

        /// <summary> Логины пользователя. External providers </summary>
        public virtual List<UserLogin> UserLogins { get; set; }
    }
}
