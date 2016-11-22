using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Editable.Interfaces
{
    /// <summary>
    /// Сервис Планирования графика работы сотрудников на период
    /// </summary>
    public interface IShiftPersonalScheduleService : IBaseEditableService<IShiftPersonalScheduleModel>
    {
        /// <summary>
        /// Таблица Планирования графика работы сотрудников на период
        /// </summary>
        /// <param name="model"> Планирования графика работы сотрудников на период</param>
        /// <returns></returns>
        Task<IShiftPersonalScheduleTableModel> GetTable(IShiftPersonalScheduleDataModel model);

        /// <summary>
        /// Планирование смен сотрудника на определенный день
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ModelEntityModifyResult> UpdateCell(IShiftPersonalScheduleUpdateModel model);

        /// <summary>
        /// Получение норма часов за период для пользователя
        /// </summary>
        /// <param name="model">Модель запроса норма часов за период для пользователя</param>
        /// <returns></returns>
        Task<int> NormaHour(IShiftPersonalScheduleNormaHourModel model);
    }
}
