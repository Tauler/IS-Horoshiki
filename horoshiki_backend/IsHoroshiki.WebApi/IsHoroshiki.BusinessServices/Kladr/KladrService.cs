using IsHoroshiki.BusinessEntities.Kladr;
using IsHoroshiki.BusinessServices.Kladr.Enums;
using IsHoroshiki.DAO.Kladr.Repositories.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using IsHoroshiki.BusinessEntities.Kladr.MappingDao;
using System.Linq;
using IsHoroshiki.DAO.Kladr.DaoEntities;

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
                var regions = new List<DAO.Kladr.DaoEntities.Kladr>();

                if(regionId.Length == 13)
                {
                    var daoDistrict = await this._unitOfWork.KladrRepository.GetByCode(regionId);
                    if (daoDistrict != null)
                    {
                        regions.Add(daoDistrict);
                    }
                }
                else
                {
                    var resultQury = await this._unitOfWork.KladrRepository.GetRegionAllAsync(query, limit);
                    regions.AddRange(resultQury);
                }

                return regions.ToModelEntityList(ContentType.Region);
            }
            else if (IsMatchContentType(contentType, ContentType.District))
            {
                var districts = new List<DAO.Kladr.DaoEntities.Kladr>();

                if (regionId.Length == 13)
                {
                    var daoDistrict = await this._unitOfWork.KladrRepository.GetByCode(regionId);
                    if (daoDistrict != null)
                    {
                        districts.Add(daoDistrict);
                    }
                }
                else
                {
                    var resultQury = await this._unitOfWork.KladrRepository.GetDistrictAllAsync(query, regionId, withParent, limit);
                    districts.AddRange(resultQury);
                }

                var result = districts.ToModelEntityList(ContentType.District).ToList();

                if (withParent)
                {
                    foreach (var district in result)
                    {
                        await FillParentForDistrict(district, district.Parents);
                    }
                }

                return result;

            }
            else if (IsMatchContentType(contentType, ContentType.City))
            {
                IEnumerable<DAO.Kladr.DaoEntities.Kladr> citys = new List<DAO.Kladr.DaoEntities.Kladr>();

                //пришел код города
                if (regionId.Length == 13)
                {
                    var daoCity = await this._unitOfWork.KladrRepository.GetByCode(regionId);
                    if (daoCity != null)
                    {
                        ((List<DAO.Kladr.DaoEntities.Kladr>)citys).Add(daoCity);
                    }
                }
                else
                {
                    if (regionId.EndsWith("00000000000"))
                    {
                        citys = await this._unitOfWork.KladrRepository.GetCityAllByRegionAsync(query, regionId, withParent, limit);
                    }
                    else
                    {
                        citys = await this._unitOfWork.KladrRepository.GetCityAllByDistrictAsync(query, regionId, withParent, limit);
                    }
                }

                var result = citys.ToModelEntityList(ContentType.City).ToList();

                if (withParent)
                {
                    foreach (var city in result)
                    {
                        await FillParentForCity(city, city.Parents);
                    }
                }

                return result;
            }
            else if (IsMatchContentType(contentType, ContentType.Street))
            {
                var streets = new List<Street>();

                //пришел код улицы
                if (regionId.Length == 17)
                {
                    var daoStreet = await this._unitOfWork.StreetRepository.GetByCode(regionId);
                    if (daoStreet != null)
                    {
                        streets.Add(daoStreet);
                    }
                }
                else
                {
                    var resultQury = await this._unitOfWork.StreetRepository.GetAllAsync(query, regionId, withParent, limit);
                    streets.AddRange(resultQury);
                }

                var result = streets.ToModelEntityList(ContentType.Street).ToList();

                if (withParent)
                {
                    foreach (var street in result)
                    {
                        await FillParentForStreet(street, street.Parents);
                    }
                }

                return result;
            }
            else if (IsMatchContentType(contentType, ContentType.House))
            {
                var houses = new List<Doma>();
                //пришел код дома
                if (regionId.Length == 19)
                {
                    var daoHouse = await this._unitOfWork.DomaRepository.GetByCode(regionId);
                    if (daoHouse != null)
                    {
                        houses.Add(daoHouse);
                    }
                }
                else
                {
                    var resultQury = await this._unitOfWork.DomaRepository.GetAllAsync(query, regionId, withParent, limit);
                    houses.AddRange(resultQury);
                }
                var result = houses.ToModelEntityList(ContentType.House).ToList();

                if (withParent)
                {
                    foreach (var street in result)
                    {
                        await FillParentForHouse(street, street.Parents);
                    }
                }

                return result;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Заполнить роделями для дома
        /// </summary>
        /// <param name="city">Модель города</param>
        /// <param name="result">Список</param>
        /// <returns></returns>
        private async Task FillParentForHouse(KladrResultModel house, List<KladrResultModel> result)
        {
            if (house == null)
            {
                return;
            }

            var streetCode = house.Id.Substring(0, 17);

            var daoStreet = await this._unitOfWork.StreetRepository.GetByCode(streetCode);
            if (daoStreet != null)
            {
                var streetModel = daoStreet.ToModelEntity(ContentType.Street);
                if (streetModel != null)
                {
                    result.Add(streetModel);
                    await FillParentForStreet(streetModel, result);
                }
            }
        }

        /// <summary>
        /// Заполнить роделями для улицы
        /// </summary>
        /// <param name="city">Модель города</param>
        /// <param name="result">Список</param>
        /// <returns></returns>
        private async Task FillParentForStreet(KladrResultModel street, List<KladrResultModel> result)
        {
            if (street == null)
            {
                return;
            }

            var cityCode = street.Id.EndsWith("000000") ?  street.Id.Substring(0, 8) + "000000" : street.Id.Substring(0, 11) + "00";

            var daoCity = await this._unitOfWork.KladrRepository.GetByCode(cityCode);
            if (daoCity != null)
            {
                var cityModel = daoCity.ToModelEntity(ContentType.City);
                if (cityModel != null)
                {
                    result.Add(cityModel);
                    await FillParentForCity(cityModel, result);
                }
            }
        }

        /// <summary>
        /// Заполнить роделями для города
        /// </summary>
        /// <param name="city">Модель города</param>
        /// <param name="result">Список</param>
        /// <returns></returns>
        private async Task FillParentForCity(KladrResultModel city, List<KladrResultModel> result)
        {
            if (city == null)
            {
                return;
            }

            var distrinctCode = city.Id.Substring(0, 5) + "00000000";

            var daoDistrict = await this._unitOfWork.KladrRepository.GetByCode(distrinctCode);
            if (daoDistrict != null)
            {
                var districtModel = daoDistrict.ToModelEntity(ContentType.District);
                if (districtModel != null)
                {
                    if (!districtModel.Id.EndsWith("00000000000"))
                    {
                        result.Add(districtModel);
                    }
                    await FillParentForDistrict(districtModel, result);
                }
            }
        }

        /// <summary>
        /// Заполнить родителя для района
        /// </summary>
        /// <param name="district">Модель района</param>
        /// <param name="result">Список</param>
        /// <returns></returns>
        private async Task FillParentForDistrict(KladrResultModel district, List<KladrResultModel> result)
        {
            if (district == null)
            {
                return;
            }

            var regionCode = district.Id.Substring(0, 2) + "00000000000";
            var daoRegion = await this._unitOfWork.KladrRepository.GetByCode(regionCode);
            if (daoRegion != null)
            {
                var regionModel = daoRegion.ToModelEntity(ContentType.Region);
                result.Add(regionModel);
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
