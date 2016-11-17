using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.DAO.Helpers
{
    /// <summary>
    /// Хелпер работы со строками
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Удаление пробелов в строке
        /// </summary>
        /// <param name="s">Строка</param>
        /// <returns></returns>
        public static string TrimProbel(this string s)
        {
            if (s == null)
            {
                return s;
            }

            return s.Replace(" ", "");
        }
    }
}
