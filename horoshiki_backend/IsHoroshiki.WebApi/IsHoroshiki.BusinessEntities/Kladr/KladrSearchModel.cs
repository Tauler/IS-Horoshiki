using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessEntities.Kladr
{
    /// <summary>
    /// Поиск в кладре по коду
    /// </summary>
    public class KladrSearchModel
    {
        /// <summary>
        /// Тип искомого объекта (область, район и т.п.)
        /// </summary>
        public string ContentType
        {
            get;
            set;
        }

        /// <summary>
        /// Максимальное количество записей в ответе
        /// </summary>
        public int Limit
        {
            get;
            set;
        }

        /// <summary>
        /// Наименование объекта в запросе
        /// </summary>
        public string Query
        {
            get;
            set;
        }

        /// <summary>
        /// Id объекта в запросе
        /// </summary>
        public string RegionId
        {
            get;
            set;
        }

        /// <summary>
        /// true - если необходимо вернуть родительскте записи для данного объекта
        /// </summary>
        public bool WithParent
        {
            get;
            set;
        }
    }
}
