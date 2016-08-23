namespace IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries
{
    /// <summary>
    /// Подотдел
    /// </summary>
    public class SubDepartment : BaseNotEditableDictionaryDaoEntity
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
    }
}
