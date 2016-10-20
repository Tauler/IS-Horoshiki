using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.Repositories.NotEditable.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace IsHoroshiki.DAO.Repositories.NotEditable
{
    /// <summary>
    /// Репозиторий Подотделы
    /// </summary>
    public class SubDepartmentRepository : BaseNotEditableRepository<SubDepartment>, ISubDepartmentRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public SubDepartmentRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion

        #region ISubDepartmentRepository

        /// <summary>
        /// Получить отделы для указанных параметров
        /// </summary>
        /// <param name="isCool">true - холодный цех</param>
        /// <param name="isPizza">true - пицца</param>
        /// <param name="isSushi">true - суши</param>
        /// <returns></returns>
        public Task<ICollection<SubDepartment>> GetSubDepartamentsAsync(bool isCool, bool isPizza, bool isSushi)
        {
            return Task<ICollection<SubDepartment>>.Factory.StartNew(() =>
            {
                var result = new List<SubDepartment>();

                AddSubDepartamentToList(isCool, result, DatabaseConstant.SubDepartmentCool);
                AddSubDepartamentToList(isPizza, result, DatabaseConstant.SubDepartmentPizza);
                AddSubDepartamentToList(isSushi, result, DatabaseConstant.SubDepartmentSushi);

                return result;
            });
        }

        #endregion

        #region private

        /// <summary>
        /// Добавить в список подотдел, если флаг isAdd = true
        /// </summary>
        /// <param name="isAdd">true - добавить в список</param>
        /// <param name="list">Список</param>
        /// <param name="subDepartament">Guid подотдела</param>
        private void AddSubDepartamentToList(bool isAdd, List<SubDepartment> list, Guid subDepartament)
        {
            if (!isAdd)
            {
                return;
            }

            var exist = DbSet.FirstOrDefault(sd => sd.Guid == subDepartament);
            if (exist != null)
            {
                list.Add(exist);
            }
        }

        #endregion
    }
}
