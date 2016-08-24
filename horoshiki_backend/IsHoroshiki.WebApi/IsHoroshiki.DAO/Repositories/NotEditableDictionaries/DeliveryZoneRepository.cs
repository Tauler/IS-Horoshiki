using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;
using IsHoroshiki.DAO.Repositories.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditableDictionaries
{
    /// <summary>
    /// Репозиторий Типы зон доставки
    /// </summary>
    public class DeliveryZoneRepository : BaseNotEditableDictionaryRepository<DeliveryZone>, IDeliveryZoneRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public DeliveryZoneRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion
    }
}
