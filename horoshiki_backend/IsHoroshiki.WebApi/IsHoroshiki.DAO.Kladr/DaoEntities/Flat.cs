using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.DAO.Kladr.DaoEntities
{
    /// <summary>
    /// Записи с объектами седьмого уровня классификации (номера квартир домов);
    /// </summary>
    public class Flat : BaseDaoEntity
    {
        /// <summary>
        /// Номера квартир (в виде списка и/или диапазонов)
        /// </summary>
        public string Name
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
        /// Номер подъезда дома
        /// </summary>
        public string NP
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
    }
}
