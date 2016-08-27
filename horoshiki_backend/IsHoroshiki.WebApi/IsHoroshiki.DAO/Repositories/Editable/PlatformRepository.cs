using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;

namespace IsHoroshiki.DAO.Repositories.Editable
{
    /// <summary>
    /// Репозиторий Площадка
    /// </summary>
    public class PlatformRepository : BaseRepository<Platform>, IPlatformRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public PlatformRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion
    }
}
