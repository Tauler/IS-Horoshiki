using IsHoroshiki.DAO.DaoEntities.Integrations;

namespace IsHoroshiki.BusinessServices.Integrations.Queues
{
    /// <summary>
    /// Очередь чеков для нормализации в БД
    /// </summary>
    public interface IIntegrationCheckQueue
    {
        /// <summary>
        /// Добавить чек в очередь
        /// </summary>
        /// <param name="check">чек</param>
        void Enqueue(IntegrationCheck check);

        /// <summary>
        /// Загрузить очередь
        /// </summary>
        void Load();

        /// <summary>
        /// Стартовать очередь
        /// </summary>
        void Start();

        /// <summary>
        /// Остановить очередь
        /// </summary>
        void Stop();
    }
}