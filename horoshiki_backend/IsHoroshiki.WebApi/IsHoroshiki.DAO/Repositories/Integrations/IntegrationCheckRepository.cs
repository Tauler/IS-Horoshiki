using IsHoroshiki.DAO.DaoEntities.Integrations;

namespace IsHoroshiki.DAO.Repositories.Integrations
{
    /// <summary>
    /// Репозиторий  Получение чеков (заказов) из 1С
    /// </summary>
    public class IntegrationCheckRepository : BaseRepository<IntegrationCheck>, IIntegrationCheckRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public IntegrationCheckRepository(ApplicationDbContext context)
            : base(context)
        {

        }
        
        #endregion
    }
}
