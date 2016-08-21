using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.DAO.Repositories.NotEditableDictionaries.Interfaces
{
    /// <summary>
    /// Базовый репозиатрий нередактируемых справочников
    /// </summary>
    public interface IBaseNotEditableDictionaryRepository<TDaoEntity> : IBaseRepository<TDaoEntity, int>
        where TDaoEntity : BaseNotEditableDictionaryDaoEntity
    {
        
    }
}
