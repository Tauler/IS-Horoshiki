using System.Collections.Generic;
using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;

namespace IsHoroshiki.BusinessServices
{
    /// <summary>
    /// Базовый сервис нередактируемый тип справочника
    /// </summary>
    public interface IBaseNotEditableService<TBaseBusninessModel> : IBaseBusinessService<TBaseBusninessModel>
        where TBaseBusninessModel : IBaseNotEditableModel
    {
        
    }
}
