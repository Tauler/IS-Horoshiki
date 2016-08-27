using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.DAO.Repositories.NotEditable.Interfaces
{
    /// <summary>
    /// Базовый репозиатрий нередактируемых справочников
    /// </summary>
    public interface IBaseNotEditableDictionaryRepository<TDaoEntity> : IBaseRepository<TDaoEntity>
        where TDaoEntity : BaseNotEditableDaoEntity
    {
        
    }
}
