using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;
using IsHoroshiki.DAO.Repositories.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditableDictionaries
{
    /// <summary>
    /// Репозиторий Статус площадки
    /// </summary>
    public class StatusSiteRepository : BaseNotEditableDictionaryRepository<StatusSite>, IStatusSiteRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public StatusSiteRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion
    }
}
