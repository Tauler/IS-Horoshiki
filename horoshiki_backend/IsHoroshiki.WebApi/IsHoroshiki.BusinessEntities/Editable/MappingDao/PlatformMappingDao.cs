using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.BusinessEntities.Editable.MappingDao
{
    /// <summary>
    /// Меппинг полей сущности DAO на бизнес-сущность
    /// </summary>
    public static class PlatformModelMappingDao
    {
        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Platform ToDaoEntity(this IPlatformModel model)
        {
            var platform = new Platform();
            Update(platform, model);
            return platform;
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<Platform> ToDaoEntityList(this IEnumerable<IPlatformModel> models)
        {
            return models.Select(model => model.ToDaoEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PlatformModel ToModelEntity(this Platform model)
        {
            return new PlatformModel()
            {
                Id = model.Id,
                Name = model.Name,
                SubDivisionId = model.SubDivisionId,
                AccountId = model.UserId,
                PlatformStatusId = model.PlatformStatusId,
                BuyProcessesIds = model.BuyProcesses != null ? model.BuyProcesses.Select(bp => bp.Id).ToList() : null,
                YandexMap = model.YandexMap,
                Address = model.Address,
                TimeStart = model.TimeStart,
                TimeEnd = model.TimeEnd,
                MinCheck = model.MinCheck
            };
        }

        /// <summary>
        /// DAO в модель
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<IPlatformModel> ToModelEntityList(this IEnumerable<Platform> models)
        {
            return models.Select(model => model.ToModelEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="daoModel"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Platform Update(this Platform daoModel, IPlatformModel model)
        {
            daoModel.Id = model.Id;
            daoModel.Name = model.Name;
            daoModel.SubDivisionId = model.SubDivisionId;
            daoModel.UserId = model.AccountId;
            daoModel.PlatformStatusId = model.PlatformStatusId;
            daoModel.BuyProcessesIds = model.BuyProcessesIds;
            daoModel.YandexMap = model.YandexMap;
            daoModel.Address = model.Address;
            daoModel.TimeStart = model.TimeStart;
            daoModel.TimeEnd = model.TimeEnd;
            daoModel.MinCheck = model.MinCheck;

            return daoModel;
        }
    }
}
