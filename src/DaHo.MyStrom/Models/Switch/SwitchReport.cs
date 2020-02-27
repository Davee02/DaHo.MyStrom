using DaHo.MyStrom.Models.Enums;
using DaHo.MyStrom.Utilities;
using Newtonsoft.Json;

namespace DaHo.MyStrom.Models
{
    public class SwitchReport
    {
        /// <summary>
        /// The current power consumed by devices attached to the switch measured in Watt
        /// </summary>
        [JsonProperty("power")]
        public double ConsumedPower { get; set; }

        /// <summary>
        /// The current state of the relay (wether or not the relay is currently turned on)
        /// </summary>
        [JsonProperty("relay")]
        [JsonConverter(typeof(BooleanEnumJsonConverter))]
        public SwitchPowerState SwitchPowerState { get; set; }

        /// <summary>
        /// The currently measured temperature by the switch. (Might initially be wrong, but will automatically correct itself over the span of a few hours)
        /// </summary>
        [JsonProperty("temperature")]
        public double Temperature { get; set; }
    }
}