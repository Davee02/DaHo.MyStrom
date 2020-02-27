using DaHo.MyStrom.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DaHo.MyStrom.Models
{
    public class AdvancedPowerCycleParameters
    {
        /// <summary>
        /// The power mode the switch should be set to
        /// </summary>
        [JsonProperty("mode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PowerMode PowerCycleMode { get; set; }

        /// <summary>
        /// How long in seconds the switch should wait until it should restart (max 3600)
        /// </summary>
        [JsonProperty("time")]
        public int TimeInSeconds { get; set; }
    }
}