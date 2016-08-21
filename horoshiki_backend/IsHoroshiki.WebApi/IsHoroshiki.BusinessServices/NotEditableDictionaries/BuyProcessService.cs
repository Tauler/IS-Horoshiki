using System;
using System.Collections.Generic;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.MappingDao;
using IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;

namespace IsHoroshiki.BusinessServices.NotEditableDictionaries
{
    /// <summary>
    /// Сервис Способы покупки
    /// </summary>
    public class BuyProcessService : BaseNotEditableDictionaryService<BuyProcessModel>, IBuyProcessService
    {
        #region IBuyProcessService

        /// <summary>
        /// Получить все сущности
        /// </summary>
        public override IEnumerable<IBaseNotEditableDictionaryModel> GetAll()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                return unitOfWork.BuyProcessPepository.GetAll().ToModelEntityList();
            }
        }

        #endregion
    }
}
