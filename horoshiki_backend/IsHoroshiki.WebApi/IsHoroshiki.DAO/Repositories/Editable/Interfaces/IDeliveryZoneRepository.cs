using IsHoroshiki.DAO.DaoEntities.Editable;
using System.Collections;
using System.Collections.Generic;

namespace IsHoroshiki.DAO.Repositories.Editable.Interfaces
{
    /// <summary>
    /// Репозиторий зон доставки
    /// </summary>
    public interface IDeliveryZoneRepository : IBaseRepository<DeliveryZone>
    {
        /// <summary>  
        /// Получить все записи для площадки
        /// </summary>  
        /// <param name="platformId">Id площадки</param>
        IEnumerable<DeliveryZone> GetAllByPlatform(int platformId);
    }
}
