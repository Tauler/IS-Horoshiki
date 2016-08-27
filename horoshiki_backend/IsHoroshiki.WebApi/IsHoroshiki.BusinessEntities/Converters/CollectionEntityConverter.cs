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
    public class CollectionEntityConverter<T, Tt> : JsonConverter where T : Tt
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(IList<Tt>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            IList<Tt> items = serializer.Deserialize<List<T>>(reader).Cast<Tt>().ToList();
            return items;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(IList<T>));
        }
    }
}
