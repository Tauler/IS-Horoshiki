using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsHoroshiki.DAO.Kladr.DaoEntities;
using IsHoroshiki.DAO.Kladr.Repositories.Interfaces;

namespace IsHoroshiki.DAO.Kladr.Repositories
{
    /// <summary>
    /// Репозитарий Записи с объектами шестого уровня классификации (номера домов улиц городов и населенных пунктов);
    /// </summary>
    public class DomaRepository : BaseRepository<Doma>, IDomaRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public DomaRepository(KladrDbContext context)
            : base(context)
        {
            this.Context = context;
        }

        #endregion

        #region IDomaRepository

        /// <summary>
        /// Поиск дома по коду
        /// </summary>
        /// <param name="code">Код дома</param>
        /// <returns></returns>
        public async Task<Doma> GetByCode(string code)
        {
            return DbSet.FirstOrDefault(d => d.Code == code);
        }

        /// <summary>
        /// Получить все дома
        /// </summary>
        /// <param name="query">Наименование объекта в запросе</param>
        /// <param name="regionId">Id объекта в запросе</param>
        /// <param name="withParent">true - если необходимо вернуть родительскте записи для данного объекта</param>
        /// <param name="limit">Максимальное количество записей в ответе</param>
        /// <returns></returns>
        public async Task<IEnumerable<Doma>> GetAllAsync(string query, string regionId, bool withParent = false, int limit = 10)
        {
            var regionIdParam = GetParameter("regionId", regionId);
            var queryParam = GetParameter("query", query);
            var limitParam = GetParameter("limit", limit);

            var result = Context.Database.SqlQuery<DomaProcedureResult>("usp_get_build @regionId, @query, @limit", regionIdParam, queryParam, limitParam);

            return result != null ? result.Select(r => r.ConvertTo()).ToList().AsEnumerable() : new List<Doma>();
        }

        #endregion

        /// <summary>
        /// Результат выполнения ХП процедуры по поиску домов
        /// </summary>
        private class DomaProcedureResult : BaseDaoEntity
        {
            #region поля и свойства

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

            /// <summary>
            /// Номер дома
            /// </summary>
            public string Building
            {
                get;
                set;
            }

            /// <summary>
            /// Корпус
            /// </summary>
            public string Corpus
            {
                get;
                set;
            }

            /// <summary>
            /// Строение
            /// </summary>
            public string Construction
            {
                get;
                set;
            }

            #endregion

            #region методы

            /// <summary>
            /// Конфверитрование в объект ДАО
            /// </summary>
            /// <returns></returns>
            public Doma ConvertTo()
            {
                return new Doma
                {
                    Name = this.Building + this.Corpus + this.Construction,
                    Socr = this.Socr,
                    Code = this.Code,
                    Index = this.Index,
                    GNINMB = this.GNINMB,
                    UNO = this.UNO,
                    OCATD = this.OCATD
                };
            }

            #endregion
        }
    }
}
