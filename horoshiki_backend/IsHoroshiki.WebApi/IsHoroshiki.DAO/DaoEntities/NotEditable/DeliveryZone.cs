namespace IsHoroshiki.DAO.DaoEntities.NotEditable
{
    /// <summary>
    /// Типы зон доставки
    /// </summary>
    public class DeliveryZone : BaseNotEditableDaoEntity
    {
        /// <summary>
        /// Время доставки в указанную зону в минутах
        /// </summary>
        public int Time
        {
            get;
            set;
        }
    }
}
