using IsHoroshiki.DAO.DaoEntities.Integrations;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.Editable
{
    /// <summary>
    /// Конфигурация Получение чеков (заказов) из 1С
    /// </summary>
    public class IntegrationCheckConfiguration : BaseDaoEntityConfiguration<IntegrationCheck>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public IntegrationCheckConfiguration()
            : base("IntegrationChecks")
        {
            Property(p => p.Cmd)
                .HasMaxLength(256);

            Property(p => p.IdCheck)
                .HasMaxLength(100);

            Property(p => p.DateDoc)
                .HasMaxLength(25);

            Property(p => p.Status)
                .HasMaxLength(100);

            Property(p => p.Klient)
                .HasMaxLength(100);

            Property(p => p.Cook)
                .HasMaxLength(100);

            Property(p => p.Zona)
                .HasMaxLength(10);

            Property(p => p.Before)
                .HasMaxLength(10);

            Property(p => p.OrderView)
                .HasMaxLength(100);

            Property(p => p.TimeStartCooking)
                .HasMaxLength(25);

            Property(p => p.TimeEndCooking)
                .HasMaxLength(25);

            Property(p => p.DateStartMaking)
                .HasMaxLength(25);

            Property(p => p.DateEndMaking)
                .HasMaxLength(25);

            Property(p => p.TimeDelivery)
                .HasMaxLength(25);

            Property(p => p.DateDelivery)
                .HasMaxLength(25);

            Property(p => p.Driver)
                .HasMaxLength(25);

            Property(p => p.CoordinateWidth)
                .HasMaxLength(100);

            Property(p => p.CoordinateLongitude)
                .HasMaxLength(100);

            Property(p => p.IsSushiDepartment)
                .HasMaxLength(10);

            Property(p => p.IsPizzaDepartment)
                .HasMaxLength(10);

            Property(p => p.IsCoolDepartment)
                .HasMaxLength(10);
        }

        #endregion
    }
}
