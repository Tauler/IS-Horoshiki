using System;
using System.Linq;
using System.Linq.Expressions;

namespace IsHoroshiki.DAO.Helpers
{
    /// <summary>
    /// Хелпер сортировки
    /// </summary>
    public static class SortingHelper
    {
        /// <summary>
        /// Отсортировать по полю
        /// </summary>
        /// <typeparam name="T">Тип</typeparam>
        /// <param name="query">запрос</param>
        /// <param name="sortField">Поле для сортировки</param>
        /// <param name="isAscending">true - сортировать по возрастанию</param>
        /// <returns></returns>
        public static IQueryable<T> OrderByPropertyName<T>(this IQueryable<T> query, string sortField, bool isAscending)
        {
            if (string.IsNullOrEmpty(sortField))
            {
                return query;
            }

            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, sortField);
            var exp = Expression.Lambda(prop, param);
            string method = isAscending ? "OrderBy" : "OrderByDescending";
            Type[] types = new Type[] { query.ElementType, exp.Body.Type };
            var rs = Expression.Call(typeof(Queryable), method, types, query.Expression, exp);
            return query.Provider.CreateQuery<T>(rs);
        }
    }
}
