using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IsHoroshiki.DAO.Repositories
{
    /// <summary>  
    /// Базовый репозиторий
    /// </summary>  
    /// <typeparam name="TDaoEntity">Тип сущности Dao</typeparam> 
    /// <typeparam name="TPrimaryKey">Тип primary key в БД</typeparam> 
    public interface IBaseRepository<TDaoEntity, TPrimaryKey> where TDaoEntity : BaseDaoEntity
    {
        #region методы

        /// <summary>  
        /// Найти по Id 
        /// </summary>  
        /// <param name="id">Id</param>  
        /// <returns></returns>  
        TDaoEntity GetById(TPrimaryKey id);

        /// <summary>  
        /// Добавить
        /// </summary>  
        /// <param name="entity">Сущность DAO</param>  
        void Insert(TDaoEntity entity);

        /// <summary>  
        /// Удалить по Id 
        /// </summary>  
        /// <param name="id">Id</param>  
        void Delete(TPrimaryKey id);

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
        IEnumerable<TDaoEntity> GetMany(Func<TDaoEntity, bool> where);

        /// <summary>  
        /// Получить запись по условию    
        /// </summary>  
        /// <param name="where">Условие в запросе</param>  
        /// <returns></returns>  
        TDaoEntity Get(Func<TDaoEntity, Boolean> where);

        /// <summary>  
        /// Удалить записи по условию 
        /// </summary>  
        /// <param name="where">Условие в запросе</param>  
        /// <returns></returns>  
        void Delete(Func<TDaoEntity, Boolean> where);

        /// <summary>  
        /// Получить все записи
        /// </summary>  
        /// <returns></returns>  
        IEnumerable<TDaoEntity> GetAll();

        /// <summary>  
        /// Проверка на существование записи
        /// </summary>  
        /// <param name="id">id</param>  
        /// <returns></returns>  
        bool Exists(TPrimaryKey id);

        #endregion
    }
}
