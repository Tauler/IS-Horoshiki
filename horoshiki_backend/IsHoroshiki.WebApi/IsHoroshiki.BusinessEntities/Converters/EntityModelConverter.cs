using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IsHoroshiki.BusinessEntities.Converters
{
    /// <summary>
    /// Конвертер
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="Tt"></typeparam>
    public class EntityModelConverter<T, Tt> : JsonConverter where T : Tt
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Tt));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<T>(reader);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(T));
        }
    }
}
