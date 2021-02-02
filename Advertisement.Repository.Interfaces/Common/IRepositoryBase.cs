using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advertisement.Repository.Interfaces.Common
{
    /// <summary>
    /// Обобщенный репозиторий
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepositoryBase<TEntity> where TEntity : class
    {

        /// <summary>
        /// Сохранение или добавление объекта сущности
        /// </summary>
        /// <param name="value"></param>
        void Add(TEntity value);

        /// <summary>
        /// Сохранение или добавление объекта сущности
        /// </summary>
        /// <param name="value"></param>
        void Update(TEntity value);

        /// <summary>
        /// Возрвращение всех объектов сущности
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Удаление объекта сущности
        /// </summary>
        /// <param name="value"></param>
        void Delete(TEntity value);
    }
}
