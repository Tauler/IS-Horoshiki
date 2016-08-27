using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;

namespace IsHoroshiki.BusinessEntities.NotEditable
{
    /// <summary>
    /// ПодОтделы
    /// </summary>
    public class SubDepartmentModel : BaseNotEditableModel, ISubDepartmentModel
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
        public IDepartmentModel Department
        {
            get;
            set;
        }
    }
}
