using System.Collections.Generic;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces
{
    /// <summary>
    /// Базовый сервис нередактируемый тип справочника
    /// </summary>
    public interface IBaseNotEditableDictionaryService<TBaseBusninessModel> : IBaseBusinessService
        where TBaseBusninessModel : IBaseNotEditableDictionaryModel
    {
        #region методы

        /// <summary>
        /// Получить все сущности
        /// </summary>
        /// <returns></returns>
        IEnumerable<TBaseBusninessModel> GetAll();

        #endregion
    }
}
