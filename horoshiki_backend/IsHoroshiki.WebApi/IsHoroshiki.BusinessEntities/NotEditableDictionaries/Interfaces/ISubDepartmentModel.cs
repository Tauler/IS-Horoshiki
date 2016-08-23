namespace IsHoroshiki.BusinessEntities.NotEditableDictionaries.Interfaces
{
    /// <summary>
    /// ПодОтделы
    /// </summary>
    public interface ISubDepartmentModel : IBaseNotEditableDictionaryModel
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
