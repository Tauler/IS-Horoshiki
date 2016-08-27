using System;
using System.Collections.Generic;
using System.Linq;

namespace IsHoroshiki.BusinessServices.Helpers
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
                throw new ArgumentNullException(arg);
            }
        }

        /// <summary>
        /// Все сообщения об ошибках
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static string GetAllMessages(this Exception exception)
        {
            var messages = exception.FromHierarchy(ex => ex.InnerException)
                .Select(ex => ex.Message);

            return String.Join(Environment.NewLine, messages);
        }

        /// <summary>
        /// Все сообщения об ошибках валидации
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static string GetAllMessages(this ModelEntityModifyResult result)
        {
            var messages = result.ValidationErrors;

            return String.Join(Environment.NewLine, messages);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="nextItem"></param>
        /// <param name="canContinue"></param>
        /// <returns></returns>
        private static IEnumerable<TSource> FromHierarchy<TSource>(this TSource source, Func<TSource, TSource> nextItem, Func<TSource, bool> canContinue)
        {
            for (var current = source; canContinue(current); current = nextItem(current))
            {
                yield return current;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="nextItem"></param>
        /// <returns></returns>
        private static IEnumerable<TSource> FromHierarchy<TSource>(this TSource source, Func<TSource, TSource> nextItem)
            where TSource : class
        {
            return FromHierarchy(source, nextItem, s => s != null);
        }
    }
}
