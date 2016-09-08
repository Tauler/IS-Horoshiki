using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.DAO.Kladr.DaoEntities
{
    /// <summary>
    /// Записи с краткими наименованиями типов адресных объектов
    /// </summary>
    public class Socrbase : BaseDaoEntity
    {
        /// <summary>
        /// Уровень объекта данного типа
        /// </summary>
        public string Level
        {
            get;
            set;
        }

        /// <summary>
        /// Сокращенное наименование типа объекта
        /// </summary>
        public string ScName
        {
            get;
            set;
        }

        /// <summary>
        /// Сокращенное наименование типа объекта
        /// </summary>
        public string SocrName
        {
            get;
            set;
        }

        /// <summary>
        /// Код типа объекта
        /// </summary>
        public string Kod_T_ST
        {
            get;
            set;
        }
    }
}
