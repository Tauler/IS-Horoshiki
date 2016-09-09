using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Kladr
{
    /// <summary>
    /// Результат поиска по КЛАДР
    /// </summary>
    public class KladrResultModel
    {
        #region поля и свойства

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

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="contentType">Тип искомого объекта (область, район и т.п.)</param>
        /// <param name="id">Id объекта в запросе</param>
        /// <param name="name">Наименование</param>
        /// <param name="okato">OKATO</param>
        /// <param name="typeShort">Тип объекта в сокращенной форме</param>
        /// <param name="index">Индекс объекта</param>
        public KladrResultModel(string contentType, 
            string id,
            string index,
            string name, 
            string okato, 
            string typeShort)
        {
            ContentType = contentType;
            Id = id;
            Name = name;
            OKATO = okato;
            TypeShort = typeShort;
            Index = index;
        }

        #endregion
    }
}
