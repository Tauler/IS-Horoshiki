using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.Editable
{
    /// <summary>
    /// Конфигурация Цель на месяц по показателям
    /// </summary>
    public class MonthObjectiveConfiguration : BaseDaoEntityConfiguration<MonthObjective>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public MonthObjectiveConfiguration() 
            : base("MonthObjectives")
        {
            Property(i => i.PlatformId)
                .IsRequired();

            Property(i => i.Year)
                .IsRequired();

            Property(i => i.Month)
                .IsRequired();

            Property(i => i.ChecksPerHourForPositionSushiChef)
                .IsRequired();

            Property(i => i.ChecksPerHourForPositionCourier)
                .IsRequired();

            Property(i => i.ChecksPerHourForPositionPizzaChef)
                .IsRequired();
        }

        #endregion
    }
}
