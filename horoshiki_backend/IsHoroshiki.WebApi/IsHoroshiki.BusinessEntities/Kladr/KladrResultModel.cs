using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Kladr
{
    /// <summary>
    /// Результат поиска по КЛАДР
    /// </summary>
    public class KladrResultModel
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
        /// Id объекта в запросе
        /// </summary>
        public string Id
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
        /// OKATO
        /// </summary>
        public string OKATO
        {
            get;
            set;
        }

        /// <summary>
        /// Тип объекта
        /// </summary>
        public string Type
        {
            get;
            set;
        }

        /// <summary>
        /// Тип объекта в сокращенной форме
        /// </summary>
        public string TypeShort
        {
            get;
            set;
        }

        /// <summary>
        /// Индекс объекта
        /// </summary>
        public string Index
        {
            get;
            set;
        }

        /// <summary>
        /// Родельские записи, если необходимы
        /// </summary>
        public IEnumerable<KladrResultModel> Parents
        {
            get;
            set;
        }
    }
}
