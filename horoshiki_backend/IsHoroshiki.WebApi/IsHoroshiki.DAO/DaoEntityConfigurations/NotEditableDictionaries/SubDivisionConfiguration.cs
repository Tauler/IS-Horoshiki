using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditableDictionaries
{
    /// <summary>
    /// Конфигурация Подразделения
    /// </summary>
    public class SubDivisionConfiguration : BaseNotEditableDictionaryDaoEntityConfiguration<SubDivision>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public SubDivisionConfiguration() 
            : base("SubDivisions")
        {

        }

        #endregion
    }
}
