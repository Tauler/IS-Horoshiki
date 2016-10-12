using IsHoroshiki.DAO;
using IsHoroshiki.DAO.DaoEntities.NotEditable;


namespace IsHoroshiki.BusinessEntities.Editable
{
    /// <summary>
    /// Зона доставки
    /// </summary>
    public class DeliveryZone : BaseDaoEntity
    {
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
