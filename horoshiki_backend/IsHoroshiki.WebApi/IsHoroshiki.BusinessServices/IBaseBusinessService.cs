using IsHoroshiki.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices
{
    /// <summary>
    /// Базовый интерфейс для всей бизнес-логики сервисов
    /// </summary>
    public interface IBaseBusinessService<TModelEntity> : IDisposable 
        where TModelEntity : IBaseBusninessModel
    {
        /// <summary>
        /// Получить всех пользователей без пейджинга
        /// </summary>
        /// <param name="sortField">Поле для сортировки</param>
        /// <param name="isAscending">true - сортировать по возрастанию</param>
        Task<IEnumerable<TModelEntity>> GetAllAsync(string sortField = "", bool isAscending = true);

        /// <summary>  
        /// Найти по Id 
        /// </summary>  
        /// <param name="id">Id</param>  
        /// <returns></returns>  
        Task<TModelEntity> GetByIdAsync(int id);

        /// <summary>  
        /// Проверка на существование записи
        /// </summary>  
        /// <param name="id">id</param>  
        /// <returns></returns>  
        Task<bool> IsExistsAsync(int id);
    }
}
