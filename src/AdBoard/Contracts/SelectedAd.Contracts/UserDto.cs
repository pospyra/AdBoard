using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.Contracts
{
    /// <summary>
    /// Можель представления Пользователя
    /// </summary>
    public class UserDto
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Логин пользователя.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// ПАРОЛЬ ТУТ ХРАНИТСЯ НЕ БУДЕТ 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Email Пользователя.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Регион
        /// </summary>
        public string Region { get; set; }

    }
}
