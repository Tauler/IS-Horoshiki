using System.Collections.Generic;
using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.DAO.DaoEntities.NotEditable
{
    /// <summary>
    /// Способы покупки
    /// </summary>
    public class BuyProcess : BaseNotEditableDaoEntity
    {
        /// <summary>
        /// Платформа
        /// </summary>
        public ICollection<Platform> Platforms
        {
            get;
            set;
        }
    }
}
