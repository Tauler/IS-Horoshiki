using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.DAO.Kladr.DaoEntities
{
    /// <summary>
    /// Сведения о соответствии кодов записей со старыми и новыми наименованиями адресных объектов, 
    /// а также сведения о соответствии кодов адресных объектов до и после их переподчинения
    /// </summary>
    public class AltName : BaseDaoEntity
    {
        /// <summary>
        /// Старый код
        /// </summary>
        public string OldCode
        {
            get;
            set;
        }

        /// <summary>
        /// Новый код
        /// </summary>
        public string NewCode
        {
            get;
            set;
        }

        /// <summary>
        /// Уровень объекта
        /// </summary>
        public string Level
        {
            get;
            set;
        }
    }
}
