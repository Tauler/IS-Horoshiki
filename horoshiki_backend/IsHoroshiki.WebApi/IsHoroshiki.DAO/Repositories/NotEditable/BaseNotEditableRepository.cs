﻿using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.DAO.Repositories.NotEditable
{
    /// <summary>
    /// Базовый репозиатрий нередактируемых справочников
    /// </summary>
    public abstract class BaseNotEditableDictionaryRepository<TDaoEntity> : BaseRepository<TDaoEntity>
        where TDaoEntity : BaseNotEditableDaoEntity
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        protected BaseNotEditableDictionaryRepository(ApplicationDbContext context)
            : base(context)
        {
           
        }

        #endregion
    }
}