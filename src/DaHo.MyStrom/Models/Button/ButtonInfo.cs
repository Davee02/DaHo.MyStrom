using Newtonsoft.Json;

namespace DaHo.MyStrom.Models
{
    public class ButtonInfo
    {
        /// <summary>
        /// The type of the device (buttonplus = wheel)
        /// </summary>
        [JsonProperty("type")]
        public string ButtonType { get; set; }

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
        /// Current voltage of the button
        /// </summary>
        [JsonProperty("voltage")]
        public double CurrentVoltage { get; set; }

        /// <summary>
        /// The firmware version of the Button
        /// </summary>
        [JsonProperty("fw_version")]
        public string FirmwareVersion { get; set; }

        /// <summary>
        /// HTTP request executed when pressing the button once
        /// </summary>
        [JsonProperty("single")]
        public string SingleAction { get; set; }

        /// <summary>
        /// HTTP request executed when pressing the button twice
        /// </summary>
        [JsonProperty("double")]
        public string DoubleAction { get; set; }

        /// <summary>
        /// HTTP request executed when pressing the button long
        /// </summary>
        [JsonProperty("long")]
        public string LongAction { get; set; }

        /// <summary>
        /// HTTP request executed when touching the button (only used for Button+)
        /// </summary>
        [JsonProperty("touch")]
        public string TouchAction { get; set; }

        /// <summary>
        /// HTTP request execute in case of any action on button.
        /// Button add additional fields to the assigned address to identify the action.
        /// In addition, this action is called automatically every twelve hours, which allows you to receive the battery status of the button. (Useful for bridges or servers)
        /// </summary>
        [JsonProperty("generic")]
        public string GenericAction { get; set; }
    }
}
