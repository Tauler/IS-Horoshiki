using System.Threading.Tasks;
using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.DaoEntities.Integrations;

namespace IsHoroshiki.BusinessServices.Integrations.Queues
{
    /// <summary>
    /// Нормализация чека
    /// </summary>
    public interface INormalizationCheck
    {
        /// <summary>
        /// Нормализация чека для его сохранения
        /// </summary>
        /// <param name="check">Чек 1С</param>
        /// <returns>Нормализованное состояние чека</returns>
        Task<SaleCheck> ExecuteNormalization(IntegrationCheck check);
    }
}