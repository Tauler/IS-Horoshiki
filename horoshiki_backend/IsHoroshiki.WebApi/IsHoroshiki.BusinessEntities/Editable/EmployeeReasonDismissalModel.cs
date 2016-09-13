using IsHoroshiki.BusinessEntities.Editable.Interfaces;

namespace IsHoroshiki.BusinessEntities.Editable
{
    /// <summary>
    /// Причины увольнения сотрудника
    /// </summary>
    public class EmployeeReasonDismissalModel : BaseBusninessModel, IEmployeeReasonDismissalModel
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name
        {
            get;
            set;
        }
    }
}
