using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditable.MappingDao;

namespace IsHoroshiki.BusinessEntities.Editable.MappingDao
{
    /// <summary>
    /// Меппинг полей сущности DAO на бизнес-сущность
    /// </summary>
    public static class DeliveryZoneModelMappingDao
    {
        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static DeliveryZone ToDaoEntity(this IDeliveryZoneModel model)
        {
            return new DeliveryZone()
            {
                Id = model.Id,
                Name = model.Name,
                DeliveryZoneType = model.DeliveryZoneType.ToDaoEntity(),
                Coordinates = GetBytes(model.Сoordinates)
            };
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<DeliveryZone> ToDaoEntityList(this IEnumerable<IDeliveryZoneModel> models)
        {
            return models.Select(model => model.ToDaoEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IDeliveryZoneModel ToModelEntity(this DeliveryZone model)
        {
            return new DeliveryZoneModel()
            {
                Id = model.Id,
                Name = model.Name,
                DeliveryZoneType = model.DeliveryZoneType != null ? model.DeliveryZoneType.ToModelEntity() : null,
                Сoordinates = GetString(model.Coordinates)
            };
        }

        /// <summary>
        /// DAO в модель
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<IDeliveryZoneModel> ToModelEntityList(this IEnumerable<DeliveryZone> models)
        {
            return models.Select(model => model.ToModelEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="daoModel"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static DeliveryZone Update(this DeliveryZone daoModel, IDeliveryZoneModel model)
        {
            daoModel.Id = model.Id;
            daoModel.Name = model.Name;
            daoModel.DeliveryZoneTypeId = model.DeliveryZoneType != null ? model.DeliveryZoneType.Id : 0;
            daoModel.Coordinates = GetBytes(model.Сoordinates);

            return daoModel;
        }

        /// <summary>
        /// Строка в массив байт
        /// </summary>
        private static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        /// <summary>
        /// Массив тайт в строку
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}
