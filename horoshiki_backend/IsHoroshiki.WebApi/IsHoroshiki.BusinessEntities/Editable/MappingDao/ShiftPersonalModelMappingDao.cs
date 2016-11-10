using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditable.MappingDao;
using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonals;

namespace IsHoroshiki.BusinessEntities.Editable.MappingDao
{
    /// <summary>
    /// Меппинг полей сущности DAO на бизнес-сущность
    /// </summary>
    public static class ShiftPersonalModelMappingDao
    {
        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ShiftPersonal ToDaoEntity(this IShiftPersonalModel model)
        {
            return new ShiftPersonal()
            {
                Id = model.Id,
                Position = model.Position != null ? model.Position.ToDaoEntity() : null,
                PositionId = model.Position != null ? model.Position.Id : 0,
                ShiftType = model.ShiftType != null ? model.ShiftType.ToDaoEntity() : null,
                ShiftTypeId = model.ShiftType != null ? model.ShiftType.Id : 0,
                StartTime = model.TimeStart,
                StopTime = model.TimeEnd,
                IsAroundClock = model.IsAroundClock
            };
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<ShiftPersonal> ToDaoEntityList(this IEnumerable<IShiftPersonalModel> models)
        {
            return models.Select(model => model.ToDaoEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IShiftPersonalModel ToModelEntity(this ShiftPersonal model)
        {
            return new ShiftPersonalModel()
            {
                Id = model.Id,
                Position = model.Position != null ? model.Position.ToModelEntity() : null,
                ShiftType = model.ShiftType != null ? model.ShiftType.ToModelEntity() : null,
                TimeStart = model.StartTime,
                TimeEnd = model.StopTime,
                IsAroundClock = model.IsAroundClock
            };
        }

        /// <summary>
        /// DAO в модель
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<IShiftPersonalModel> ToModelEntityList(this IEnumerable<ShiftPersonal> models)
        {
            return models.Select(model => model.ToModelEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="daoModel"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ShiftPersonal Update(this ShiftPersonal daoModel, IShiftPersonalModel model)
        {
            daoModel.Id = model.Id;
            daoModel.PositionId = model.Position?.Id ?? 0;
            daoModel.Position = model.Position?.ToDaoEntity();
            daoModel.ShiftTypeId = model.ShiftType?.Id ?? 0;
            daoModel.ShiftType = model.ShiftType?.ToDaoEntity();
            daoModel.StartTime = model.TimeStart;
            daoModel.StopTime = model.TimeEnd;
            daoModel.IsAroundClock = model.IsAroundClock;

            return daoModel;
        }
    }
}
