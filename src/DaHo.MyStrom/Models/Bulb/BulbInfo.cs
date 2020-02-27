using DaHo.MyStrom.Models.Enums;
using Newtonsoft.Json;

namespace DaHo.MyStrom.Models
{
    public class BulbInfo
    {
        /// <summary>
        /// The type of the device
        /// </summary>
        [JsonProperty("type")]
        public string BulbType { get; set; }

        /// <summary>
        /// Wether or not the devices is using batteries
        /// </summary>
        [JsonProperty("battery")]
        public bool IsUsingBattery { get; set; }

        /// <summary>
        /// Wether or not the device is connected to a myStrom account
        /// </summary>
        [JsonProperty("reachable")]
        public bool IsConnectedToMyStromAccount { get; set; }

        /// <summary>
        /// Wether or not the bulb is currently turned on
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
        public BulbColorMode ColorMode { get; set; }

        /// <summary>
        /// How quickly the bulb changes its its color in milliseconds
        /// </summary>
        [JsonProperty("ramp")]
        public long TransitionTime { get; set; }

        /// <summary>
        /// The firmware version of the bulb
        /// </summary>
        [JsonProperty("fw_version")]
        public string FirmwareVersion { get; set; }

        /// <summary>
        /// The power consumed by the bulb measured in Watts
        /// </summary>
        [JsonProperty("power")]
        public double PowerConsumption { get; set; }
    }
}