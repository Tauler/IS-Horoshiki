using System.Collections.Generic;
using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities;
using IsHoroshiki.BusinessEntities.Paging;

namespace IsHoroshiki.BusinessServices
{
    /// <summary>
    /// Базовый сервис для редактируемого типа
    /// </summary>
    public interface IBaseEditableService<TModelEntity> : IBaseBusinessService<TModelEntity>
       where TModelEntity : class, IBaseBusninessModel
    {
        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        /// <param name="pageNo">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="sortField">Поле для сортировки</param>
        /// <param name="isAscending">true - сортировать по возрастанию</param>
        /// <returns></returns>
        Task<PagedResult<TModelEntity>> GetAllAsync(int pageNo = 1, int pageSize = 50, string sortField = "", bool isAscending = true);

        /// <summary>
        /// Добавить в БД
        /// </summary>
        /// <param name="model">Модель</param>
        /// <returns></returns>
        Task<ModelEntityModifyResult> AddAsync(TModelEntity model);

        /// <summary>
        /// Добавить в БД
        /// </summary>
        /// <param name="model">Модель</param>
        /// <returns></returns>
        Task<ModelEntityModifyResult> UpdateAsync(TModelEntity model);

        /// <summary>
        /// Удалить из БД
        /// </summary>
        /// <param name="id">Id объекта</param>
        /// <returns></returns>
        Task<ModelEntityModifyResult> DeleteAsync(int id);
    }
}
