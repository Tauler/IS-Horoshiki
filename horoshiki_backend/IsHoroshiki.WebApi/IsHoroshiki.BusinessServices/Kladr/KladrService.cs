using IsHoroshiki.BusinessEntities.Kladr;
using IsHoroshiki.BusinessServices.Kladr.Enums;
using IsHoroshiki.DAO.Kladr.Repositories.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using IsHoroshiki.BusinessEntities.Kladr.MappingDao;

namespace IsHoroshiki.BusinessServices.Kladr
{
    /// <summary>
    /// Сервис Записи с объектами седьмого уровня классификации (номера квартир домов);
    /// </summary>
    public class KladrService : BaseKladrBusinessService<DAO.Kladr.DaoEntities.Kladr, IKladrRepository>, IKladrService
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="validator">Валидатор</param>
        public KladrService(KladrUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.KladrRepository)
        {

        }

        #endregion

        #region IKladrService

        /// <summary>
        /// Получить все записи
        /// </summary>
        /// <param name="contentType">Тип искомого объекта (область, район и т.п.)</param>
        /// <param name="query">Наименование объекта в запросе</param>
        /// <param name="regionId">Id объекта в запросе</param>
        /// <param name="withParent">true - если необходимо вернуть родительскте записи для данного объекта</param>
        /// <param name="limit">Максимальное количество записей в ответе</param>
        /// <returns></returns>
        public async Task<IEnumerable<KladrResultModel>> Get(string contentType, string query, string regionId, bool withParent = false, int limit = 10)
        {
            if (IsMatchContentType(contentType, ContentType.Region))
            {
                var regions = await this._unitOfWork.KladrRepository.GetRegionAllAsync(query, limit);

                return regions.ToModelEntityList(ContentType.Region);
            }
            else if (IsMatchContentType(contentType, ContentType.District))
            {
                var districts = await this._unitOfWork.KladrRepository.GetDistrictAllAsync(query, regionId, withParent, limit);
                return districts.ToModelEntityList(ContentType.District);
            }
            else if (IsMatchContentType(contentType, ContentType.City))
            {
                var citys = await this._unitOfWork.KladrRepository.GetCityAllAsync(query, regionId, withParent, limit);
                return citys.ToModelEntityList(ContentType.City);
            }
            //else if (IsMatchContentType(contentType, ContentType.Street))
            //{
            //    var streets = await this._unitOfWork.StreetRepository.GetAllAsync(query, regionId, withParent, limit);
            //}
            //else if (IsMatchContentType(contentType, ContentType.House))
            //{
            //    var houses = await this._unitOfWork.DomaRepository.GetAllAsync(query, regionId, withParent, limit);
            //}
            else
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region private

        /// <summary>
        /// true - если строкой значение соответствует значению перечня
        /// </summary>
        /// <param name="contentType">Строковое значение</param>
        /// <param name="enumContentType">Значение перечня</param>
        /// <returns></returns>
        private bool IsMatchContentType(string contentType, ContentType enumContentType)
        {
            if (string.IsNullOrEmpty(contentType))
            {
                throw new ArgumentNullException();
            }

            return string.Equals(contentType, enumContentType.ToString(), StringComparison.OrdinalIgnoreCase);
        }

        #endregion
    }
}
