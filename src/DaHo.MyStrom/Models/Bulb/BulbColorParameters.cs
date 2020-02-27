using DaHo.MyStrom.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DaHo.MyStrom.Models
{
    public class BulbColorParameters
    {
        /// <summary>
        /// The power mode the bulb should be set to
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PowerMode PowerMode { get; set; }

        /// <summary>
        /// The color we set the bulb to
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }

        /// <summary>
        /// The color mode we want the Bulb to set to 
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
        /// nce defined the bulb will send POST request to that URL whenever its state changes
        /// </summary>
        [JsonProperty("notifyurl")]
        public string Notifyurl { get; set; }
    }
}