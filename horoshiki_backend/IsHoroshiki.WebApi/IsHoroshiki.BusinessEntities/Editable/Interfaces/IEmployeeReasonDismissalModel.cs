namespace IsHoroshiki.BusinessEntities.Editable.Interfaces
{
    /// <summary>
    /// Причины увольнения сотрудника
    /// </summary>
    public interface IEmployeeReasonDismissalModel : IBaseBusninessModel
    {
        /// <summary>
        /// Наименование
        /// </summary>
        string Name
        {
            get;
            set;
        }
    }
}
