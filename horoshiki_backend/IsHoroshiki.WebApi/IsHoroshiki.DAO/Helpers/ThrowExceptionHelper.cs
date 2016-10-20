using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.DAO.Helpers
{
    /// <summary>
    /// Хелпер вброса эксепшна
    /// </summary>
    public static class ThrowExceptionHelper
    {
        /// <summary>
        /// Вброс эксепшена, если пустая строка
        /// </summary>
        /// <param name="arg">Проверяемый аргумент</param>
        /// <param name="message">Сообщение</param>
        public static void ThrowIfNull(this string arg, string message = "")
        {
            if (string.IsNullOrEmpty(arg))
            {
                throw new ArgumentNullException(message);
            }
        }
    }
}
