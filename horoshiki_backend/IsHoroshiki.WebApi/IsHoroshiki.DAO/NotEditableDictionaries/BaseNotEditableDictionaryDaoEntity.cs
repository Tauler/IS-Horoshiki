using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.DAO.NotEditableDictionaries
{
    /// <summary>
    /// Базовый нередактируемый тип справочника
    /// </summary>
    public abstract class BaseNotEditableDictionaryDaoEntity : BaseDaoEntity
    {
        /// <summary>
        /// Id в БД
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Значение
        /// </summary>
        public string Value
        {
            get;
            set;
        }
    }
}
