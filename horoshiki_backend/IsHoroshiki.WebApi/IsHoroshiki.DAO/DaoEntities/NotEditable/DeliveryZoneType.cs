namespace IsHoroshiki.DAO.DaoEntities.NotEditable
{
    /// <summary>
    /// Типы зон доставки
    /// </summary>
    public class DeliveryZoneType : BaseNotEditableDaoEntity
    {
        /// <summary>
        /// Время доставки в указанную зону в минутах
        /// </summary>
        public int Time
        {
            get;
            set;
        }

        /// <summary>
        /// Цвет заливки 
        /// </summary>
        public string Background
        {
            get;
            set;
        }

        /// <summary>
        /// Прозрачность заливки 
        /// </summary>
        public float Opacity
        {
            get;
            set;
        }

        /// <summary>
        /// Цвет контура 
        /// </summary>
        public string BorderColor
        {
            get;
            set;
        }

        /// <summary>
        /// ZIndex
        /// </summary>
        public int ZIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Приоритет
        /// </summary>
        public int Priority
        {
            get;
            set;
        }
    }
}
