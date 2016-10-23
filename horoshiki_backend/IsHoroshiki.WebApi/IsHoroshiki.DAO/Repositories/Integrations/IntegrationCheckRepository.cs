using IsHoroshiki.DAO.DaoEntities.Integrations;
using System.Collections.Generic;
using System.Linq;

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

        #region Конструктор

        /// <summary>
        /// Список чеков для нормализации
        /// </summary>
        /// <returns></returns>
        public List<IntegrationCheck> GetForNormalization()
        {
            return DbSet.Where(ic => ic.Cmd.ToUpper() == "order".ToUpper() && !ic.IsSuccessConvert).ToList();
        }

        #endregion
    }
}
