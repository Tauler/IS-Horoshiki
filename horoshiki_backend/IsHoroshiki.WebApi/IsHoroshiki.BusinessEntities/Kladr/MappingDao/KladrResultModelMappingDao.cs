using IsHoroshiki.BusinessServices.Kladr.Enums;
using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.DAO.Kladr.DaoEntities;

namespace IsHoroshiki.BusinessEntities.Kladr.MappingDao
{
    /// <summary>
    /// Мепинг кладр на результат
    /// </summary>
    public static class KladrResultModelMappingDao
    {
        /// <summary>
        /// DAO в Модель
        /// </summary>
        /// <param name="model">DAO модель</param>
        /// <param name="contentType">Тип контента</param>
        /// <returns></returns>
        public static KladrResultModel ToModelEntity(this DAO.Kladr.DaoEntities.Kladr model, ContentType contentType)
        {
            return new KladrResultModel(contentType.ToString(), model.Code, model.Index, model.Name, model.OCATD, model.Socr);
        }

        /// <summary>
        /// DAO в Модель
        /// </summary>
        /// <param name="models">DAO модели</param>
        /// <param name="contentType">Тип контента</param>
        /// <returns></returns>
        public static IEnumerable<KladrResultModel> ToModelEntityList(this IEnumerable<DAO.Kladr.DaoEntities.Kladr> models, ContentType contentType)
        {
            return models.Select(m => m.ToModelEntity(contentType));
        }

        /// <summary>
        /// DAO в Модель
        /// </summary>
        /// <param name="model">DAO модель</param>
        /// <param name="contentType">Тип контента</param>
        /// <returns></returns>
        public static KladrResultModel ToModelEntity(this Street model, ContentType contentType)
        {
            return new KladrResultModel(contentType.ToString(), model.Code, model.Index, model.Name, model.OCATD, model.Socr);
        }

        /// <summary>
        /// DAO в Модель
        /// </summary>
        /// <param name="models">DAO модели</param>
        /// <param name="contentType">Тип контента</param>
        /// <returns></returns>
        public static IEnumerable<KladrResultModel> ToModelEntityList(this IEnumerable<Street> models, ContentType contentType)
        {
            return models.Select(m => m.ToModelEntity(contentType));
        }

        /// <summary>
        /// DAO в Модель
        /// </summary>
        /// <param name="model">DAO модель</param>
        /// <param name="contentType">Тип контента</param>
        /// <returns></returns>
        public static KladrResultModel ToModelEntity(this Doma model, ContentType contentType)
        {
            return new KladrResultModel(contentType.ToString(), model.Code, model.Index, model.Name, model.OCATD, model.Socr);
        }

        /// <summary>
        /// DAO в Модель
        /// </summary>
        /// <param name="models">DAO модели</param>
        /// <param name="contentType">Тип контента</param>
        /// <returns></returns>
        public static IEnumerable<KladrResultModel> ToModelEntityList(this IEnumerable<Doma> models, ContentType contentType)
        {
            return models.Select(m => m.ToModelEntity(contentType));
        }
    }
}
