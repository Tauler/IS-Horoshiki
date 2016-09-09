using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace IsHoroshiki.DAO.Kladr.Repositories
{
    /// <summary>  
    /// Базовый репозиторий
    /// </summary>  
    /// <typeparam name="TDaoEntity">Тип сущности Dao</typeparam> 
    public abstract class BaseRepository<TDaoEntity> : IBaseRepository<TDaoEntity>
        where TDaoEntity : class, IBaseDaoEntity
    {
        #region поля и свойства

        /// <summary>
        /// Контекст выполнения БД
        /// </summary>
        protected KladrDbContext Context;

        /// <summary>
        /// Сущность БД
        /// </summary>
        protected DbSet<TDaoEntity> DbSet;

        #endregion

        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        protected BaseRepository(KladrDbContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<TDaoEntity>();
        }

        #endregion

        #region методы

        /// <summary>  
        /// Получить записи по условию  
        /// </summary>  
        /// <param name="where">Условие в запросе</param>  
        /// <returns></returns>  
        public virtual async Task<IEnumerable<TDaoEntity>> GetManyAsync(Func<TDaoEntity, bool> where)
        {
            var list = DbSet.Where(where).ToList();
            return list;
        }

        /// <summary>  
        /// Получить запись по условию    
        /// </summary>  
        /// <param name="where">Условие в запросе</param>  
        /// <returns></returns>  
        public virtual async Task<TDaoEntity> GetAsync(Func<TDaoEntity, Boolean> where)
        {
            var daoEntity = DbSet.Where(where).FirstOrDefault();
            return daoEntity;
        }

        #endregion

        #region protected

        /// <summary>
        /// Добавление параметра
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected DbParameter GetParameter(string name, object value)
        {
            return new SqlParameter(name, value);
        }

        #endregion

    }
}
