using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsHoroshiki.DAO.Repositories
{
    /// <summary>  
    /// Базовый репозиторий
    /// </summary>  
    /// <typeparam name="TDaoEntity">Тип сущности Dao</typeparam> 
    public interface IBaseRepository<TDaoEntity> where TDaoEntity : IBaseDaoEntity
    {
        #region методы

        /// <summary>  
        /// Найти по Id 
        /// </summary>  
        /// <param name="id">Id</param>  
        /// <returns></returns>  
        Task<TDaoEntity> GetByIdAsync(int id);

        /// <summary>  
        /// Добавить
        /// </summary>  
        /// <param name="entity">Сущность DAO</param>  
        void Insert(TDaoEntity entity);

        /// <summary>  
        /// Удалить по Id 
        /// </summary>  
        /// <param name="id">Id</param>  
        void Delete(int id);

        /// <summary>  
        /// Удалить
        /// </summary>  
        /// <param name="entity">Сущность DAO</param>  
        void Delete(TDaoEntity entity);

        /// <summary>  
        /// Обновить  
        /// </summary>  
        /// <param name="entity">Сущность DAO</param>  
        void Update(TDaoEntity entity);

        /// <summary>  
        /// Получить записи по условию  
        /// </summary>  
        /// <param name="where">Условие в запросе</param>  
        /// <returns></returns>  
        Task<IEnumerable<TDaoEntity>> GetManyAsync(Func<TDaoEntity, bool> where);

        /// <summary>  
        /// Получить запись по условию    
        /// </summary>  
        /// <param name="where">Условие в запросе</param>  
        /// <returns></returns>  
        Task<TDaoEntity> GetAsync(Func<TDaoEntity, Boolean> where);

        /// <summary>  
        /// Удалить записи по условию 
        /// </summary>  
        /// <param name="where">Условие в запросе</param>  
        /// <returns></returns>  
        void Delete(Func<TDaoEntity, Boolean> where);

        /// <summary>  
        /// Получить все записи
        /// </summary>  
        /// <param name="pageNo">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="sortField">Поле для сортировки</param>
        /// <param name="isAscending">true - сортировать по возрастанию</param>
        Task<IEnumerable<TDaoEntity>> GetAllAsync(int pageNo = 1, int pageSize = 50, string sortField = "", bool isAscending = true);

        /// <summary>  
        /// Получить количество записей
        /// </summary>  
        /// <returns></returns>  
        Task<int> CountAsync();

        /// <summary>  
        /// Проверка на существование записи
        /// </summary>  
        /// <param name="id">id</param>  
        /// <returns></returns>  
        Task<bool> IsExistsAsync(int id);

        #endregion
    }
}
