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
        Task<IEnumerable<IShiftPersonalModel>> GetTable();
    }
}
