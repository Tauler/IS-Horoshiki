using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.BusinessEntities.NotEditable.MappingDao;
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
        public static SubDivision ToDaoEntity(this SubDivisionModel model)
        {
            return new SubDivision()
            {
                Id = model.Id,
                Name = model.Name,
                Timezone = model.Timezone,
                PriceType = model.PriceTypeModel != null ? model.PriceTypeModel.ToDaoEntity() : null,
                SiteHeader = model.SiteHeader
            };
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<SubDivision> ToDaoEntityList(this IEnumerable<SubDivisionModel> models)
        {
            return models.Select(model => model.ToDaoEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static SubDivisionModel ToModelEntity(this SubDivision model)
        {
            return new SubDivisionModel()
            {
                Id = model.Id,
                Name = model.Name,
                Timezone = model.Timezone,
                PriceTypeModel = model.PriceType != null ? model.PriceType.ToModelEntity() : null,
                SiteHeader = model.SiteHeader
            };
        }

        /// <summary>
        /// DAO в модель
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<SubDivisionModel> ToModelEntityList(this IEnumerable<SubDivision> models)
        {
            return models.Select(model => model.ToModelEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="daoModel"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static SubDivision Update(this SubDivision daoModel, SubDivisionModel model)
        {
            daoModel.Id = model.Id;
            daoModel.Name = model.Name;
            daoModel.Timezone = model.Timezone;
            daoModel.PriceType = model.PriceTypeModel?.ToDaoEntity();
            daoModel.SiteHeader = model.SiteHeader;

            return daoModel;
        }
    }
}
