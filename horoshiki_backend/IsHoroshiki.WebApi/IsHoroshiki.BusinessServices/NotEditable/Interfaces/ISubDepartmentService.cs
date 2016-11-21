using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessServices.NotEditable.Interfaces
{
    /// <summary>
    /// Cервис Подoтделы
    /// </summary>
    public interface ISubDepartmentService : IBaseNotEditableService<ISubDepartmentModel>
    {
        /// <summary>
        /// Найти все подотделы для отдела
        /// </summary>
        /// <param name="departamentId">Id отдела</param>
        /// <returns></returns>
        Task<List<ISubDepartmentModel>> GetAllByDepartament(int departamentId);
    }
}
