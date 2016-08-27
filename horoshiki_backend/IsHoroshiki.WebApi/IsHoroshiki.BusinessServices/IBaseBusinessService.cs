using IsHoroshiki.BusinessEntities;
using System;
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
