using IsHoroshiki.DAO;
using IsHoroshiki.DAO.DaoEntities.NotEditable;


namespace IsHoroshiki.DAO.DaoEntities.Editable
{
    /// <summary>
    /// Зона доставки
    /// </summary>
    public class DeliveryZone : BaseDaoEntity
    {
        /// <summary>
        /// Площадка
        /// </summary>
        public int PlatformId
        {
            get;
            set;
        }

        /// <summary>
        /// Площадка
        /// </summary>
        public Platform Platform
        {
            get;
            set;
        }
        
        /// <summary>
        /// Тип зоны
        /// </summary>
        public int DeliveryZoneTypeId
        {
            get;
            set;
        }

        /// <summary>
        /// Тип зоны
        /// </summary>
        public DeliveryZoneType DeliveryZoneType
        {
            get;
            set;
        }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Координаты зоны
        /// </summary>
        public byte[] Coordinates
        {
            get;
            set;
        }
    }
}
