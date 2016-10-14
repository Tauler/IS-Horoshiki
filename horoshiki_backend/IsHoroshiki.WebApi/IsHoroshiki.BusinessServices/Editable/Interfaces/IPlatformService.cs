using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Editable.Interfaces
{
    /// <summary>
    /// Cервис Площадка
    /// </summary>
    public interface IPlatformService : IBaseEditableService<IPlatformModel>
    {
        /// <summary>
        /// Получить все площадки для подразделения
        /// </summary>
        /// <param name="subDivisionId">Id подразделения</param>
        Task<IEnumerable<IPlatformModel>> GetAllBySubDivision(int subDivisionId);

        /// <summary>
        /// Сохранение координат площадки
        /// </summary>
        /// <param name="platformId">Id площадки</param>
        /// <param name="coordinates">Координаты площадки</param>
        /// <returns></returns>
        Task<ModelEntityModifyResult> AddYandexMapToPlatform(int platformId, string coordinates);
    }
}
