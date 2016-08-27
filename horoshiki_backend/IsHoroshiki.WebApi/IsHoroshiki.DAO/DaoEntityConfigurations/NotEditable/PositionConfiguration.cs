using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditable
{
    /// <summary>
    /// Конфигурация Должности
    /// </summary>
    public class PositionConfiguration : BaseNotEditableDaoEntityConfiguration<Position>
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
