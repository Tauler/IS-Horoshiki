using System.Collections.Generic;
using System.Threading.Tasks;
using IsHoroshiki.DAO.Kladr.DaoEntities;

namespace IsHoroshiki.DAO.Kladr.Repositories.Interfaces
{
    /// <summary>
    /// Репозитарий Записи с объектами шестого уровня классификации (номера домов улиц городов и населенных пунктов);
    /// </summary>
    public interface IDomaRepository : IBaseRepository<Doma>
    {
        /// <summary>
        /// Получить все дома
        /// </summary>
        /// <param name="query">Наименование объекта в запросе</param>
        /// <param name="regionId">Id объекта в запросе</param>
        /// <param name="withParent">true - если необходимо вернуть родительскте записи для данного объекта</param>
        /// <param name="limit">Максимальное количество записей в ответе</param>
        /// <returns></returns>
        Task<IEnumerable<Doma>> GetAllAsync(string query, string regionId, bool withParent = false, int limit = 10);

        /// <summary>
        /// Поиск дома по коду
        /// </summary>
        /// <param name="code">Код дома</param>
        /// <returns></returns>
        Task<Doma> GetByCode(string code);
    }
}
