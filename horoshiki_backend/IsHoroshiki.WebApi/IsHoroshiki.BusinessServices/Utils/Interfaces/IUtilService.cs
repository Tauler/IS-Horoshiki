using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Utils.Interfaces
{
    /// <summary>
    /// Cервис проверки доступности сервера и т.п.
    /// </summary>
    public interface IUtilService
    {
        /// <summary>
        /// true - если сервер БД доступен
        /// </summary>
        Task<bool> IsAvailableServer();
    }
}
