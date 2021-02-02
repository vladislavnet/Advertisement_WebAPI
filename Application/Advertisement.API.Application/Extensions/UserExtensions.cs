using advertisement.models;
using Advertisement.API.Application.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advertisement.API.Application.Extensions
{
    public static class UserExtensions
    {
        /// <summary>
        /// Расширение позволяющее объект класса User преобразовать в UserDto
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
            };
        }
    }
}
