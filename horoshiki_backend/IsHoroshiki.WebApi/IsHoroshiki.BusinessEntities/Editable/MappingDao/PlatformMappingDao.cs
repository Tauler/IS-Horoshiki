using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.BusinessEntities.Account.MappingDao;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditable.MappingDao;
using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.DaoEntities.NotEditable;

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
                SubDivisionModel = model.SubDivision != null ? model.SubDivision.ToModelEntity() : null,
                UserModel = model.User != null ?model.User.ToUserModelEntity() : null,
                PlatformStatusModel = model.PlatformStatus != null ? model.PlatformStatus.ToModelEntity() : null,
                BuyProcessesModel = model.BuyProcesses != null ? model.BuyProcesses.ToModelEntityList() : null,
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
            daoModel.SubDivision = model.SubDivisionModel != null ? model.SubDivisionModel.ToDaoEntity() : null;
            daoModel.SubDivisionId = model.SubDivisionModel != null ? model.SubDivisionModel.Id : 0;
            daoModel.User = model.UserModel != null ? model.UserModel.ToDaoEntity() : null;
            daoModel.UserId = model.UserModel != null ? model.UserModel.Id : 0;
            daoModel.PlatformStatus = model.PlatformStatusModel != null ? model.PlatformStatusModel.ToDaoEntity() : null;
            daoModel.PlatformStatusId = model.PlatformStatusModel != null ? model.PlatformStatusModel.Id : 0;
            daoModel.BuyProcesses = model.BuyProcessesModel != null ? model.BuyProcessesModel.ToDaoEntityList() : null;
            daoModel.YandexMap = model.YandexMap;
            daoModel.Address = model.Address;
            daoModel.TimeStart = model.TimeStart;
            daoModel.TimeEnd = model.TimeEnd;
            daoModel.MinCheck = model.MinCheck;

            return daoModel;
        }
    }
}
