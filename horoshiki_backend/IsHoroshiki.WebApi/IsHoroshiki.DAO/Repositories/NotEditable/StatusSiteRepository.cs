using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.Repositories.NotEditable.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditable
{
    /// <summary>
    /// Репозиторий Статус площадки
    /// </summary>
    public class StatusSiteRepository : BaseNotEditableDictionaryRepository<PlatformStatus>, IStatusSiteRepository
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
