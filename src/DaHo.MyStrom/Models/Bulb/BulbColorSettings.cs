using DaHo.MyStrom.Models.Enums;
using Newtonsoft.Json;

namespace DaHo.MyStrom.Models
{
    public class BulbColorSettings
    {
        /// <summary>
        /// The color mode the bulb is currently set to
        /// </summary>
        [JsonProperty("mode")]
        public BulbColorMode ColorMode { get; set; }

        /// <summary>
        /// The current color in the WRGB format
        /// </summary>
        [JsonProperty("current_rgb")]
        public string Wrgb { get; set; }

        /// <summary>
        /// The last set mono (white) color
        /// </summary>
        [JsonProperty("mono")]
        public string Mono { get; set; }

        /// <summary>
        /// The current color in the HSV format
        /// </summary>
        [JsonProperty("hsv")]
        public string Hsv { get; set; }
    }
}
