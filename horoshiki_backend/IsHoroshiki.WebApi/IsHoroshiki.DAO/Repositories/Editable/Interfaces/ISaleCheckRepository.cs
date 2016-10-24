using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.DaoEntities.Editable.Helpers;
using System;
using System.Collections.Generic;

namespace IsHoroshiki.DAO.Repositories.Editable.Interfaces
{
    /// <summary>
    /// Репозиторий Чек продаж
    /// </summary>
    public interface ISaleCheckRepository : IBaseRepository<SaleCheck>
    {
        /// <summary>
        /// Найти чек по его Id
        /// </summary>
        /// <param name="idCheck">Id чека</param>
        /// <returns></returns>
        SaleCheck GetByCheckId(string idCheck);

        /// <summary>
        /// Получить отчет-анализ за период
        /// </summary>
        /// <param name="idPlatform">id Площадки</param>
        /// <param name="start">Дата начала</param>
        /// <param name="end">Дата окончания</param>
        /// <param name="isSushi">true - если суши</param>
        /// <returns></returns>
        List<SaleAnalizeResult> GetSaleCheckAnalize(int idPlatform, DateTime start, DateTime end, bool isSushi);
    }
}
