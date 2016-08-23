namespace IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries
{
    /// <summary>
    /// Типы зон доставки
    /// </summary>
    public class DeliveryZone : BaseNotEditableDictionaryDaoEntity
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
