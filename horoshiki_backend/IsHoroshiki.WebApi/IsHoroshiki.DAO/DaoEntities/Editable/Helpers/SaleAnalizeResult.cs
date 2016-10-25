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
        /// Способ покупки
        /// </summary>
        public int? BuyProcessId
        {
            get;
            set;
        }

        /// <summary>
        /// Кол-во чеков на этот день
        /// </summary>
        public int CountCheck
        {
            get;
            set;
        }
    }
}
