using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.BusinessEntities.Editable.MappingDao
{
    /// <summary>
    /// Меппинг полей сущности DAO на бизнес-сущность
    /// </summary>
    public static class MonthObjectiveModelMappingDao
    {
        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static MonthObjective ToDaoEntity(this IMonthObjectiveModel model)
        {
            return new MonthObjective()
            {
                Id = model.Id,
                Platform = model.Platform != null ? model.Platform.ToDaoEntity() : null,
                PlatformId = model.Platform != null ? model.Platform.Id : 0,
                Year = model.Year,
                Month = model.Month,
                ChecksPerHourForPositionSushiChef = model.ChecksPerHourForPositionSushiChef,
                ChecksPerHourForPositionCourier = model.ChecksPerHourForPositionCourier,
                ChecksPerHourForPositionPizzaChef = model.ChecksPerHourForPositionPizzaChef
            };
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<MonthObjective> ToDaoEntityList(this IEnumerable<IMonthObjectiveModel> models)
        {
            return models.Select(model => model.ToDaoEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IMonthObjectiveModel ToModelEntity(this MonthObjective model)
        {
            return new MonthObjectiveModel()
            {
                Id = model.Id,
                Platform = model.Platform != null ? model.Platform.ToModelEntity() : null,
                Year = model.Year,
                Month = model.Month,
                ChecksPerHourForPositionSushiChef = model.ChecksPerHourForPositionSushiChef,
                ChecksPerHourForPositionCourier = model.ChecksPerHourForPositionCourier,
                ChecksPerHourForPositionPizzaChef = model.ChecksPerHourForPositionPizzaChef
            };
        }

        /// <summary>
        /// DAO в модель
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<IMonthObjectiveModel> ToModelEntityList(this IEnumerable<MonthObjective> models)
        {
            return models.Select(model => model.ToModelEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="daoModel"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static MonthObjective Update(this MonthObjective daoModel, IMonthObjectiveModel model)
        {
            daoModel.Id = model.Id;
            daoModel.PlatformId = model.Platform?.Id ?? 0;
            daoModel.Platform = model.Platform?.ToDaoEntity();
            daoModel.Year = model.Year;
            daoModel.Month = model.Month;
            daoModel.ChecksPerHourForPositionSushiChef = model.ChecksPerHourForPositionSushiChef;
            daoModel.ChecksPerHourForPositionCourier = model.ChecksPerHourForPositionCourier;
            daoModel.ChecksPerHourForPositionPizzaChef = model.ChecksPerHourForPositionPizzaChef;

            return daoModel;
        }
    }
}
