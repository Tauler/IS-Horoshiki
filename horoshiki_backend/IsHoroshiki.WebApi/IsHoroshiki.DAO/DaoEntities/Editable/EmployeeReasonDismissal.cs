namespace IsHoroshiki.DAO.DaoEntities.Editable
{
    /// <summary>
    /// Причины увольнения сотрудника
    /// </summary>
    public class EmployeeReasonDismissal : BaseDaoEntity
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
