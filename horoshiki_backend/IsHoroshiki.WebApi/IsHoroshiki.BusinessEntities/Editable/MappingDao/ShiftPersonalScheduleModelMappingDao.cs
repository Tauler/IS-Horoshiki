using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules;
using IsHoroshiki.BusinessEntities.Account.MappingDao;
using IsHoroshiki.BusinessEntities.NotEditable.MappingDao;

namespace IsHoroshiki.BusinessEntities.Editable.MappingDao
{
    /// <summary>
    /// Меппинг полей сущности DAO на бизнес-сущность
    /// </summary>
    public static class ShiftPersonalScheduleModelMappingDao
    {
        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ShiftPersonalSchedule ToDaoEntity(this IShiftPersonalScheduleModel model)
        {
            return new ShiftPersonalSchedule()
            {
                Id = model.Id,
                User = model.User != null ? model.User.ToDaoEntity() : null,
                ShiftType = model.ShiftType != null ? model.ShiftType.ToDaoEntity() : null,
                ShiftPersonalSchedulePeriods = model.ShiftPersonalSchedulePeriods != null ? model.ShiftPersonalSchedulePeriods.ToDaoEntityList().ToList() : null,
                Date = model.Date
            };
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<ShiftPersonalSchedule> ToDaoEntityList(this IEnumerable<IShiftPersonalScheduleModel> models)
        {
            return models.Select(model => model.ToDaoEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IShiftPersonalScheduleModel ToModelEntity(this ShiftPersonalSchedule model)
        {
            return new ShiftPersonalScheduleModel()
            {
                Id = model.Id,
                User = model.User != null ? model.User.ToModelEntity() : null,
                ShiftType = model.ShiftType != null ? model.ShiftType.ToModelEntity() : null,
                ShiftPersonalSchedulePeriods = model.ShiftPersonalSchedulePeriods != null ? model.ShiftPersonalSchedulePeriods.ToModelEntityList().ToList() : null,
                Date = model.Date
            };
        }

        /// <summary>
        /// DAO в модель
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<IShiftPersonalScheduleModel> ToModelEntityList(this IEnumerable<ShiftPersonalSchedule> models)
        {
            return models.Select(model => model.ToModelEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="daoModel"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ShiftPersonalSchedule Update(this ShiftPersonalSchedule daoModel, IShiftPersonalScheduleModel model)
        {
            daoModel.Id = model.Id;
            daoModel.Date = model.Date;
            daoModel.ShiftTypeId = model.ShiftType != null ? model.ShiftType.Id : 0;
            daoModel.UserId = model.User != null ? model.User.Id : 0;
            daoModel.ShiftPersonalSchedulePeriods = model.ShiftPersonalSchedulePeriods != null ? model.ShiftPersonalSchedulePeriods.ToDaoEntityList().ToList() : null;

            return daoModel;
        }
    }
}
