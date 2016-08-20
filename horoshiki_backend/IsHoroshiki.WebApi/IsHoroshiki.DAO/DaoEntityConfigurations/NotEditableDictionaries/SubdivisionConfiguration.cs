using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditableDictionaries
{
    /// <summary>
    /// Конфигурация Подразделения
    /// </summary>
    public class SubdivisionConfiguration : BaseNotEditableDictionaryDaoEntityConfiguration<Subdivision>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public SubdivisionConfiguration() 
            : base("Subdivisions")
        {

        }

        #endregion
    }
}
