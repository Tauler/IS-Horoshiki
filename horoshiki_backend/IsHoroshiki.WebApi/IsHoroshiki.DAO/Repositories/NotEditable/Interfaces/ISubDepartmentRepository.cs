using IsHoroshiki.DAO.DaoEntities.NotEditable;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsHoroshiki.DAO.Repositories.NotEditable.Interfaces
{
    /// <summary>
    /// Репозиторий ПодОтделы
    /// </summary>
    public interface ISubDepartmentRepository : IBaseNotEditableDictionaryRepository<SubDepartment>
    {
        /// <summary>
        /// Получить отделы для указанных параметров
        /// </summary>
        /// <param name="isCool">true - холодный цех</param>
        /// <param name="isPizza">true - пицца</param>
        /// <param name="isSushi">true - суши</param>
        /// <returns></returns>
        Task<ICollection<SubDepartment>> GetSubDepartamentsAsync(bool isCool, bool isPizza, bool isSushi);
    }
}
