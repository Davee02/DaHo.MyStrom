using DaHo.MyStrom.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DaHo.MyStrom.Models
{
    public class BulbResponse
    {
        /// <summary>
        /// Wether or not the bulb is now turned on (after the request has been executed)
        /// </summary>
        [JsonProperty("on")]
        public bool IsTurnedOn { get; set; }

        /// <summary>
        /// The current color
        /// </summary>
        [JsonProperty("color")]
        public string CurrentColor { get; set; }

        /// <summary>
        /// The color mode the bulb is currently set to
        /// </summary>
        [JsonProperty("mode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BulbColorMode ColorMode { get; set; }

        /// <summary>
        /// Transition time in milliseconds from the light’s current state to the new state
        /// </summary>
        [JsonProperty("ramp")]
        public long TransitionTime { get; set; }

        /// <summary>
        /// Once defined the bulb will send POST request to that URL whenever its state changes
        /// </summary>
        [JsonProperty("notifyurl")]
        public string Notifyurl { get; set; }
    }
}