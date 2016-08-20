using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.DAO.Repositories.NotEditableDictionaries
{
    /// <summary>
    /// Базовый репозиатрий нередактируемых справочников
    /// </summary>
    public abstract class BaseNotEditableDictionaryRepository<TDaoEntity> : BaseRepository<TDaoEntity, int>
        where TDaoEntity : BaseNotEditableDictionaryDaoEntity
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
