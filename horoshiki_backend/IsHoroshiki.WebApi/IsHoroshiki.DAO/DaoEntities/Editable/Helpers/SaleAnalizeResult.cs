using System;

namespace IsHoroshiki.DAO.DaoEntities.Editable
{
    /// <summary>
    /// Зона доставки
    /// </summary>
    public class SaleAnalizeResult : BaseDaoEntity
    {
        /// <summary>
        /// Дата чека
        /// </summary>
        public DateTime DateDoc
        {
            get;
            set;
        }

        /// <summary>
        /// Доставка
        /// </summary>
        public int Delivery
        {
            get;
            set;
        }

        /// <summary>
        /// Cамовывоз
        /// </summary>
        public int Self
        {
            get;
            set;
        }
    }
}
