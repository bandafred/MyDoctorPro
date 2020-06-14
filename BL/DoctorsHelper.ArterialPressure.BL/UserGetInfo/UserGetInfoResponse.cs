using System;
using DoctorsHelper.ArterialPressure.Data;
using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.ArterialPressure.BL.UserGetInfo
{
    /// <summary> Ответ на команду получения информации о клиенте </summary>
    public class UserGetInfoResponse: IMapFrom<User>
    {
        /// <summary> Дата рождения пользователя </summary>
        public DateTime BirthDate { get; set; }

        /// <summary> Параметр отражающий мужчина ли пользователь </summary>
        public bool IsMen { get; set; }

        /// <summary> Почта </summary>
        public string Email { get; set; }

        /// <summary> Имя пользователя </summary>
        public string UserName { get; set; }

        /// <summary> Подтвержден ли Email </summary>
        public bool EmailConfirmed { get; set; }
    }
}