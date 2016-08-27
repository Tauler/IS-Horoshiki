using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.Editable
{
    /// <summary>
    /// Конфигурация Подразделения
    /// </summary>
    public class SubDivisionConfiguration : BaseDaoEntityConfiguration<SubDivision>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public SubDivisionConfiguration() 
            : base("SubDivisions")
        {
            HasRequired(s => s.PriceType);
        }

        #endregion
    }
}
