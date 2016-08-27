namespace IsHoroshiki.BusinessEntities.NotEditable.Interfaces
{
    /// <summary>
    /// ПодОтделы
    /// </summary>
    public interface ISubDepartmentModel : IBaseNotEditableModel
    {
        /// <summary>
        /// Депратамент
        /// </summary>
        int DepartmentId
        {
            get;
            set;
        }

        /// <summary>
        /// Депратамент
        /// </summary>
        IDepartmentModel Department
        {
            get;
            set;
        }
    }
}
