using IsHoroshiki.BusinessEntities.Kladr;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Kladr
{
    /// <summary>
    /// Сервис Записи с объектами седьмого уровня классификации (номера квартир домов);
    /// </summary>
    public interface IKladrService : IBaseKladrBusinessService<DAO.Kladr.DaoEntities.Kladr>
    {
        /// <summary>
        /// Получить все записи
        /// </summary>
        /// <param name="contentType">Тип искомого объекта (область, район и т.п.)</param>
        /// <param name="query">Наименование объекта в запросе</param>
        /// <param name="regionId">Id объекта в запросе</param>
        /// <param name="withParent">true - если необходимо вернуть родительскте записи для данного объекта</param>
        /// <param name="limit">Максимальное количество записей в ответе</param>
        /// <returns></returns>
        Task<IEnumerable<KladrResultModel>> Get(string contentType, string query, string regionId, bool withParent = false, int limit = 10);
    }
}
