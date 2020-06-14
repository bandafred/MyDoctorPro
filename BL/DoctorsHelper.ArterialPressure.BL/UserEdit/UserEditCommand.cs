#nullable enable
using System;
using DoctorsHelper.ArterialPressure.Data;
using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.ArterialPressure.BL.UserEdit
{
    /// <summary> Команда для редактирования пользователя </summary>
    public class UserEditCommand : ICommand<UserEditResponse>, IMapTo<User>
    {
        /// <summary> Имя пользователя </summary>
        public string? UserName { get; set; }
        
        /// <summary> Дата рождения пользователя </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary> Параметр отражающий мужчина ли пользователь </summary>
        public bool? IsMen { get; set; }
    }
}