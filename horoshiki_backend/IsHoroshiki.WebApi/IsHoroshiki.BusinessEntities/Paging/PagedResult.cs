using System;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Paging
{
    /// <summary>
    /// Результат пейджинга
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedResult<T>
    {
        /// <summary>
        /// Информация о пейджинге
        /// </summary>
        public class PagingInfo
        {
            /// <summary>
            /// Номер страницы
            /// </summary>
            public int PageNo
            {
                get;
                set;
            }

            /// <summary>
            /// Размер страницы
            /// </summary>
            public int PageSize
            {
                get;
                set;
            }

            /// <summary>
            /// Количество объектов на странице
            /// </summary>
            public int PageCount
            {
                get;
                set;
            }

            /// <summary>
            /// Всегод записей
            /// </summary>
            public long TotalRecordCount
            {
                get;
                set;
            }
        }

        /// <summary>
        /// Список объектов
        /// </summary>
        public List<T> Data
        {
            get;
            private set;
        }

        /// <summary>
        /// Информация о пейдижнге
        /// </summary>
        public PagingInfo Paging
        {
            get;
            private set;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="items">Список объектов</param>
        /// <param name="pageNo">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="totalRecordCount">Всего объектов</param>
        public PagedResult(IEnumerable<T> items, int pageNo, int pageSize, long totalRecordCount)
        {
            Data = new List<T>(items);
            Paging = new PagingInfo
            {
                PageNo = pageNo,
                PageSize = pageSize,
                TotalRecordCount = totalRecordCount,
                PageCount = totalRecordCount > 0
                    ? (int)Math.Ceiling(totalRecordCount / (double)pageSize)
                    : 0
            };
        }
    }
}
