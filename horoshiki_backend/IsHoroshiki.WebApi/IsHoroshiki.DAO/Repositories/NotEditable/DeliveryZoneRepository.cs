using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.Repositories.NotEditable.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditable
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
