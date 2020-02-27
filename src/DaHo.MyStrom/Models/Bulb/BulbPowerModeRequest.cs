using DaHo.MyStrom.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DaHo.MyStrom.Models
{
    public class BulbPowerModeRequest
    {
        /// <summary>
        /// The action we want to take 
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PowerMode PowerMode { get; set; }
    }
}
