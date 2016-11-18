using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules;

namespace IsHoroshiki.BusinessEntities.Editable.MappingDao
{
    /// <summary>
    /// Меппинг полей сущности DAO на бизнес-сущность
    /// </summary>
    public static class ShiftPersonalSchedulePeriodModelMappingDao
    {
        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ShiftPersonalSchedulePeriod ToDaoEntity(this IShiftPersonalSchedulePeriodModel model)
        {
            return new ShiftPersonalSchedulePeriod()
            {
                Id = model.Id,
                ShiftPersonalSchedule = model.ShiftPersonalSchedule != null ? model.ShiftPersonalSchedule.ToDaoEntity() : null,
                StartTime = model.StartTime,
                StopTime = model.StopTime,
            };
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<ShiftPersonalSchedulePeriod> ToDaoEntityList(this IEnumerable<IShiftPersonalSchedulePeriodModel> models)
        {
            return models.Select(model => model.ToDaoEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IShiftPersonalSchedulePeriodModel ToModelEntity(this ShiftPersonalSchedulePeriod model)
        {
            return new ShiftPersonalSchedulePeriodModel()
            {
                Id = model.Id,
                ShiftPersonalSchedule = model.ShiftPersonalSchedule != null ? model.ShiftPersonalSchedule.ToModelEntity() : null,
                StartTime = model.StartTime,
                StopTime = model.StopTime,
            };
        }

        /// <summary>
        /// DAO в модель
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<IShiftPersonalSchedulePeriodModel> ToModelEntityList(this IEnumerable<ShiftPersonalSchedulePeriod> models)
        {
            return models.Select(model => model.ToModelEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="daoModel"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ShiftPersonalSchedulePeriod Update(this ShiftPersonalSchedulePeriod daoModel, IShiftPersonalSchedulePeriodModel model)
        {
            daoModel.Id = model.Id;
            daoModel.ShiftPersonalScheduleId = model.ShiftPersonalSchedule != null ? model.ShiftPersonalSchedule.Id : 0;
            daoModel.StartTime = model.StartTime;
            daoModel.StopTime = model.StopTime;

            return daoModel;
        }
    }
}
