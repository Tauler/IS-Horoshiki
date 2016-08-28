using System;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IsHoroshiki.WebApi.Handlers
{
    /// <summary>
    /// Биндинг интерфейса контроллера к сущности
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class IocCustomCreationConverter<T> : CustomCreationConverter<T>
    {
        /// <summary>
        /// Создать тип
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override T Create(Type objectType)
        {
            return (T)DependencyResolver.Current.GetService(objectType);
        }

        /// <summary>
        /// Создать объект на основе Json
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var obj = Create(objectType);
            serializer.Populate(reader, obj);
            return obj;
        }
    }
}