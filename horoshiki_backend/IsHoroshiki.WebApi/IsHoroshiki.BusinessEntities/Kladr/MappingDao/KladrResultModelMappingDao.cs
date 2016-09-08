using IsHoroshiki.BusinessServices.Kladr.Enums;
using System.Collections.Generic;
using System.Linq;

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
            return new KladrResultModel()
            {
                ContentType = contentType.ToString(),
                Id = model.Code,
                Index = model.Index,
                Name = model.Name,
                OKATO = model.OCATD,
                Type = model.Socr,
                TypeShort = model.Socr,
            };
        }

        /// <summary>
        /// DAO в Модель
        /// </summary>
        /// <param name="model">DAO модели</param>
        /// <param name="contentType">Тип контента</param>
        /// <returns></returns>
        public static IEnumerable<KladrResultModel> ToModelEntityList(this IEnumerable<DAO.Kladr.DaoEntities.Kladr> models, ContentType contentType)
        {
            return models.Select(m => m.ToModelEntity(contentType));
        }
    }
}
