using Newtonsoft.Json;

namespace DaHo.MyStrom.Models
{
    public class LightEffect
    {
        /// <summary>
        /// The color we want to set the light strip to.
        /// Can be either in HSV or WRGB format
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }

        /// <summary>
        /// How quickly to set the led strip to the specified color in milliseconds
        /// </summary>
        [JsonProperty("ramp")]
        public long TransitionTime { get; set; }

        /// <summary>
        /// How long in seconds we wait until we start the next request
        /// If you do not want to interrupt the color ramp up, this time has to be bigger or equal than the <see cref="TransitionTime"/> value i.e. bigger or equal than <see cref="TransitionTime"/>/1000
        /// </summary>
        [JsonProperty("time")]
        public long EffectTime { get; set; }
    }
}