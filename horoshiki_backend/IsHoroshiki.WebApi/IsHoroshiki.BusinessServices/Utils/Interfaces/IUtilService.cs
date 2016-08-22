using IsHoroshiki.BusinessEntities.NotEditableDictionaries;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces
{
    /// <summary>
    /// Cервис проверки доступности сервера и т.п.
    /// </summary>
    public interface IUtilService
    {
        /// <summary>
        /// true - если сервер БД доступен
        /// </summary>
        bool IsAvailableServer();
    }
}
