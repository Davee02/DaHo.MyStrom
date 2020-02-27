using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DaHo.MyStrom.Utilities
{
    internal static class ObjectExtensions
    {
        internal static IDictionary<string, string> ToDictionary(this object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return JsonConvert.DeserializeObject<IDictionary<string, string>>(json);
        }

        internal static string ToFormString(this object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var jObject = JsonConvert.DeserializeObject<JObject>(json);

            string result = string.Empty;
            foreach (var item in jObject)
            {
                result += $"{item.Key}={item.Value}&";
            }
            result.TrimEnd('&');

            return result;
        }
    }
}
