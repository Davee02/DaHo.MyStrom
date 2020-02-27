using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace DaHo.MyStrom
{
    internal class JsonContent : StringContent
    {
        public static JsonContent From(object data) =>
            data == null 
                ? null 
                : new JsonContent(data);

        public JsonContent(object data)
            : base(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json")
        {
        }
    }
}
