using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.Repositories.NotEditable.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditable
{
    /// <summary>
    /// Репозиторий Статус площадки
    /// </summary>
    public class PlatformStatusRepository : BaseNotEditableDictionaryRepository<PlatformStatus>, IPlatformStatusRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public PlatformStatusRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion
    }
}
