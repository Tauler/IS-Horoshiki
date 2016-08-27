using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessEntities
{
    /// <summary>
    /// Базовая сущность для всех сущностей в сервисе
    /// </summary>
    public abstract class BaseBusninessModel : IBaseBusninessModel
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
