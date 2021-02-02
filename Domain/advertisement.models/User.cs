using advertisement.models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace advertisement.models
{
    /// <summary>
    /// Сущность "Пользователь"
    /// </summary>
    public class User : Entity<int>
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Роль пользователя
        /// </summary>
        public string Role { get; set; }
    }
}
