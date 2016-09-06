using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.BusinessEntities.Editable.MappingDao
{
    /// <summary>
    /// Меппинг полей сущности DAO на бизнес-сущность
    /// </summary>
    public static class SubDivisionModelMappingDao
    {
        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static SubDivision ToDaoEntity(this ISubDivisionModel model)
        {
            return new SubDivision()
            {
                Id = model.Id,
                Name = model.Name,
                Timezone = model.Timezone,
                PriceTypeId = model.PriceTypeId,
                SiteHeader = model.SiteHeader
            };
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<SubDivision> ToDaoEntityList(this IEnumerable<ISubDivisionModel> models)
        {
            return models.Select(model => model.ToDaoEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ISubDivisionModel ToModelEntity(this SubDivision model)
        {
            return new SubDivisionModel()
            {
                Id = model.Id,
                Name = model.Name,
                Timezone = model.Timezone,
                PriceTypeId = model.PriceTypeId,
                SiteHeader = model.SiteHeader
            };
        }

        /// <summary>
        /// DAO в модель
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<ISubDivisionModel> ToModelEntityList(this IEnumerable<SubDivision> models)
        {
            return models.Select(model => model.ToModelEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="daoModel"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static SubDivision Update(this SubDivision daoModel, ISubDivisionModel model)
        {
            daoModel.Id = model.Id;
            daoModel.Name = model.Name;
            daoModel.Timezone = model.Timezone;
            daoModel.PriceTypeId = model.PriceTypeId;
            daoModel.SiteHeader = model.SiteHeader;

            return daoModel;
        }
    }
}
