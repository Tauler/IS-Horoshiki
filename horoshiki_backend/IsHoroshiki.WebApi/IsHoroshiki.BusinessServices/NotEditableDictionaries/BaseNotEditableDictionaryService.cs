using System.Collections.Generic;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.Interfaces;
using IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.BusinessServices.NotEditableDictionaries
{
    /// <summary>
    /// Базовый сервис нередактируемый тип справочника
    /// </summary>
    public abstract class BaseNotEditableDictionaryService<TBaseBusninessModel> : BaseBusinessService, IBaseNotEditableDictionaryService<TBaseBusninessModel>
        where TBaseBusninessModel : IBaseNotEditableDictionaryModel
    {
        #region методы

        /// <summary>
        /// Получить все сущности
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<IBaseNotEditableDictionaryModel> GetAll();

        #endregion
    }
}
