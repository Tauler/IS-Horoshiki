using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.DAO
{
    /// <summary>
    /// Базовая сущность для всех сущностей БД
    /// </summary>
    public abstract class BaseDaoEntity
    {
        /// <summary>
        /// Id в БД
        /// </summary>
        public int Id
        {
            get;
            set;
        }
    }
}
