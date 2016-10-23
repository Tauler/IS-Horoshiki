using System.Collections.Generic;

namespace IsHoroshiki.DAO.DaoEntities.NotEditable
{
    /// <summary>
    /// Подотдел
    /// </summary>
    public class SubDepartment : BaseNotEditableDaoEntity
    {
        /// <summary>
        /// Депратамент
        /// </summary>
        public int DepartmentId
        {
            get;
            set;
        }

        /// <summary>
        /// Депратамент
        /// </summary>
        public Department Department
        {
            get;
            set;
        }

        /// <summary>
        /// Чеки продаж
        /// </summary>
        public ICollection<Editable.SaleCheck> SaleChecks
        {
            get;
            set;
        }
    }
}
