using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.BusinessEntities.Account.MappingDao;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditable.MappingDao;
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
        /// <param name="isLoadChild">Конвертировать дочерние объекты</param>
        /// <returns></returns>
        public static PlatformModel ToModelEntity(this Platform model, bool isLoadChild = true)
        {
            return new PlatformModel()
            {
                Id = model.Id,
                Name = model.Name,
                SubDivision = model.SubDivision != null ? model.SubDivision.ToModelEntity() : null,
                User = isLoadChild && model.User != null ? model.User.ToModelEntity(false) : null,
                PlatformStatus = model.PlatformStatus != null ? model.PlatformStatus.ToModelEntity() : null,
                BuyProcesses = model.BuyProcesses != null ? model.BuyProcesses.ToModelEntityList() : null,
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
        /// <param name="isLoadChild">Конвертировать дочерние объекты</param>
        /// <returns></returns>
        public static IEnumerable<IPlatformModel> ToModelEntityList(this IEnumerable<Platform> models, bool isLoadChild = true)
        {
            return models.Select(m => ToModelEntity(m, isLoadChild));
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
          //  daoModel.SubDivision = model.SubDivision != null ? model.SubDivision.ToDaoEntity() : null;
            daoModel.SubDivisionId = model.SubDivision != null ? model.SubDivision.Id : 0;

            if (model.User != null && model.User.Id > 0)
            {
                //daoModel.User = model.User.ToDaoEntity();
                daoModel.UserId = model.User.Id;
            }
            else
            {
                daoModel.User = null;
                daoModel.UserId = null;
            }

          //  daoModel.PlatformStatus = model.PlatformStatus != null ? model.PlatformStatus.ToDaoEntity() : null;
            daoModel.PlatformStatusId = model.PlatformStatus != null ? model.PlatformStatus.Id : 0;
           // daoModel.BuyProcesses = model.BuyProcesses != null ? model.BuyProcesses.ToDaoEntityList() : null;
            daoModel.YandexMap = model.YandexMap;
            daoModel.Address = model.Address;
            daoModel.TimeStart = model.TimeStart;
            daoModel.TimeEnd = model.TimeEnd;
            daoModel.MinCheck = model.MinCheck;

            return daoModel;
        }
    }
}
