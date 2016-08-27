using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.Repositories.NotEditable.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditable
{
    /// <summary>
    /// Репозиторий Должности
    /// </summary>
    public class PositionRepository : BaseNotEditableDictionaryRepository<Position>, IPositionRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public PositionRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion
    }
}
