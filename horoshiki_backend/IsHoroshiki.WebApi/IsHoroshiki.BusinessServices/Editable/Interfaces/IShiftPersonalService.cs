using IsHoroshiki.BusinessEntities.Editable.ShiftPersonals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Editable.Interfaces
{
    /// <summary>
    /// Сервис Смена
    /// </summary>
    public interface IShiftPersonalService : IBaseEditableService<IShiftPersonalModel>
    {
        /// <summary>
        /// Создать результатирующую таблицу с настройками смен работы
        /// </summary>
        /// <returns></returns>
        Task<IShiftPersonalTableModel> GetTable();

        /// <summary>
        /// Сохранение рабочего интервала времени
        /// </summary>
        /// <param name="model">Изменяемая часть смены</param>
        /// <returns></returns>
        Task<ModelEntityModifyResult> UpdateWorkingTime(IShiftPersonalTimePartModel model);
    }
}
