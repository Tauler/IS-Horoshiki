using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.Repositories.NotEditable.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditable
{
    /// <summary>
    /// Репозиторий Типы зон доставки
    /// </summary>
    public class DeliveryZoneTypeRepository : BaseNotEditableRepository<DeliveryZoneType>, IDeliveryZoneTypeRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public DeliveryZoneTypeRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion
    }
}
