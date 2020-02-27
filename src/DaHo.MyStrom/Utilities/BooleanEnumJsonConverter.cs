using Newtonsoft.Json;
using System;

namespace DaHo.MyStrom.Utilities
{
    internal class BooleanEnumJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum;
        }

        public override bool CanWrite => false;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            bool booleanValue = bool.Parse(reader.Value.ToString());
            return Enum.ToObject(objectType, booleanValue ? 1 : 0);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
