using IsHoroshiki.BusinessEntities.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.BusinessEntities.NotEditableDictionaries
{
    /// <summary>
    /// ПодОтделы
    /// </summary>
    public class SubDepartmentModel : BaseNotEditableDictionaryModel, ISubDepartmentModel
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
