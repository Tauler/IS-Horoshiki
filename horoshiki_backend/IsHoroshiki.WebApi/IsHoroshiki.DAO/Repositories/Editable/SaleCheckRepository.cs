using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IsHoroshiki.DAO.Repositories.Editable
{
    /// <summary>
    /// Репозиторий Чек продаж
    /// </summary>
    public class SaleCheckRepository : BaseRepository<SaleCheck>, ISaleCheckRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public SaleCheckRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion

        #region ISaleCheckRepository

        /// <summary>
        /// Найти чек по его Id
        /// </summary>
        /// <param name="idCheck">Id чека</param>
        /// <returns></returns>
        public SaleCheck GetByCheckId(string idCheck)
        {
            return DbSet.FirstOrDefault(check => check.IdCheck == idCheck);
        }


        /// <summary>
        /// Получить отчет-анализ за период
        /// </summary>
        /// <param name="idPlatform">id Площадки</param>
        /// <param name="start">Дата начала</param>
        /// <param name="end">Дата окончания</param>
        /// <param name="isSushi">true - если суши</param>
        /// <returns></returns>
        public List<AnalizeResult> GetSaleCheckAnalize(int idPlatform, DateTime start, DateTime end, bool isSushi)
        {
            return Context.Database.SqlQuery<AnalizeResult>("exec SaleCheckAnalize @PlatformId, @DateBegin, @DateEnd, @IsSuchi", idPlatform, start, end, isSushi).ToList();
        }

        #endregion

        public class AnalizeResult
        {
            public DateTime DateDoc
            {
                get;
                set;
            }

            public int BuyProcessId
            {
                get;
                set;
            }

            public int CountCheck
            {
                get;
                set;
            }

            
        }

    }
}
