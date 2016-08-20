using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditableDictionaries
{
    /// <summary>
    /// Конфигурация Должности
    /// </summary>
    public class PositionConfiguration : BaseNotEditableDictionaryDaoEntityConfiguration<Position>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public PositionConfiguration() 
            : base("Positions")
        {

        }

        #endregion
    }
}
