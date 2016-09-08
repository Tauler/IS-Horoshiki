using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.DAO.Kladr.DaoEntities
{
    /// <summary>
    /// Записи с объектами первых четырех уровней классификации (регионы; районы (улусы); 
    /// города, поселки городского типа, сельсоветы; сельские населенные пункты);
    /// </summary>
    public class Kladr : BaseDaoEntity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Сокращенное наименование типа объекта
        /// </summary>
        public string Socr
        {
            get;
            set;
        }

        /// <summary>
        /// Код
        /// </summary>
        public string Code
        {
            get;
            set;
        }

        /// <summary>
        /// Почтовый индекс
        /// </summary>
        public string Index
        {
            get;
            set;
        }

        /// <summary>
        /// Код ИФНС
        /// </summary>
        public string GNINMB
        {
            get;
            set;
        }

        /// <summary>
        /// Код территориального участка ИФНС
        /// </summary>
        public string UNO
        {
            get;
            set;
        }

        /// <summary>
        /// Код ОКАТО 
        /// </summary>
        public string OCATD
        {
            get;
            set;
        }

        /// <summary>
        /// Статус объекта 
        /// </summary>
        public string Status
        {
            get;
            set;
        }
    }
}
