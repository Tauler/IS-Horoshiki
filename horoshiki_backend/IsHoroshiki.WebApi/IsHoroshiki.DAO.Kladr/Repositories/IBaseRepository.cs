using IsHoroshiki.DAO.Kladr.DaoEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsHoroshiki.DAO.Kladr
{
    /// <summary>  
    /// Базовый репозиторий
    /// </summary>  
    /// <typeparam name="TDaoEntity">Тип сущности Dao</typeparam> 
    public interface IBaseRepository<TDaoEntity>
         where TDaoEntity : IBaseDaoEntity
    {
        #region методы

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

        #endregion
    }
}
