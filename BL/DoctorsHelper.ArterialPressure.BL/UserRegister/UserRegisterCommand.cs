#nullable enable
using System;
using DoctorsHelper.ArterialPressure.Data;
using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.ArterialPressure.BL.UserRegister
{
    /// <summary> Команда регистрации пользователя </summary>
    public class UserRegisterCommand : ICommand<UserRegisterResponse>, IMapTo<User>
    {
        /// <summary> Дата рождения пользователя </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary> Параметр отражающий мужчина ли пользователь </summary>
        public bool? IsMen { get; set; }

        /// <summary> Имя пользователя, необязательный параметр, если пустой берется строка из Email до символа @ </summary>
        public string? UserName { get; set; }

        /// <summary> Почта </summary>
        public string? Email { get; set; }

        /// <summary> Пароль </summary>
        public string? Password { get; set; }
    }
}