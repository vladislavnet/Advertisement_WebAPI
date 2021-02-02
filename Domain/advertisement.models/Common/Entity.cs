using System;
using System.Collections.Generic;
using System.Text;

namespace advertisement.models.Common
{
    /// <summary>
    /// Класс Entity, является базовым классом для всех сущностей предметной области
    /// </summary>
    /// <typeparam name="T">Тип уникального индетификатора сущности</typeparam>
    public class Entity<TKey>
    {
        /// <summary>
        /// Уникальный идентификатор сущности
        /// </summary>
        public TKey Id { get; set; }
    }
}
