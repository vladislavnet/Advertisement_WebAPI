using advertisement.models.Common;
using System;

namespace advertisement.models
{
    /// <summary>
    /// Сущность "Обявление"
    /// </summary>
    public class Advert : Entity<int>
    {
        /// <summary>
        /// Заголовок объявления
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание объявления
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата и время создания объявления
        /// </summary>
        public DateTime CreateDateTime { get; set; }

        /// <summary>
        /// Уникальный идентификатор владельца объявления
        /// </summary>
        public int OwnerUserId { get; set; }

        /// <summary>
        /// Владелец объявления
        /// </summary>
        public User OwnerUser { get; set; }
    }
}
