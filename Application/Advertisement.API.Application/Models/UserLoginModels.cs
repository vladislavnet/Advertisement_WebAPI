using System;
using System.ComponentModel.DataAnnotations;

namespace Advertisement.API.Application.Models
{
    /// <summary>
    /// Модель предназначенная для авторизации пользователя
    /// </summary>
    public class UserLoginModels
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
