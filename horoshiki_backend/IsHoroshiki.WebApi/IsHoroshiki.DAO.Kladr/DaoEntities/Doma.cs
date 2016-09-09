using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.DAO.Kladr.DaoEntities
{
    /// <summary>
    /// Записи с объектами шестого уровня классификации (номера домов улиц городов и населенных пунктов);
    /// </summary>
    public class Doma : BaseDaoEntity
    {
        /// <summary>
        /// Номера домов, владений (в виде списка и/или диапазонов)
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Корпус дома
        /// </summary>
        public string Korp
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
    }
}
