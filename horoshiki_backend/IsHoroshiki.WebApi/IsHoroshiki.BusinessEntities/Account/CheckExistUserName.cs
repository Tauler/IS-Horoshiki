using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessEntities.Account
{
    /// <summary>
    /// Проверка сещуствования пользваотеля по логину
    /// </summary>
    public class CheckExistUserName
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string UserName
        {
            get;
            set;
        }
    }
}
