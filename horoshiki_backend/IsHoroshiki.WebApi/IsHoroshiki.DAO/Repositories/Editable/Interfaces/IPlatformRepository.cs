using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.DAO.Repositories.Editable.Interfaces
{
    /// <summary>
    /// Репозиторий Площадка
    /// </summary>
    public interface IPlatformRepository : IBaseRepository<Platform>
    {
        /// <summary>
        /// true - если существует площадка, для которой указан пользователь с Id
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <returns></returns>
        bool IsExistForUser(int userId);

        /// <summary>
        /// true - если существует площадка, для которой указано подразделение с Id
        /// </summary>
        /// <param name="subDivisionId">Id подразделения</param>
        bool IsExistForSubDivision(int subDivisionId);
    }
}
