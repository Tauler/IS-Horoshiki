//using System.Collections.Generic;
//using System.Linq;
//using IsHoroshiki.BusinessEntities.NotEditableDictionaries.Interfaces;
//using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;
//using IsHoroshiki.DAO.Identities;

//namespace IsHoroshiki.BusinessEntities.NotEditableDictionaries.MappingDao
//{
//    /// <summary>
//    /// Меппинг полей сущности DAO на бизнес-сущность
//    /// </summary>
//    public static class ApplicationUserModelMappingDao
//    {
//        /// <summary>
//        /// Модель в DAO
//        /// </summary>
//        /// <param name="model"></param>
//        /// <returns></returns>
//        public static ApplicationUser ToDaoEntity(this ApplicationUserModel model)
//        {
//            return new ApplicationUser()
//            {    
//                Id = model.Id,
//                Value = model.Value
//            };
//        }

//        /// <summary>
//        /// Модель в DAO
//        /// </summary>
//        /// <param name="models"></param>
//        /// <returns></returns>
//        public static IEnumerable<BuyProcess> ToDaoEntityList(this IEnumerable<IBuyProcessModel> models)
//        {
//            return models.Select(model => model.ToDaoEntity());
//        }

//        /// <summary>
//        /// Модель в DAO
//        /// </summary>
//        /// <param name="model"></param>
//        /// <returns></returns>
//        public static IBuyProcessModel ToModelEntity(this BuyProcess model)
//        {
//            return new BuyProcessModel()
//            {
//                Id = model.Id,
//                Value = model.Value
//            };
//        }

//        /// <summary>
//        /// DAO в модель
//        /// </summary>
//        /// <param name="models"></param>
//        /// <returns></returns>
//        public static IEnumerable<IBuyProcessModel> ToModelEntityList(this IEnumerable<BuyProcess> models)
//        {
//            return models.Select(model => model.ToModelEntity());
//        }
//    }
//}
