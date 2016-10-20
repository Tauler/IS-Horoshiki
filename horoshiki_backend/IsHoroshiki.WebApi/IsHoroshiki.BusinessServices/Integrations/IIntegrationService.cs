using IsHoroshiki.BusinessEntities.Integrations;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Integrations
{
    /// <summary>
    /// Сервис интеграции
    /// </summary>
    public interface IIntegrationService
    {
        /// <summary>
        /// Сохранить запись о чеки
        /// </summary>
        /// <param name="model">Модель</param>
        Task<bool> Save(IIntegrationCheckModel model);
    }
}
