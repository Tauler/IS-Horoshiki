using IsHoroshiki.DAO.Kladr;
using System;

namespace IsHoroshiki.BusinessServices.Kladr
{
    /// <summary>
    /// Базовый интерфейс сервисов кладр
    /// </summary>
    public interface IBaseKladrBusinessService<TDaoEntity> : IDisposable
        where TDaoEntity : IBaseDaoEntity
    {
    }
}
