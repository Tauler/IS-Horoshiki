using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.BusinessEntities.Editable.SalePlans;
using System.Globalization;

namespace IsHoroshiki.BusinessEntities.Editable.MappingDao
{
    /// <summary>
    /// Меппинг полей сущности DAO на бизнес-сущность
    /// </summary>
    public static class SalePlanDayMappingDao
    {
        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static SalePlanDay ToDaoEntity(this ISalePlanDayModel model)
        {
            return new SalePlanDay()
            {
                Id = model.Id,
                Date = model.Date,
                Delivery = model.Delivery,
                Self = model.Self
            };
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<SalePlanDay> ToDaoEntityList(this IEnumerable<ISalePlanDayModel> models)
        {
            return models.Select(model => model.ToDaoEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ISalePlanDayModel ToModelEntity(this SalePlanDay model)
        {
            return new SalePlanDayModel()
            {
                Id = model.Id,
                Date = model.Date,
                Delivery = model.Delivery,
                Self = model.Self,
                DayOfWeek = model.Date.DayOfWeek,
                DayOfWeekDescr = model.Date.ToString("ddd", new CultureInfo("ru-Ru")),
            };
        }

        /// <summary>
        /// DAO в модель
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<ISalePlanDayModel> ToModelEntityList(this IEnumerable<SalePlanDay> models)
        {
            return models.Select(model => model.ToModelEntity());
        }        
    }
}
